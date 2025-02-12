# EE WiFi (BT Wi-Fi) Autologin (OpenWrt Service) (Windows.exe) (BASH Script.sh) (Android & Chrome OS Macrodroid) (WISPr URL) (HTTP-POST) (HTTP-GET)


## ![48 info](https://user-images.githubusercontent.com/11254983/166980034-691be097-a101-43bb-b44e-646f04299b87.png) BT Wi-Fi is now EE WiFi  ![download](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_OpenWrt_Linux_ChromeOS_Android_Macrodroid_Windows.EXE/assets/11254983/196d7a5b-e3d7-415b-bf05-893b2f4f55e4) 
- BT Wi-Fi is now EE WiFi, Your existing username and password will remain valid going forward. When you see the "EE WiFi" network you can connect to this in the same way you currently use "BTWi-fi". </br>


## General Information

- Jan 2024: "The BT Wi-Fi App Is Being Removed, Access to EE Wi-Fi Still Available via Web Browser" (Or Use My Macrodroid Script)
- Jan 2024: Most Hotspots now "EE WiFi" My parents are still running "BTWiFi" on their BT HomeHub 3 (Seems no more updates to this router)

The EE WiFi (BT Wi-Fi) Service Comes With Several Options To Gain Access To The Network<br/>

- Pay & Go On Demand (1 Hour To 30 Days)
- BT or EE Broadband & BT Mobile Customers (EE/BT Broadband & BT Mobile customers get free, unlimited access to the EE WiFi network)
- ~~Pay & Go Subscription (3 OR 12 Months Up To 5 Devices Online, 5 People Could Split 12 Months and pay £3 Each Per Month)~~ (No Longer Available 2023)
- ~~FON Account~~ (No longer in partnership with Fon as of 2020)

Therse Are The URLs I Have Found To Login Without Loading A Webpage OR Typing Credidetials Every Time<br/>

- BT Log You Out Automatically After 4 Hours (And A Few Seconds)
- There Are 4 URLs, (HTTP GET May Only Work With Home Broadband, Others Untested) 
- If Using OpenWrt Restore The Customised Backup Zips & Add Account In LUCI "Local Startup"
- If Using Windows .NET 4.6+ May Be Needed With Windows Vista To Windows 8.1 (Should Just Work Windows 10 & Newer)
- If Using Macrodroid Download The Macro & Edit The Variables Drawer To Add Account (Work With Chrome OS)
- If Using Inside A Linux Script Edit The URL To Include Your Account Info


## SSIDs:
(Pulled From APK, No longer in partnership with Fon as of 2020, Most Hotspots Now Branded "EE WiFi")
```
EE WiFi
BTWi-fi
_BTWi-fi
BTWiFi
BTWiFi-with-FON
BTWifi-with-FON
BTOpenzone
BTOpenzone-H
BTOpenzone-B
BTFON
```


## Testing Results
Tested In A Home Internet Replacment Setting, using BT Home Hub 5 Flashed With OpenWRT Configured in Client & Access Point Mode (Windows Direct BT Wi-Fi Connection)

- This allows one device to sign in every device inside my network <br/>
- this runs well & downtime is almost non existant <br/>
- manually logging out and letting it sign itself in didnt break an active download i had running


## Speeds For Me: (You Will Vary)
- Ping Approx. 30ms <br/>
- Download 40-60 Mbps <br/>
- Upload Approx 11-17 Mbps<br/>

## My Network Topology (OpenWrt):
![topology](https://github.com/user-attachments/assets/67f17b36-6a40-402e-888c-080327309188)


# ![youtube-logo-png-46026](https://user-images.githubusercontent.com/11254983/164994883-0a78494e-ae24-4eee-bdbe-a165a7c7d890.png) OpenWRT EE WiFi (BTWi-fi) YouTube Guide
- Updated Video Planned Soon!
<br/>

# ![2528830](https://user-images.githubusercontent.com/11254983/164993973-1b534096-84a8-4785-bf39-ea177eea4274.png) OpenWrt Autologin Service, LED & Theme

<details>
  <summary>Click to expand!</summary><br/>
- Set Up OpenWrt With EE WiFi (BTWi-fi) & The Autologin Service, THEME & LED Service Also Availible


### ![48 info](https://user-images.githubusercontent.com/11254983/166980034-691be097-a101-43bb-b44e-646f04299b87.png) Install The tar.gz Files Using LUCI (System > Backup / Flash Firmware)

![1-UPLOAD ARCHIVE](https://github.com/user-attachments/assets/9d1fca5f-ab1e-4474-b9a6-fe8849483390)

### Autologin Service (System > Startup)
	
![2-ENABLE SERVICE COMBINE](https://github.com/user-attachments/assets/bacf534c-cfa1-499e-9950-d74a34927299)

### Add Your Account (System > Startup > Local Startup)
	
![3-ADD ACCOUNT](https://github.com/user-attachments/assets/9458ae35-9105-417f-bd93-bd3e810b908c)

### ![10254536-48](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_OpenWrt_Linux_ChromeOS_Android_Macrodroid_Windows.EXE/assets/11254983/60b4e9d1-52d9-4805-882f-16e90f6f60a4) OpenWrt Code & Downloads
    
[Login Service](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_OpenWRT)
    
[LED Service](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_OpenWRT/tree/main/OpenWrt%20Themes%20%26%20LED%20Service/OpenWrt%20LED%20Service)
    
[Themes](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_OpenWRT/tree/main/OpenWrt%20Themes%20%26%20LED%20Service/OpenWrt%20Theme)
    
  </details><br/>


# ![Winlogo48NEW](https://user-images.githubusercontent.com/11254983/173395338-8a7c71f5-caf0-45e8-bb6f-0574fd4ec867.png) Windows Autologin Service

<details>
  <summary>Click to expand!</summary><br/>

- Automatic Login, Start On Boot, Always Online, Minimise System To Tray
- Works On All Windows 10 & Newer As Is
- Windows Vista, 7, 8 & 8.1 Needs .net 4.6 to be manually installed
- First Attempt At Making Windows Software

## Windows GUI
![WINDOWS SOFTWARE](https://github.com/user-attachments/assets/fe6d8bdc-502a-4586-9e3b-e64d5cf8ab34)
  
## ![48 info](https://user-images.githubusercontent.com/11254983/166980034-691be097-a101-43bb-b44e-646f04299b87.png) Features:
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

## ![10254536-48](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_OpenWrt_Linux_ChromeOS_Android_Macrodroid_Windows.EXE/assets/11254983/60b4e9d1-52d9-4805-882f-16e90f6f60a4) Windows Code & Downloads
[Login Service](https://github.com/aidanmacgregor/BT-Wi-Fi-Autologin-Windows)
</details><br/>


# ![MacroDroid_forum_48](https://user-images.githubusercontent.com/11254983/164982041-be7d0dd7-5c9a-4b24-a5a4-4e8f82a17bc5.png) Macrodroid Autologin Setup (Android 5.0+ & Chrome OS)
<details>
  <summary>Click to expand!</summary><br/>
- Automatic Login From An Android Device, With Alway Online, Charging Only Mode, Track The Number Of Logins & See How To Set Android Up As Wi-Fi Repeater 

## ![48 info](https://user-images.githubusercontent.com/11254983/166980034-691be097-a101-43bb-b44e-646f04299b87.png) Downoad From Play Store Template Availible In The Macrodroid Template Store!

![md1](https://github.com/user-attachments/assets/2d082397-7a5d-4bbc-9823-c677699cda61)
  
## Macrodroid GUI (Edit Settings & Add Account Here)
<details>
  <summary>Click to expand!</summary><br/>
Settings & Information Here
<br/>
<br/>
	  
 ![md2](https://github.com/user-attachments/assets/c3c22154-4c49-40d6-be07-bb7ae72f1b1f)

 <br/>
 </details><br/>
	
## ![10254536-48](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_OpenWrt_Linux_ChromeOS_Android_Macrodroid_Windows.EXE/assets/11254983/60b4e9d1-52d9-4805-882f-16e90f6f60a4) Android Code & Downloads

[Login Service](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_Android_ChromeOS_Macrodroid)

   </details>	
   
   </details>
	</details><br/>


# ![48 terminal-icon copy](https://user-images.githubusercontent.com/11254983/164985283-235c64c3-415e-4cb1-8ce9-8967c23add8e.png) Linux Bash Script
<details>
  <summary>Click to expand!</summary><br/>

- This is a shell script to automate the sign in and always remain connected to EE WiFi (BTWi-fi), Designed To Be Light, Simple & fast
    
## Terminal Running
![WSL2](https://user-images.githubusercontent.com/11254983/173451001-cce58162-7475-4322-9744-fb842ce40209.JPG)

## ![10254536-48](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_OpenWrt_Linux_ChromeOS_Android_Macrodroid_Windows.EXE/assets/11254983/60b4e9d1-52d9-4805-882f-16e90f6f60a4) Linux Code & Download
[Login Service](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_Linux)
    
 </details><br/>


# ![2834255-48](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_OpenWrt_Linux_ChromeOS_Android_Macrodroid_Windows.EXE/assets/11254983/58ee927b-880c-443b-84f2-1942aebbf042) Autologin URLs (HTTP POST & HTTP GET)

<details>
  <summary>Click to expand!</summary><br/>

- The RAW URLs the BT Service Uses To Login


## ![4700146-48](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_OpenWrt_Linux_ChromeOS_Android_Macrodroid_Windows.EXE/assets/11254983/c71ee156-bd31-478b-b793-3ee025fe27e8) HTTP POST
<details>
  <summary>Click to expand!</summary><br/>

- HTTP POST URLs, These Should Work With All Account Types (EE Broadband Unknown)

### ![48 green icon](https://user-images.githubusercontent.com/11254983/164984530-03352fa6-2b61-427a-b92c-911b60fee1bb.png) Secure HTTP POST (With SSL Certificate)

(Normal Login Does NOT Work With Other DNS Settings EG. Google DNS)
- BT Home Broadband:
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://www.btwifi.com:8443/tbbLogon
```
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://ee-wifi.ee.co.uk/tbbLogon
```
  
- EE Wi-Fi (Pay & Go):
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://www.btwifi.com:8443/ante
```
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://ee-wifi.ee.co.uk/ante
```
  
- BT Buisness Broadband:
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://www.btwifi.com:8443/ante?partnerNetwork=btb
```
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://ee-wifi.ee.co.uk/ante?partnerNetwork=btb
```
<br/>

### ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure HTTP POST (Must Allow Any Certificate)

(SSL Error, Works With Other DNS Settings EG. Google DNS)
- BT Home Broadband:
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://192.168.23.21:8443/tbbLogon
```
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://217.39.0.50/tbbLogon
```
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://109.144.192.50/tbbLogon
```
  
- EE Wi-Fi (Pay & Go):
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://192.168.23.21:8443/ante
```
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://217.39.0.50/ante
```
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://109.144.192.50/ante
```
  
- BT Buisness Broadband:
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://www.btwifi.com:8443/ante?partnerNetwork=btb
```
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://217.39.0.50/ante?partnerNetwork=btb
```
```
wget --no-check-certificate -O /dev/null --post-data "username=EMAIL&password=PASSWORD" https://109.144.192.50/ante?partnerNetwork=btb
```

</details>


## ![2555544-48](https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_OpenWrt_Linux_ChromeOS_Android_Macrodroid_Windows.EXE/assets/11254983/8837a11b-f942-4ee2-85c8-d6ed1384f327) HTTP GET (Browser URL bar)
<details>
  <summary>Click to expand!</summary><br/>

- HTTP GET URLs, This Has Been Tested With Home Broadband Accounts, Others Unknown

### ![48 green icon](https://user-images.githubusercontent.com/11254983/164993018-7814c4d6-baee-4602-aae1-a9def39702cd.png) Secure HTTP GET (With SSL Certificate)

(Normal Login, Does NOT Work With Other DNS Settings EG. Google DNS) <br/>
```
- https://www.btwifi.com:8443/wbacOpen?username=EMAIL&password=PASSWORD
```
```
- https://ee-wifi.ee.co.uk/wbacOpen?username=EMAIL&password=PASSWORD
```
### ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure HTTP GET (Must Allow Any Certificate)

(SSL Error in Browser, Works With Other DNS Settings EG. Google DNS) <br/>
```
- https://192.168.23.21:8443/wbacOpen?username=EMAIL&password=PASSWORD
```
```
- https://217.39.0.50/wbacOpen?username=EMAIL&password=PASSWORD
```
```
- https://109.144.192.50/wbacOpen?username=EMAIL&password=PASSWORD
```
 
  </details>
</details><br/>


# ![48 logoffpng](https://user-images.githubusercontent.com/11254983/164995694-4273493d-8bb6-4df4-91b4-ba90b926ce6c.png) Logoff (HTTP GET & Browser URL)
<details>
  <summary>Click to expand!</summary><br/>

- These URLs can be used to manually log out

### ![48 green icon](https://user-images.githubusercontent.com/11254983/164993018-7814c4d6-baee-4602-aae1-a9def39702cd.png) Secure Page

(Normal Logoff, Does NOT Work With Other DNS Settings EG. Google DNS) <br/>
```
- https://www.btwifi.com:8443/accountLogoff/home?confirmed=true
```
```
- https://ee-wifi.ee.co.uk/accountLogoff/home?confirmed=true
```
### ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure
    
(SSL Error in Browser, Works With Other DNS Settings EG. Google DNS) <br/>
```
- https://192.168.23.21:8443/accountLogoff/home?confirmed=true
```
```
- https://217.39.0.50/accountLogoff/home?confirmed=true
```
```
- https://109.144.192.50/accountLogoff/home?confirmed=true
```
</details><br/>


# ![48 Yellow Info](https://user-images.githubusercontent.com/11254983/164985697-861a5a64-e88a-4279-a317-13859676e50e.png) Remove Forced Safesearch & Content Filtering (DNS)
<details>
  <summary>Click to expand!</summary><br/>

## Interface > br-lan (Edit) > DHCP Server > Advanced Settings<br/>
- Change The Setting "DHCP-Options" to
```
6,8.8.8.8,8.8.4.4
```

![LAN DHCP OPTIONS](https://github.com/user-attachments/assets/616c77bf-9cf9-45ed-9fe3-b6cc821f9fff)

## Interface > wwan (Edit) > Advanced Settings
- Use DNS servers advertised by peer
```
(uncheck)
```

- Use custom DNS servers 
```
8.8.8.8
```
```
8.8.4.4
```

![WWAN DNS SETTINGS](https://github.com/user-attachments/assets/a58577a6-2ea3-41cd-bd0f-daa7b4e0304a)

</details><br/>

# Troubleshooting
<details>
  <summary>Click to expand!</summary><br/>
	
- Rebind Protection Needs To Be "OFF" To Load The Login Page Using Browser "btwifi.com:8443"
- To Use Rebind Protection "ON" (OpenWrt Default) Use The Insecure URLs (Cert Warning) "192.168.23.21:8443"

</details><br/>

Tags: BT Wifi login, BT Wifi autologin, btwifi login, BTWi-fi login, BTWi-fi autologin, BTWi-fi Service, BTWi-fi Script, bt wifi login
