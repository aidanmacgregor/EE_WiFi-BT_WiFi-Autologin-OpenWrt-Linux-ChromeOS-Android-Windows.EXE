Imports System.Net
Imports System.Text
Imports System.IO


Public Class Form1

    '' set application name and application path variables (Part Of AutoRun)
    Private ReadOnly applicationName As String = Application.ProductName
    Private ReadOnly applicationPath As String = Application.ExecutablePath

    '' Global Cookie For Login & Logout
    Dim logincookie As CookieContainer

    '' Login Counter Variable
    Dim LoginCount As Integer

    '' set new backgroundworker
    Private ReadOnly MyBackgroundWorker As New System.ComponentModel.BackgroundWorker



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '' Hide Crossthreading Error
        CheckForIllegalCrossThreadCalls = False

        '' ComboBox Options
        Dim comboSource As New Dictionary(Of String, String) From {
            {"1", "BT Home Broadband"},
            {"2", "BT Buisness Broadband"},
            {"3", "BT Wi-Fi"}
        }
        comboAcctype.DataSource = New BindingSource(comboSource, Nothing)
        comboAcctype.DisplayMember = "Value"
        comboAcctype.ValueMember = "Key"

        '' Load ComboBox Previous Settings (System - Settings - Integer)
        comboAcctype.SelectedIndex = My.Settings.saveAccType

        '' add the following to the form load event to Check Value Of AutoRun (Regisery Key) & Update CheckBox
        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)


        '' set button text
        butStartStop.Text = "Start Service"

        butRunningStatus.BackColor = Color.Red

        '' set backgroundworker settings
        MyBackgroundWorker.WorkerSupportsCancellation = True
        MyBackgroundWorker.WorkerReportsProgress = True
        AddHandler MyBackgroundWorker.DoWork, AddressOf MyBackgroundWorker_Login_Loop
        AddHandler MyBackgroundWorker.RunWorkerCompleted, AddressOf MyBackgroundWorker_Completed

        '' Check For AutoRun Registery Key, Mark Checkbox & Start Service if key is present
        If CStr(regKey.GetValue(applicationName)) = """" & applicationPath & """" Then
            checkboxAutorun.Checked = True
            Me.butStartStop.PerformClick()
        Else
            checkboxAutorun.Checked = False
        End If
        regKey.Close()

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStartStop.Click

        If butStartStop.Text = "Start Service" Then

            '' Change Button Function
            butStartStop.Text = "Stop Service"

            '' Status Button Coulour
            butRunningStatus.BackColor = Color.Green

            '' Clear HTTP Response
            richtxtHTTPresponse.Clear()

            '' start backgroundworker process
            If MyBackgroundWorker.IsBusy = False Then
                MyBackgroundWorker.RunWorkerAsync()
            End If

        ElseIf butStartStop.Text = "Stop Service" Then

            '' Sleep To Ensure Enough Time For Thread To Initalise Before Stopping (Dont Know If Nesicerry But Seems Like Good Idea)
            Threading.Thread.Sleep(1000)

            '' cancel bacgroundworker process (sets CancellationPending to True)
            MyBackgroundWorker.CancelAsync()

        End If

    End Sub



    Private Sub MyBackgroundWorker_Login_Loop(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)

        '' Label To Loop Back To On Exeption
ErrorLoop:

        '' start infinite loop
        Do

            Try

                '' Combo Box Read Selection
                Dim keyAcctype As String = DirectCast(comboAcctype.SelectedItem, KeyValuePair(Of String, String)).Key
                Dim valueAcctype As String = DirectCast(comboAcctype.SelectedItem, KeyValuePair(Of String, String)).Value

                If My.Computer.Network.Ping("1.1.1.1") = False Then

                    '' Internet Status "LED"
                    butInternetStatus.BackColor = Color.Red

                    '' Wait Before Testing Internet Again (May Help Reduce Any False Positives)
                    Threading.Thread.Sleep(500)

                    If My.Computer.Network.Ping("8.8.8.8") = False Then

                        '' Clear HTTP Request
                        richtxtHTTPresponse.Clear()

                        '' Post Data String
                        Dim postData As String = $"username={txtEmail.Text}&password={txtPassword.Text}"

                        '' Post Data Settings
                        Dim tempCookies As New CookieContainer
                        Dim encoding As New UTF8Encoding
                        Dim byteData As Byte() = encoding.GetBytes(postData)

                        If keyAcctype = 1 Then

                            Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://btwifi.com:8443/tbbLogon"), HttpWebRequest)
                            postReq.Method = "POST"
                            postReq.KeepAlive = False
                            postReq.CookieContainer = tempCookies
                            postReq.ContentType = "application/x-www-form-urlencoded"
                            postReq.Referer = "https://google.com"
                            postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; RV:26.0) Gecko/20100101 Firefox/26.0"
                            postReq.ContentLength = byteData.Length

                            Dim postreqstream As Stream = postReq.GetRequestStream()
                            postreqstream.Write(byteData, 0, byteData.Length)
                            postreqstream.Close()
                            Dim postresponse As HttpWebResponse
                            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
                            tempCookies.Add(postresponse.Cookies)
                            logincookie = tempCookies
                            Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
                            Dim thepage As String = postreqreader.ReadToEnd

                            '' Temporary Write Response To Rich Text Box
                            richtxtHTTPresponse.Text = thepage

                            '' Check Rich Text Box & Replace Withe Useful Message
                            If thepage.Contains("You&#8217;re now logged on to BT Wi-Fi") Then
                                richtxtHTTPresponse.Text = ("Logged In Sucsesfully " & TimeString)
                                LoginCount = Integer.Parse(txtLoginCount.Text)
                                LoginCount += 1
                                txtLoginCount.Text = LoginCount
                            ElseIf thepage.Contains("Please check you have entered your Username/Password correctly") Then
                                richtxtHTTPresponse.Text = "Username/Password Error"
                            End If

                        ElseIf keyAcctype = 2 Then

                            Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://www.btwifi.com:8443/ante?partnerNetwork=btb"), HttpWebRequest)
                            postReq.Method = "POST"
                            postReq.KeepAlive = False
                            postReq.CookieContainer = tempCookies
                            postReq.ContentType = "application/x-www-form-urlencoded"
                            postReq.Referer = "https://google.com"
                            postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; RV:26.0) Gecko/20100101 Firefox/26.0"
                            postReq.ContentLength = byteData.Length

                            Dim postreqstream As Stream = postReq.GetRequestStream()
                            postreqstream.Write(byteData, 0, byteData.Length)
                            postreqstream.Close()
                            Dim postresponse As HttpWebResponse
                            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
                            tempCookies.Add(postresponse.Cookies)
                            logincookie = tempCookies
                            Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
                            Dim thepage As String = postreqreader.ReadToEnd

                            '' Temporary Write Response To Rich Text Box
                            richtxtHTTPresponse.Text = thepage

                            '' Check Rich Text Box & Replace Withe Useful Message
                            If thepage.Contains("You&#8217;re now logged on to BT Wi-Fi") Then
                                richtxtHTTPresponse.Text = ("Logged In Sucsesfully " & TimeString)
                                LoginCount = Integer.Parse(txtLoginCount.Text)
                                LoginCount += 1
                                txtLoginCount.Text = LoginCount
                            ElseIf thepage.Contains("Please check you have entered your Username/Password correctly") Then
                                richtxtHTTPresponse.Text = "Username/Password Error"
                            End If

                        ElseIf keyAcctype = 3 Then

                            Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://www.btwifi.com:8443/ante"), HttpWebRequest)
                            postReq.Method = "POST"
                            postReq.KeepAlive = False
                            postReq.CookieContainer = tempCookies
                            postReq.ContentType = "application/x-www-form-urlencoded"
                            postReq.Referer = "https://google.com"
                            postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; RV:26.0) Gecko/20100101 Firefox/26.0"
                            postReq.ContentLength = byteData.Length

                            Dim postreqstream As Stream = postReq.GetRequestStream()
                            postreqstream.Write(byteData, 0, byteData.Length)
                            postreqstream.Close()
                            Dim postresponse As HttpWebResponse
                            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
                            tempCookies.Add(postresponse.Cookies)
                            logincookie = tempCookies
                            Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
                            Dim thepage As String = postreqreader.ReadToEnd

                            '' Temporary Write Response To Rich Text Box
                            richtxtHTTPresponse.Text = thepage

                            '' Check Rich Text Box & Replace Withe Useful Message
                            If thepage.Contains("You&#8217;re now logged on to BT Wi-Fi") Then
                                richtxtHTTPresponse.Text = ("Logged In Sucsesfully " & TimeString)
                                LoginCount = Integer.Parse(txtLoginCount.Text)
                                LoginCount += 1
                                txtLoginCount.Text = LoginCount
                            ElseIf thepage.Contains("Please check you have entered your Username/Password correctly") Then
                                richtxtHTTPresponse.Text = "Username/Password Error"
                            End If

                        End If
                    End If
                Else
                    ''Green Internet Status If Ping Sucsessful
                    butInternetStatus.BackColor = Color.Green
                End If

            Catch ex As Exception  '' This Exeption Cathes Ping Failing & DNS ERRORS

                '' Listen For CancelAsync & Exit The Loop
                If MyBackgroundWorker.CancellationPending = True Then
                    Exit Do
                End If

                '' Check For Network & Report Interet Status
                If My.Computer.Network.IsAvailable Then
                Else
                    '' Internet Connection Fail Status Light
                    butInternetStatus.BackColor = Color.Red
                End If

                '' Change info Label
                richtxtHTTPresponse.Text = "No BT Wi-Fi Connection"

                '' Wait Before Testing Internet Again To Not Flood Server With Requests
                Threading.Thread.Sleep(1000)

                richtxtHTTPresponse.Clear()

                '' Loop Attemps To Login Instead Of Exeption & Crash
                GoTo ErrorLoop

            End Try

            '' Listen For Do Loop Exit
            If MyBackgroundWorker.CancellationPending = True Then

                Exit Do

            End If

            '' Wait Before Testing Internet Again To Not Flood Server With Requests
            Threading.Thread.Sleep(1000)

        Loop

    End Sub



    Private Sub MyBackgroundWorker_Completed(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)

        richtxtHTTPresponse.Clear()

        '' Try & Catch Exeption To Avoid Crashes
        Try

            Dim postData As String = ""
            Dim tempCookies As New CookieContainer
            Dim encoding As New UTF8Encoding
            Dim byteData As Byte() = encoding.GetBytes(postData)

            Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://btwifi.com:8443/accountLogoff/home?confirmed=true"), HttpWebRequest)
            postReq.Method = "POST"
            postReq.KeepAlive = False
            postReq.CookieContainer = tempCookies
            postReq.ContentType = "application/x-www-form-urlencoded"
            postReq.Referer = "https://google.com"
            postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; RV:26.0) Gecko/20100101 Firefox/26.0"
            postReq.ContentLength = byteData.Length

            Dim postreqstream As Stream = postReq.GetRequestStream()
            postreqstream.Write(byteData, 0, byteData.Length)
            postreqstream.Close()
            Dim postresponse As HttpWebResponse
            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
            tempCookies.Add(postresponse.Cookies)
            logincookie = tempCookies
            Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
            Dim thepage As String = postreqreader.ReadToEnd

            '' Temporary Write Response To Rich Text Box
            richtxtHTTPresponse.Text = thepage

            '' Check Rich Text Box & Replace Withe Useful Message
            If thepage.Contains("landing.htm") Then
                richtxtHTTPresponse.Text = "Logged Out"
            End If

            '' Status "Lights"
            butRunningStatus.BackColor = Color.Red
            butInternetStatus.BackColor = Color.Red

            '' Change Button Function
            butStartStop.Text = "Start Service"

            '' Try & Catch Exeption To Avoid Crashes
        Catch ex As Exception

            '' Error Shows When Unable To Resolve BT Wi-Fi DNS
            richtxtHTTPresponse.Text = "No BT Wi-Fi Connection"

            ''cancel bacgroundworker process (sets CancellationPending to True)
            MyBackgroundWorker.CancelAsync()

            '' Change Button Function & "Lights"
            butRunningStatus.BackColor = Color.Red
            butStartStop.Text = "Start Service"

        End Try

    End Sub


    '' Handle The Minimize To Tray Function
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
            NotifyIcon1.Visible = True
        End If

    End Sub



    '' Handle The Double Click (OPEN) Of The System Tray Icon (Add In [DESIGN] page to form)
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False

    End Sub



    '' Handle Context Menu Open (Right CLick System Tray > Open)
    Private Sub ContextOpen_Click(sender As Object, e As EventArgs) Handles contextOpen.Click

        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False

    End Sub



    '' Handle Context Menu Exit (Right CLick System Tray > Exit)
    Private Sub ContextExit_Click(sender As Object, e As EventArgs) Handles contextExit.Click

        Close()

    End Sub



    '' Handle Version & Website Opening
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Try
            MessageBox.Show("BT Wi-Fi Autologin Service v3 (July 2022)")
            Dim url As String = “https://www.youtube.com/c/AidanMacgregor“
            Process.Start(url)
        Catch ex As Exception
            MessageBox.Show("BT Wi-Fi Autologin Service v3 (July 2022) --ERROR OPENING WEBSITE--")
        End Try

    End Sub



    '' While closing the program, Handles The Saving Of ComboBox & Autorun...
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try
            If e.CloseReason = CloseReason.UserClosing Then

                '' ComboBox Save Settings (System - Settings - Integer)
                My.Settings.saveAccType = comboAcctype.SelectedIndex

                'Set Or Remove registry key to Autorun application if checkbox is checked
                If checkboxAutorun.Checked Then
                    Dim regKey As Microsoft.Win32.RegistryKey
                    regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                    regKey.SetValue(applicationName, """" & applicationPath & """")
                    regKey.Close()
                Else
                    Dim regKey As Microsoft.Win32.RegistryKey
                    regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                    regKey.DeleteValue(applicationName, False)
                    regKey.Close()
                End If

            End If

        Catch ex As Exception

            MessageBox.Show("Error During Close, Data May NOT Be Saved")

        End Try

    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles butReset.Click

        Dim ask As MsgBoxResult = MsgBox("Really Delete Login Count Data? (Irriversable)", MsgBoxStyle.YesNo)

        If ask = MsgBoxResult.Yes Then
            txtLoginCount.Text = 0
        End If

    End Sub



End Class

