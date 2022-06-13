This Is The Main Windows EXE Code, The Rest Is In The Zip File
------------- DONT COPY THIS & UP --------------

Imports System.Net
Imports System.Text
Imports System.IO


Public Class Form1

    '' set application name and application path variables (Part Of AutoRun)
    Private applicationName As String = Application.ProductName
    Private applicationPath As String = Application.ExecutablePath
    '' Global Cookie For Login & Logout
    Dim logincookie As CookieContainer
    '' set new backgroundworker
    Private ReadOnly MyBackgroundWorker As New System.ComponentModel.BackgroundWorker



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Hide Crossthreading Error
        CheckForIllegalCrossThreadCalls = False

        '' ComboBox Options
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add("1", "BT Home Broadband")
        comboSource.Add("2", "BT Buisness Broadband")
        comboSource.Add("3", "BT Wi-Fi")
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

        '' set backgroundworker settings
        MyBackgroundWorker.WorkerSupportsCancellation = True
        MyBackgroundWorker.WorkerReportsProgress = True
        AddHandler MyBackgroundWorker.DoWork, AddressOf MyBackgroundWorker_Login_Loop
        AddHandler MyBackgroundWorker.RunWorkerCompleted, AddressOf MyBackgroundWorker_Completed

        '' Check For AutoRun Registery Key, Mark Checkbox & Start Service
        If CStr(regKey.GetValue(applicationName)) = """" & applicationPath & """" Then

            CheckBox1.Checked = True
            Me.butStartStop.PerformClick()

        Else

            CheckBox1.Checked = False

        End If

        regKey.Close()

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStartStop.Click

        RichTextBox1.Clear()

        If butStartStop.Text = "Start Service" Then

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

        RichTextBox1.Clear()

        '' Label To Loop Back To On Exeption
ErrorLoop:
        '' start infinite loop
        Do

            Try

                Dim keyAcctype As String = DirectCast(comboAcctype.SelectedItem, KeyValuePair(Of String, String)).Key
                Dim valueAcctype As String = DirectCast(comboAcctype.SelectedItem, KeyValuePair(Of String, String)).Value

                '' Change Button Function
                butStartStop.Text = "Stop Service"
                Label6.Text = "STATUS: Running..."

                If My.Computer.Network.Ping("1.1.1.1") = False Then

                    '' Wait Before Testing Internet Again (May Help Reduce Any False Positives)
                    Threading.Thread.Sleep(500)

                    If My.Computer.Network.Ping("8.8.8.8") = False Then

                        RichTextBox1.Clear()

                        Dim postData As String = $"username={txtEmail.Text}&password={txtPassword.Text}"

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

                            RichTextBox1.Text = thepage

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

                            RichTextBox1.Text = thepage

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

                            RichTextBox1.Text = thepage

                        End If

                    End If

                End If

            Catch ex As Exception

                '' Listen For CancelAsync & Exit The Loop
                If MyBackgroundWorker.CancellationPending = True Then

                    Exit Do

                End If

                '' Change info Label
                Label6.Text = "STATUS: No BT Wi-Fi Connection"

                '' Wait Before Testing Internet Again To Not Flood Server With Requests
                Threading.Thread.Sleep(1000)

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

        MessageBox.Show("Logging Out & Stopping Service")

        '' Change Button Function
        Label6.Text = "Stopped"
        butStartStop.Text = "Start Service"

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

            RichTextBox1.Text = thepage

        Catch ex As Exception

            '' Error Shows When Unable To Resolve BT Wi-Fi DNS
            MessageBox.Show("Log Out -- Error Communicating With BT Wi-Fi (DNS / Not BT Wi-Fi Hotspot?)")

            ''cancel bacgroundworker process (sets CancellationPending to True)
            MyBackgroundWorker.CancelAsync()

            '' Change Button Function
            Label6.Text = "STATUS: Stopped"
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

            MessageBox.Show("BT Wi-Fi Autologin Service v.1 (June 2022)")

            Dim url As String = “https://www.youtube.com/c/AidanMacgregor“
            Process.Start(url)

        Catch ex As Exception

            MessageBox.Show("BT Wi-Fi Autologin Service v.1 (June 2022) --ERROR OPENING WEBSITE--")

        End Try

    End Sub



    '' Handle The Saving Of ComboBox etc... while closing the program)
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try

            If e.CloseReason = CloseReason.UserClosing Then

                '' ComboBox Save Settings (System - Settings - Integer)
                My.Settings.saveAccType = comboAcctype.SelectedIndex

                'Set Or Remove registry key to Autorun application if checkbox is checked
                If CheckBox1.Checked Then

                    Dim regKey As Microsoft.Win32.RegistryKey
                    regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                    regKey.SetValue(applicationName, """" & applicationPath & """")
                    regKey.Close()

                Else

                    Dim regKey As Microsoft.Win32.RegistryKey
                    regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                    '' Delete registry key to prevent app from starting on windows startup
                    regKey.DeleteValue(applicationName, False)
                    regKey.Close()

                End If

            End If

        Catch ex As Exception

            MessageBox.Show("Error During Close, Data May NOT Be Saved")

        End Try

    End Sub



End Class
