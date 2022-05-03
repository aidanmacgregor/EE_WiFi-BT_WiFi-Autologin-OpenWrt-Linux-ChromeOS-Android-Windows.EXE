![NEW LOGO 7 (2)](https://user-images.githubusercontent.com/11254983/164937155-679db244-df83-4aa6-a6f2-9a3fee0dfad7.png)<br/> 
## BTWi-fi Autologin (Shell Script) (Macrodroid) (OpenWrt) (WISPr) (HTTP POST) (HTTP GET)

### Generel Information<br/>

The BT Wi-Fi Service Comes With Several Options To Gain Access To The Network<br/>
- Pay & Go On Demand (1 Hour To 30 Days)
- Pay & Go Subscription (3 OR 12 Months Up To 5 Devices Online, 5 People Could Split 12 Months and pay £3 Each Per Month)
- As A BT Broadband OR BT Mobile Customer (BT Broadband and BT Mobile customers get free, unlimited access to the BT Wi-Fi network)
- FON (No longer in partnership with Fon as of 2020)

Therse Are The URLs I Have Found To Login Without Loading A Webpage OR Typing Credidetials Every Time<br/>
- BT Log You Out Automatically After 4 Hours (And A Few Seconds)
- There Are 4 URLs, (HTTP GET May Only Work With Home Broadband, Others Untested) <br/> 
- If Using Inside A Script Edit The URL To Include Your Account Info<br/> 
- If Using Macrodroid (FREE & RECOMMENDED) Download The Macro & Edit The Variables Drawer To Add Account<br/>
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

### I Advise Using The OpenWrt Script (Macrodroid Config Also Availible For Use On Android) <br/>

Tested In A Home Internet Replacment Setting, using BT Home Hub 5 Flashed With OpenWRT Configured in Client & Access Point Mode <br/>
- This allows one device to sign in every device inside my network <br/>
- this runs well & downtime is almost non existant <br/>
- manually logging out and letting it sign itself in didnt break an active download i had running

### Speeds For Me: (You Will Vary) <br/>

- Ping Approx. 40 MS<br/>
- Download 40 Mbps +<br/>
- Upload Approx 17 Mbps<br/>

# ![youtube-logo-png-46026](https://user-images.githubusercontent.com/11254983/164994883-0a78494e-ae24-4eee-bdbe-a165a7c7d890.png) OpenWRT BT Wi-fi YouTube Guide<br/>
Updated Video Planned Soon!

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/z7pTcrwUQkU/0.jpg)](https://www.youtube.com/watch?v=z7pTcrwUQkU)
<br/>
<br/>
# ![48 terminal-icon copy](https://user-images.githubusercontent.com/11254983/164985283-235c64c3-415e-4cb1-8ce9-8967c23add8e.png) Shell Script Autologin (btwifi.sh) (OpenWrt Compatible)

This is a shell script to automate the sign in and always remain connected to BTWi-fi, Designed To Be Light, Simple & fast

<details>
  <summary>Click to expand!</summary>
  <br/>
 
 ### BTWi-fi Shell Script
[DOWNLOAD SCRIPT](https://github.com/aidanmacgregor/BT_Wi-Fi_Autologin_MACRODROID-WISPr-HTTP_POST-HTTP_GET-OpenWRT/blob/974fd6173b00c1a89c223cf41324b0b09de448da/btwifi.sh) (btwifi.sh)

```
#!/bin/sh

###############- BTWifi Openwrt Autologin Script -###############
##############-- By: Aidan Macgregor (May 2022) --###############
# https://github.com/aidanmacgregor/BT_Wi-Fi_Autologin_MACRODROID-WISPr-HTTP_POST-HTTP_GET-OpenWRT
# (Tested On LEDE 17.01.7, OpenWrt 19.07.10 & 21.02.3)

############### INFO ###############

#### OpenWrt Install These 2 Required Packages: 

# 	libustream-mbedtls
# (libustream-mbedtls Not Needed On OpenWRT 21.X as Wolf SSL included)

#	tmux
# (tmux only fits on 8mb devices, if you have a 4mb device use older buggy method)

#### Copy This File To /sbin/
# 	Use WinSCP To Tranfer File & Give 755 (Execute) permissions

#### Manual Run Using Putty Or Kitty:
# 	btwifi.sh

#### Start On Boot (For Devices With Room For tmux), Add This With LUCI System/Startup (rc.local)
# 	/usr/bin/tmux new -d /bin/sh /sbin/btwifi.sh

#### (For 4mb Devices With NO Room For tmux, MAY BE BUGGY) Start On Boot , Add This With LUCI System/Startup (rc.local)
# 	/bin/sh /sbin/btwifi.sh

#### In The SETTINGS Section Choose Your Account Type & Add Email & Password

#### To stop this script comment out or remove the line in LUCI System - Startup - Local Startup (local.rc) & Reboot
# (OR Delete/Rename the file from /sbin & Reboot)

#### Account Type:
# 	1 = BT Home Broadband
# 	2 = BT Buisness Broadband
# 	3 = BT Wi-Fi Account

###############- SETTINGS -###############

ACCOUNTTYPE=1
USERNAME=
PASSWORD=

###############- OPTIONAL -###############

PINGDNS=8.8.8.8
PING2URL=www.google.com

##########################################
#####---- DO NOT EDIT BELOW HERE ----#####
##########################################

# Ensure PATH is sensible
export PATH=/usr/sbin:/usr/bin:/sbin:/bin:$PATH

# Manual Run Confirm (so user knows something happened)
echo "btwifi.sh is RUNNING! Press [ctrl] & [c] to stop or test by logging out"

while true
do
	if ! ping -c 1 -W 1 $PINGDNS 2>/dev/null >/dev/null			 
	then 
		logger -t BTWi-fi "Ping 1 DNS Fail"
		if ! ping -c 1 -W 1 $PING2URL 2>/dev/null >/dev/null				 
		then
			logger -t BTWi-fi "Offline, Attempting Login, Ping 2 DNS Fail"
			if [ "$ACCOUNTTYPE" = "1" ]
			then
				logger -t BTWi-fi "Offline, attempting login URL 1 (BT Home Broadband Account)"
				wget -T 2 -O /dev/null --post-data "username=$USERNAME&password=$PASSWORD" 'https://192.168.23.21:8443/tbbLogon'
			elif [ "$ACCOUNTTYPE" = "2" ]
			then
				logger -t BTWi-fi "Offline, attempting login URL2 (BT Buisness Broadband Account)"																	 
				wget -T 2 -O /dev/null --post-data "username=$USERNAME&password=$PASSWORD" 'https://192.168.23.21:8443/ante?partnerNetwork=btb'
			elif [ "$ACCOUNTTYPE" = "3" ]
			then
				logger -t BTWi-fi "Offline, attempting login URL3 (BT Wi-fi Account)"														 
				wget -T 2 -O /dev/null --post-data "username=$USERNAME&password=$PASSWORD" 'https://192.168.23.21:8443/ante'
			fi
		fi
	fi
sleep 1
done
```

 </details>

 <br/>

# ![MacroDroid_forum_48](https://user-images.githubusercontent.com/11254983/164982041-be7d0dd7-5c9a-4b24-a5a4-4e8f82a17bc5.png) Macrodroid Autologin Setup (Android 5.0+)<br/>
Automatic Login From An Android Device, With Alway Online, Charging Only Mode, Track The Number Of Logins & More

<details>
  <summary>Click to expand!</summary>

### Template Availible In The Macrodroid Template Store!
Download From Macrodroid Templates!

![Screenshot_20220502-194637_MacroDroid](https://user-images.githubusercontent.com/11254983/166310061-5c8bb11f-a9ec-429a-aa6c-8796fb5f5a72.jpg)
 <br/>

  
### Variables Tab (Edit Settings & Add Account Here)
<details>
  <summary>Click to expand!</summary
<br/>
Settings & Inmformation Here
	  
![3  Screenshot_20220415-230400_MacroDroid_copy_640x1422](https://user-images.githubusercontent.com/11254983/163649231-921d6e70-86e0-46d0-8064-635d2b450ab8.png) <br/>

 </details>

### Main Macro
<details>
  <summary>Click to expand!</summary>
Macro Structure
	
![Screenshot_20220502-190512_MacroDroid](https://user-images.githubusercontent.com/11254983/166310114-93b22ec4-a938-4d44-bcac-19ca1ae5f7ff.jpg)
  
<br/>

   </details>
   </details> 
 <br/>

 # ![2528830](https://user-images.githubusercontent.com/11254983/164993973-1b534096-84a8-4785-bf39-ea177eea4274.png) OpenWrt Setup (17.x to 21.x Tested)<br/>
Set Up OpenWrt With BTWi-fi & the autologin script!
 
 <details>
  <summary>Click to expand!</summary>
  
  <br/>
  
### System - Administration (Set Password)<br/>
  Set Up Your Router Admin Password<br/>
<br/>
  ![1 - System - Administration (Set Password)](https://user-images.githubusercontent.com/11254983/166240566-d8d4fc01-ef00-479c-8592-e3845ebe96a6.JPG)
  
 <br/>
  
### Network - Wireless (delete WiFi)<br/>
Delete The Default Wireless Networks<br/>
<br/>
  ![2 - Network - Wireless (delete WiFi)](https://user-images.githubusercontent.com/11254983/166240817-9a8fb916-d3fd-4791-b4cb-dd2ae2649272.JPG)

  <br/>
  
### Network - Wireless (Connect BT WiFi)<br/>
Choose Your Wifi Radio & Choose Scan (2.4Ghz BGN Reccomended)<br/>
<br/>
![3 - Network - Wireless (Connect BT WiFi)](https://user-images.githubusercontent.com/11254983/166240933-f0e76120-650b-4d0f-9fd7-6407fe92e5d2.JPG)

  <br/>
  
### Network - Wireless (inactivity & Low ACK)<br/>
Set These Settings Like So In Advanced Tab<br/>
<br/>
  ![4  - Network - Wireless (inactivity   Low ACK)](https://user-images.githubusercontent.com/11254983/166241142-6537767b-f52a-49e4-959b-6837102b9b61.JPG)
  
  <br/>
  
### Network - Wireless (Create An Access Point)<br/>
Create Your Interal Wi-Fi Network (Dont Forget To Add Password)<br/>
<br/>
  ![4 1 - Network - Wireless (Create An Access Point)](https://user-images.githubusercontent.com/11254983/166241248-638a4873-0d93-4a99-bda9-f2a0ff2080ae.JPG)
  
  <br/>
  
### Network - Interface (delete wan & wan6)<br/>
Delete The Unused WAN Interfaces<br/>
<br/>
  ![5 - Network - Interface (delete wan   wan6)](https://user-images.githubusercontent.com/11254983/166241334-f505c56f-23db-4e25-9941-55cffcd3bc47.JPG)
  
  <br/>
  
### Network - Interface - LAN - Edit (Use custom DNS servers)<br/>
Add Custom DNS Servers<br/>
<br/>
  ![6 - Network - Interface - LAN - Edit (Use custom DNS servers)](https://user-images.githubusercontent.com/11254983/166241402-27dc1998-64c3-41da-a3c0-390827530e47.JPG)
  
  <br/>
  
### Network - Interface - LAN - Edit - DHCP Server - Advanced Settings- (DHCP-options)<br/>
Add Custom DNS Servers<br/>
<br/>
  ![7 - Network - Interface - LAN - Edit - DHCP Server - Advanced Settings- (DHCP-options)](https://user-images.githubusercontent.com/11254983/166241561-665686c0-3435-4bc8-9f2e-2a3fe3b5cfcd.JPG)
  
  <br/>
  
### Network - DHCP & DNS (disable rebind protection)<br/>
(Needed To Load The Login Page & Download The Packages)<br/>
	 <br/>
  ![8 - Network - DHCP   DNS (disable rebind protection)](https://user-images.githubusercontent.com/11254983/166241698-471e5593-043a-4ffe-9f3a-7e6ad959831b.JPG)
  
  <br/>
  
### Login Manually<br/>
Load a webpage & Log in Normally<br/>
	 <br/>
  ![9 - Login Manually](https://user-images.githubusercontent.com/11254983/166241894-2aa59758-a5bb-4863-a13c-a2874aca56d1.JPG)
  
  <br/>
  
### System - Software (install libustream-mbedtls)<br/>
Install The Following Package<br/>
	 <br/>
  ![10 - System - Software](https://user-images.githubusercontent.com/11254983/166242079-36c6912e-d3cc-489d-a03e-3652604631aa.JPG)
  
  <br/>
  
### System - Software (install tmux)<br/>
Install The Following Package<br/>
	 <br/>
  ![11 - System - Software](https://user-images.githubusercontent.com/11254983/166242150-36d4c4e7-f1b6-45c6-95f0-15fc8e9e0343.JPG)
  
  <br/>
  
### Add Account Details to the Script<br/>
You Need To Add Your Account Details & Choose Account Type<br/>
	 <br/>
  ![12 - Add Account Details to SH](https://user-images.githubusercontent.com/11254983/166242263-c55bd6ba-1414-4332-bc85-b356d2bf17aa.JPG)
  
  <br/>
  
### Copy Script To /sbin (Use WinSCP to transfer)<br/>
Use WinSPC To Transfer Files To The Router<br/>
	 <br/>
  ![13 - Copy sh To sbin](https://user-images.githubusercontent.com/11254983/166242422-9e4e91bd-16a4-4500-a51f-5ee796ddee61.JPG)
  
  <br/>
  
### Set Permissions (755)<br/>
Use WinSCP, File Properties<br/>
	 <br/>
  ![14 - Set Permissions (755)](https://user-images.githubusercontent.com/11254983/166242532-b2aefdd3-215e-47f6-87db-b0255253ce72.JPG)
  
  <br/>
  
### System - Startup - Local startup<br/>
This Makes The Script Run When The Router Boots Up<br/>
	 <br/>
  ![15 - System - Startup - Local startup](https://user-images.githubusercontent.com/11254983/166242600-ff456463-fded-4b3c-8421-d6828284c164.JPG)
  
  <br/>
  
### Network - DHCP & DNS (enable rebind protection)<br/>
To Help Remove Google Safe Search<br/>
	 <br/>
  ![16 - Network - DHCP   DNS (enable rebind protection)](https://user-images.githubusercontent.com/11254983/166242694-f7b918ad-f751-4473-b396-63a526b30d0f.JPG)
  
  <br/>
  
### Manual Run The Script (For Tetsing)<br/>
  Run The Script & Then Log Out, And Watch A Ping Test To See How Quickly Connection Is Restored To Stop Press [CTRL] & [C]<br/>
	 <br/>
  ![17 - Manual Run](https://user-images.githubusercontent.com/11254983/166243577-bc600601-d463-4ee7-942f-af60fc8c8552.JPG)

  <br/>
  
  
</details>

 <br/>

# ![48 http copy 2](https://user-images.githubusercontent.com/11254983/164985125-01ad4452-6b6a-42e7-94d5-a04020e1ded5.png) Autologin URLs (HTTP POST, HTTP GET & Browser URL) <br/>
The URLs Used By BT For Authentication

<details>
  <summary>Click to expand!</summary>
  
## HTTP POST
HTTP POST URLs, These Should Work With All Account Types
<details>
  <summary>Click to expand!</summary>

### ![48 green icon](https://user-images.githubusercontent.com/11254983/164984530-03352fa6-2b61-427a-b92c-911b60fee1bb.png) Secure HTTP POST (With SSL Certificate) <br/>
(Normal Login, Does NOT Work With Other DNS Settings EG. Google DNS)<br/>

- BT Home Broadband:<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/tbbLogon<br/>
<br/>
  
- BT Wi-Fi (Pay & Go):<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/ante<br/>
<br/>
  
- BT Buisness Broadband:<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/ante?partnerNetwork=btb <br/>

### ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure HTTP POST (Must Allow Any Certificate) <br/>
(SSL Error, Works With Other DNS Settings EG. Google DNS)
  
- BT Home Broadband:<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://192.168.23.21:8443/tbbLogon <br/>
<br/>
  
- BT Wi-Fi (Pay & Go):<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://192.168.23.21:8443/ante <br/>
<br/>
  
- BT Buisness Broadband:<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://192.168.23.21:8443/ante?partnerNetwork=btb <br/>

</details>

<br/>

## HTTP GET (Browser URL bar)
HTTP GET URLs, This Has Been Tested With Home Broadband Accounts, Others Unknown
<details>
  <summary>Click to expand!</summary>

### ![48 green icon](https://user-images.githubusercontent.com/11254983/164993018-7814c4d6-baee-4602-aae1-a9def39702cd.png) Secure HTTP GET (With SSL Certificate)<br/>
(Normal Login, Does NOT Work With Other DNS Settings EG. Google DNS) <br/>

https://www.btwifi.com:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD

### ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure HTTP GET (Must Allow Any Certificate)<br/>
(SSL Error in Browser, Works With Other DNS Settings EG. Google DNS) <br/>

https://192.168.23.21:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD
 
  </details>
</details>

 <br/>

# ![48 logoffpng](https://user-images.githubusercontent.com/11254983/164995694-4273493d-8bb6-4df4-91b4-ba90b926ce6c.png) Logoff (HTTP GET & Browser URL) <br/>
These URLs can be used to manually log out

<details>
  <summary>Click to expand!</summary>

### ![48 green icon](https://user-images.githubusercontent.com/11254983/164993018-7814c4d6-baee-4602-aae1-a9def39702cd.png) Secure Page <br/>
(Normal Logoff, Does NOT Work With Other DNS Settings EG. Google DNS) <br/>

https://www.btwifi.com:8443/accountLogoff/home?confirmed=true

### ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure <br/>
(SSL Error in Browser, Work With Other DNS Settings EG. Google DNS) <br/>

https://192.168.23.21:8443/accountLogoff/home?confirmed=true

</details>

 <br/>
  
 ## ![48 Yellow Info](https://user-images.githubusercontent.com/11254983/164985697-861a5a64-e88a-4279-a317-13859676e50e.png) Rebind Protection & Alternatave DNS (Safesearch Remove)
 Useful Info (OpenWrt Guide Already Included These Steps)
 
 <details>
  <summary>Click to expand!</summary>

<br/>

- Rebind Protection Needs To Be "OFF" To Load The Login Page Using Browser "btwifi.com:8443"
- To Use Rebind Protection "ON" (OpenWrt Default) Use The Insecure URLs (Cert Warning) "192.168.23.21:8443"
- "Use Custom DNS Servers" Affects Android (Wi-Fi) Automatically Geting Google DNS Via DHCP
- "DHCP-Options" Affects Windows (Ethernet) Automatically Geting Google DNS Via DHCP
  
<br/>
Im Using Google DNS on the internal network To Remove Forced Google Safe Search<br/>
<br/>

- Chose Network > Interfaces From The Menu
- EDIT the LAN Interface<br/>
 
 ![lan](https://user-images.githubusercontent.com/11254983/164999146-b1a85ec5-9752-4e56-ab6c-ceb4c969327b.JPG)

- Find "Use custom DNS servers" Add<br/>
8.8.8.8 & 8.8.4.4<br/>
  
![DHCP GEN](https://user-images.githubusercontent.com/11254983/164999416-b8b8ca43-272d-47a3-a106-2e3165c0fdad.JPG)

- Open DHCP Server Tab, Advanced
  
![DHCP ADV BAR](https://user-images.githubusercontent.com/11254983/164999274-0c193757-6404-47ff-8b74-9e555c0dc326.JPG)
  
 - Under DHCP-Options ADD<br/>
6,8.8.8.8,8.8.4.4<br/>
 
 ![DHCP ADV](https://user-images.githubusercontent.com/11254983/164999225-05066ac7-f35a-4ea2-9b5f-5c237458e56a.JPG)

</details>

 <br/>
