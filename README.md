# BTWi-fi Autologin (OpenWrt Service) (Windows.exe) (BASH Script.sh) (Android & Chrome OS Macrodroid) (WISPr URL) (HTTP-POST) (HTTP-GET)

![48 info](https://user-images.githubusercontent.com/11254983/166980034-691be097-a101-43bb-b44e-646f04299b87.png) OpenWrt Script Has Now Been Replaced With A Service (v3) </br>

(Install The Archive.tar.gz From LUCI > Backup & Change Settings From LUCI > Startup > Local Startup) </br>



### General Information
The BT Wi-Fi Service Comes With Several Options To Gain Access To The Network<br/>

- Pay & Go On Demand (1 Hour To 30 Days)
- Pay & Go Subscription (3 OR 12 Months Up To 5 Devices Online, 5 People Could Split 12 Months and pay £3 Each Per Month)
- As A BT Broadband OR BT Mobile Customer (BT Broadband and BT Mobile customers get free, unlimited access to the BT Wi-Fi network)
- FON (No longer in partnership with Fon as of 2020)

Therse Are The URLs I Have Found To Login Without Loading A Webpage OR Typing Credidetials Every Time<br/>

- BT Log You Out Automatically After 4 Hours (And A Few Seconds)
- There Are 4 URLs, (HTTP GET May Only Work With Home Broadband, Others Untested) 
- If Using OpenWrt Restore The Customised Backup Zips & Add Account In LUCI "Local Startup"
- If Using Windows .NET 4.6+ May Be Needed With Windows Vista To Windows 8.1 (Should Just Work Windows 10 & Newer)
- If Using Macrodroid Download The Macro & Edit The Variables Drawer To Add Account (Work With Chrome OS)
- If Using Inside A Linux Script Edit The URL To Include Your Account Info



### SSIDs:
(Pulled From APK, No longer in partnership with Fon as of 2020, Most Hotspots Now Branded BTWi-fi)

- BTWi-fi 
- _BTWi-fi 
- BTWifi-with-FON
- BTWiFi-with-FON
- BTOpenzone
- BTOpenzone-H
- BTOpenzone-B
- BTWiFi 
- BTFON



### Testing Results
Tested In A Home Internet Replacment Setting, using BT Home Hub 5 Flashed With OpenWRT Configured in Client & Access Point Mode (Windows Direct BT Wi-Fi Connection)

- This allows one device to sign in every device inside my network <br/>
- this runs well & downtime is almost non existant <br/>
- manually logging out and letting it sign itself in didnt break an active download i had running



### Speeds For Me: (You Will Vary)

- Ping Approx. 30ms <br/>
- Download 40-60 Mbps <br/>
- Upload Approx 11-17 Mbps<br/>






# ![youtube-logo-png-46026](https://user-images.githubusercontent.com/11254983/164994883-0a78494e-ae24-4eee-bdbe-a165a7c7d890.png) OpenWRT BTWi-fi YouTube Guide<br/>
Updated Video Planned Soon!

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/z7pTcrwUQkU/0.jpg)](https://www.youtube.com/watch?v=z7pTcrwUQkU)
<br/>


 # ![2528830](https://user-images.githubusercontent.com/11254983/164993973-1b534096-84a8-4785-bf39-ea177eea4274.png) OpenWrt Autologin Service, LED & Theme<br/>
Set Up OpenWrt With BTWi-fi & The Autologin Service, THEME & LED Service Also Availible

<details>
  <summary>Click to expand!</summary>

## Install The tar.gz Files Using LUCI (System > Backup / Flash Firmware)
	
![Install](https://user-images.githubusercontent.com/11254983/173888569-542fbbdd-c7c9-41cf-8411-1eceed69610c.JPG)	

## Autologin Service (System > Startup)
	
![Startup (3)](https://user-images.githubusercontent.com/11254983/173452552-d591d1c8-edd6-460b-b9bf-39509da5fda1.JPG)

## Add Your Account (System > Startup > Local Startup)
	
![Local Startup (3)](https://user-images.githubusercontent.com/11254983/173452553-e6a26dde-2d85-478a-9c94-22dde81a19fc.JPG)

## OpenWrt Code & Downloads
    
[Login Service](https://github.com/aidanmacgregor/BT_Wi-fi_Autologin_-_OpenWrt_Windows.EXE_Linux_Android-Macrodroid/tree/main/BT%20Wi-Fi%20Autologin%20Service/Login%20Service%20OpenWrt%20(Service))
    
[LED Service](https://github.com/aidanmacgregor/BT_Wi-fi_Autologin_-_OpenWrt_Windows.EXE_Linux_Android-Macrodroid/tree/main/OpenWrt%20Theme%20%26%20LED%20Service/OpenWrt%20LED%20Service)
    
[Themes](https://github.com/aidanmacgregor/BT_Wi-fi_Autologin_-_OpenWrt_Windows.EXE_Linux_Android-Macrodroid/tree/main/OpenWrt%20Theme%20%26%20LED%20Service/OpenWrt%20Theme)
    
  </details>


  
  
  
  
# ![Winlogo48NEW](https://user-images.githubusercontent.com/11254983/173395338-8a7c71f5-caf0-45e8-bb6f-0574fd4ec867.png) Windows Autologin Service <br/>
Automatic Login, Start On Boot, Always Online, Minimise System To Tray
Works On All Windows 10 & Newer As Is
Windows Vista, 7, 8 & 8.1 Needs .net 4.6 to be manually installed
(First Attempt At Making Windows Software)

<details>
  <summary>Click to expand!</summary>
  
  ## Windows GUI
![BT Wi-Fi Windows App](https://user-images.githubusercontent.com/11254983/184173045-f6e5ce51-4128-44fb-9964-eadcf718cf71.png)
  
## Features:

- New UI Design [[NEW v4]]
- Automatic Login To UK Wide BT Wi-Fi Hotspots
- Tray Icon Double Click To Restore & Minnimise [[NEW v5]]
- Tray Icon Will Bring Window To Front Focus [[NEW v5]]
- Close Will Minimise To Tray (Exit By Using Right Click On Tray Icon, This WONT Run The Log Out URL, If Log Out Is Needed Thet Stop Service First) [[NEW v4]]
- Tray Icon Changes (Red & Green) To Reflect Current Internet Status Status (Reccomend Dragging Moving It To always Show Next To Wi-Fi Icom) [[NEW v4]]
- Auto Run Regestery Key & Start Service At Boot Option
- Saves State & Settings Instsantly When Changing Allowing For Reboot etc... Without loosing Settings [[NEW v4]]
- Http Response Based Sucsess Check Text Box (Indicates Login Sucsess, No Bt Wi-Fi/Internet, Wrong Username OR Password/Account Type)
- BT Wi-Fi Map Link Included [[NEW v4]]
- Status Indicators For Running & Internet
- Login Count
- Logoff URL is Run On Stop Service (About 10 Second Delay On BT Side Fr Logout To Stop Internet)
- HTTP Post Request Used For Login & Logout
- Complete rewrite, import should work work visual studio [[NEW v4]]

## Windows Code & Downloads
[Login Service](https://github.com/aidanmacgregor/BT-Wi-Fi-Autologin-Windows)

  </details>
 
 
 
 
 
 
 # ![MacroDroid_forum_48](https://user-images.githubusercontent.com/11254983/164982041-be7d0dd7-5c9a-4b24-a5a4-4e8f82a17bc5.png) Macrodroid Autologin Setup (Android 5.0+ & Chrome OS)<br/>
Automatic Login From An Android Device, With Alway Online, Charging Only Mode, Track The Number Of Logins & See How To Set Android Up As Wi-Fi Repeater 

<details>
  <summary>Click to expand!</summary>

## Downoad From Play Store Template Availible In The Macrodroid Template Store!

![Screenshot_20220502-194637_MacroDroid](https://user-images.githubusercontent.com/11254983/166310061-5c8bb11f-a9ec-429a-aa6c-8796fb5f5a72.jpg)
 <br/>

  
## Macrodroid GUI (Edit Settings & Add Account Here)
<details>
  <summary>Click to expand!</summary>

<br/>
Settings & Information Here<br/>
<br/>
	  
![3  Screenshot_20220415-230400_MacroDroid_copy_640x1422](https://user-images.githubusercontent.com/11254983/163649231-921d6e70-86e0-46d0-8064-635d2b450ab8.png) <br/>

 </details>
	
## Android Code & Downloads

[Login Service](https://github.com/aidanmacgregor/BT_Wi-fi_Autologin_-_OpenWrt_Windows.EXE_Linux_Android-Macrodroid/tree/main/BT%20Wi-Fi%20Autologin%20Service/Login%20Service%20Android%20(Macrdroid))
  
<br/>

   </details>	
		
## Android Wi-Fi Repeater
<details>
  <summary>Click to expand!</summary>
<br/>
Wi-Fi Sharing Android (Dont Forget To Set A Password)<br/>
<br/>
	
![Screenshot_20220505-215917_Settings](https://user-images.githubusercontent.com/11254983/167026350-4fd79afb-2073-438e-83e2-5dca2778b921.png)
  
<br/>

   </details>
	</details>






# ![48 terminal-icon copy](https://user-images.githubusercontent.com/11254983/164985283-235c64c3-415e-4cb1-8ce9-8967c23add8e.png) Linux Bash Script

This is a shell script to automate the sign in and always remain connected to BTWi-fi, Designed To Be Light, Simple & fast

<details>
  <summary>Click to expand!</summary>
    
## Terminal Running
![WSL2](https://user-images.githubusercontent.com/11254983/173451001-cce58162-7475-4322-9744-fb842ce40209.JPG)

## Linux Code & Download
[Login Service](https://github.com/aidanmacgregor/BT_Wi-fi_Autologin_-_OpenWrt_Windows.EXE_Linux_Android-Macrodroid/tree/main/BT%20Wi-Fi%20Autologin%20Service/Login%20Service%20Linux%20(Bash))
    
 </details>






# ![48 http copy 2](https://user-images.githubusercontent.com/11254983/164985125-01ad4452-6b6a-42e7-94d5-a04020e1ded5.png) Autologin URLs (HTTP POST & HTTP GET)

The RAW URLs the BT Service Uses To Login

<details>
  <summary>Click to expand!</summary>
  
## HTTP POST
<details>
  <summary>Click to expand!</summary>
    
    HTTP POST URLs, These Should Work With All Account Types

### ![48 green icon](https://user-images.githubusercontent.com/11254983/164984530-03352fa6-2b61-427a-b92c-911b60fee1bb.png) Secure HTTP POST (With SSL Certificate) <br/>
(Normal Login, Does NOT Work With Other DNS Settings EG. Google DNS)<br/>

- BT Home Broadband:
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/tbbLogon
  
- BT Wi-Fi (Pay & Go):
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/ante
  
- BT Buisness Broadband:
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/ante?partnerNetwork=btb

### ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure HTTP POST (Must Allow Any Certificate) <br/>
(SSL Error, Works With Other DNS Settings EG. Google DNS)
  
- BT Home Broadband:
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://192.168.23.21:8443/tbbLogon
  
- BT Wi-Fi (Pay & Go):
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://192.168.23.21:8443/ante
  
- BT Buisness Broadband:
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://192.168.23.21:8443/ante?partnerNetwork=btb

</details>

    
	
## HTTP GET (Browser URL bar)
<details>
  <summary>Click to expand!</summary>
    
    HTTP GET URLs, This Has Been Tested With Home Broadband Accounts, Others Unknown

### ![48 green icon](https://user-images.githubusercontent.com/11254983/164993018-7814c4d6-baee-4602-aae1-a9def39702cd.png) Secure HTTP GET (With SSL Certificate)<br/>
(Normal Login, Does NOT Work With Other DNS Settings EG. Google DNS) <br/>

https://www.btwifi.com:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD

### ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure HTTP GET (Must Allow Any Certificate)<br/>
(SSL Error in Browser, Works With Other DNS Settings EG. Google DNS) <br/>

https://192.168.23.21:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD
 
  </details>
</details>







# ![48 logoffpng](https://user-images.githubusercontent.com/11254983/164995694-4273493d-8bb6-4df4-91b4-ba90b926ce6c.png) Logoff (HTTP GET & Browser URL) <br/>
These URLs can be used to manually log out

<details>
  <summary>Click to expand!</summary>

### ![48 green icon](https://user-images.githubusercontent.com/11254983/164993018-7814c4d6-baee-4602-aae1-a9def39702cd.png) Secure Page

(Normal Logoff, Does NOT Work With Other DNS Settings EG. Google DNS) <br/>

https://www.btwifi.com:8443/accountLogoff/home?confirmed=true

### ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure
    
(SSL Error in Browser, Work With Other DNS Settings EG. Google DNS) <br/>

https://192.168.23.21:8443/accountLogoff/home?confirmed=true

</details>

  
  
  
  
  
  
# ![48 Yellow Info](https://user-images.githubusercontent.com/11254983/164985697-861a5a64-e88a-4279-a317-13859676e50e.png) Rebind Protection & Alternatave DNS (Safesearch Remove)
 Useful Info (OpenWrt Guide Already Included These Steps)
 
 <details>
  <summary>Click to expand!</summary>

<br/>

- Rebind Protection Needs To Be "OFF" To Load The Login Page Using Browser "btwifi.com:8443"
- To Use Rebind Protection "ON" (OpenWrt Default) Use The Insecure URLs (Cert Warning) "192.168.23.21:8443"

## Im Using Google DNS on the internal network To Remove Forced Google Safe Search<br/>

- Chose Network > Interfaces From The Menu
- EDIT the LAN Interface<br/>

![Interfaces](https://user-images.githubusercontent.com/11254983/173432696-46497af9-22af-4df6-99eb-12e17bb6f4b9.JPG)

- Open DHCP Server Tab, Advanced, Under DHCP-Options ADD

 ![dhcp options](https://user-images.githubusercontent.com/11254983/173432775-b3fa400d-aca2-465f-9096-86213073847f.JPG)

</details>
