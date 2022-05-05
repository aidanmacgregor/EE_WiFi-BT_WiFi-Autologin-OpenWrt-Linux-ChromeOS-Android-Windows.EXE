![NEW LOGO 7 (2)](https://user-images.githubusercontent.com/11254983/164937155-679db244-df83-4aa6-a6f2-9a3fee0dfad7.png)<br/> 
## BTWi-fi Autologin (OpenWrt) (Script.sh) (Macrodroid) (WISPr) (HTTP-POST) (HTTP-GET)

### Generel Information<br/>
![48 info](https://user-images.githubusercontent.com/11254983/166980034-691be097-a101-43bb-b44e-646f04299b87.png) OpenWrt Script Has Now Been Replaced With A Service (Edit The File Using Notepad++)
</br>

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

### I Advise Using The OpenWrt Service (Macrodroid Config Also Availible For Use On Android) <br/>

Tested In A Home Internet Replacment Setting, using BT Home Hub 5 Flashed With OpenWRT Configured in Client & Access Point Mode <br/>
- This allows one device to sign in every device inside my network <br/>
- this runs well & downtime is almost non existant <br/>
- manually logging out and letting it sign itself in didnt break an active download i had running

### Speeds For Me: (You Will Vary) <br/>

- Ping Approx. 40 MS<br/>
- Download 40 Mbps +<br/>
- Upload Approx 17 Mbps<br/>

# ![youtube-logo-png-46026](https://user-images.githubusercontent.com/11254983/164994883-0a78494e-ae24-4eee-bdbe-a165a7c7d890.png) OpenWRT BTWi-fi YouTube Guide<br/>
Updated Video Planned Soon!

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/z7pTcrwUQkU/0.jpg)](https://www.youtube.com/watch?v=z7pTcrwUQkU)
<br/>
<br/>


 # ![2528830](https://user-images.githubusercontent.com/11254983/164993973-1b534096-84a8-4785-bf39-ea177eea4274.png) OpenWrt Autologin Service & Setup (17.x to 21.x Tested)<br/>
Set Up OpenWrt With BTWi-fi & the autologin Service
 
  <details>
  <summary>Click to expand!</summary>
 
### OpenWrt Autologin Service
```
#!/bin/sh /etc/rc.common

##############- BTWi-fi Openwrt Autologin Service -##############
##############-- By: Aidan Macgregor (May 2022) --###############
# https://github.com/aidanmacgregor/BT_Wi-Fi_Autologin_MACRODROID-WISPr-HTTP_POST-HTTP_GET-OpenWRT
# (Tested On LEDE 17.01.7, OpenWrt 19.07.10 & 21.02.3)

############### INFO ###############

#### OpenWrt Install This Required Package:
# 	libustream-mbedtls
# (libustream-mbedtls Not Needed On OpenWRT 21.X as Wolf SSL included)

#### Copy This File To /etc/init.d/
# 	Use WinSCP To Tranfer File & Give 755 (Execute) permissions
# (If No Permissions You Get Error "Failed to execute "/etc/init.d/BTWi-fi_Autologin_Service start")

#### Manual Run & Stop (Stopping Also Signs The Account Out)
# 	Click Start/Stop on the service in LUCI (System > Startup)

#### Automatically Start On Boot
#	Enable the service in LUCI (System > Startup)

#### In The SETTINGS Section Choose Your Account Type & Add Email & Password
# (Reccomend Open This File With Notepad++)

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
LOGPATH=/BTWi-fi_Autologin_Service_LOG.txt

##########################################
#####---- DO NOT EDIT BELOW HERE ----#####
##########################################

START=99
STOP=1
PIDFILE=/var/run/btwifi.pid

btwifi_loop(){
while true
do
if [[ "92" -ge "92" ]]; then
	echo "$(tail -92 $LOGPATH)" > $LOGPATH
fi
	if ! ping -c 1 -W 1 $PINGDNS 2>/dev/null >/dev/null	 
	then
		logger -t BTWi-fi_Autologin_Service "Ping 1 DNS Fail"
		echo "$(date) Ping 1 DNS Fail" >> $LOGPATH
		if ! ping -c 1 -W 1 $PING2URL 2>/dev/null >/dev/null			 
		then
			logger -t BTWi-fi_Autologin_Service "Ping 2 URL Fail"
			echo "$(date) Ping 1 DNS Fail" >> $LOGPATH
			if [ "$ACCOUNTTYPE" = "1" ]
			then
				logger -t BTWi-fi_Autologin_Service "$(date) Offline, attempting login URL 1 (BT Home Broadband Account)"
				echo "$(date) Offline, attempting login URL 1 (BT Home Broadband Account)" >> $LOGPATH
				wget -T 2 -O /dev/null --post-data "username=$USERNAME&password=$PASSWORD" 'https://192.168.23.21:8443/tbbLogon'
			elif [ "$ACCOUNTTYPE" = "2" ]
			then
				logger -t BTWi-fi_Autologin_Service "$(date) Offline, attempting login URL 2 (BT Buisness Broadband Account)"
				echo "$(date) Offline, attempting login URL 2 (BT Buisness Broadband Account)" >> $LOGPATH
				wget -T 2 -O /dev/null --post-data "username=$USERNAME&password=$PASSWORD" 'https://192.168.23.21:8443/ante?partnerNetwork=btb'
			elif [ "$ACCOUNTTYPE" = "3" ]
			then
				logger -t BTWi-fi_Autologin_Service "$(date) Offline, attempting login URL 3 (BT Wi-Fi Account)"
				echo "$(date) Offline, attempting login URL 3 (BT Wi-Fi Account)" >> $LOGPATH
				wget -T 2 -O /dev/null --post-data "username=$USERNAME&password=$PASSWORD" 'https://192.168.23.21:8443/ante'
			fi
		fi
	fi
sleep 1
done
}

start() {
	logger -t BTWi-fi_Autologin_Service "$(date) BTWi-fi Autologin Service Started"
	echo "$(date) BTWi-fi Autologin Service Started" >> $LOGPATH
	[ -f $PIDFILE ] && [ ! -d /proc/`cat $PIDFILE` ] && rm $PIDFILE
	[ -f $PIDFILE ] && exit 1
	btwifi_loop &
	echo -n $! > $PIDFILE
}

stop() {
	kill `cat $PIDFILE`
	rm $PIDFILE
	wget -T 2 -O /dev/null 'https://192.168.23.21:8443/accountLogoff/home?confirmed=true'
	logger -t BTWi-fi_Autologin_Service "$(date) BTWi-fi Autologin Service Stopped Manually (Or Reboot)"
	echo "$(date) BTWi-fi Autologin Service Stopped Manually (Or Reboot)" >> $LOGPATH
}
```
	
### OpenWrt Config

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
  
### Add Account Details to the Script<br/>
You Need To Add Your Account Details & Choose Account Type<br/>
	 <br/>
  ![12 - Add Account Details to SH](https://user-images.githubusercontent.com/11254983/166242263-c55bd6ba-1414-4332-bc85-b356d2bf17aa.JPG)
  
  <br/>
  
### Copy Service File To /etc/init.d (Use WinSCP to transfer)<br/>
Use WinSPC To Transfer Files To The Router<br/>
	 <br/>
![13 - Copy sh To sbin](https://user-images.githubusercontent.com/11254983/167023631-866f98ca-c8d1-4de3-9588-501f490112ee.png)

  <br/> 

### Set Permissions (755)<br/>
Use WinSCP, File Properties<br/>
	 <br/>
  ![14 - Set Permissions (755)](https://user-images.githubusercontent.com/11254983/167023685-e716341a-fc03-4faf-8417-43e2d13e9d0b.png)
  
  <br/>
  
### System - Startup <br/>
This Makes The Script Run When The Router Boots Up<br/>
	 <br/>
  ![15 - System - Startup - Enable on boot](https://user-images.githubusercontent.com/11254983/167023774-c3b781d3-0018-4023-9691-e4b780e5f583.png)

  <br/>
  
### Network - DHCP & DNS (enable rebind protection)<br/>
To Help Remove Google Safe Search<br/>
	 <br/>
  ![16 - Network - DHCP   DNS (enable rebind protection)](https://user-images.githubusercontent.com/11254983/166242694-f7b918ad-f751-4473-b396-63a526b30d0f.JPG)
  
  <br/>

  
</details>
</details>

 <br/>
 
 # ![MacroDroid_forum_48](https://user-images.githubusercontent.com/11254983/164982041-be7d0dd7-5c9a-4b24-a5a4-4e8f82a17bc5.png) Macrodroid Autologin Setup (Android 5.0+)<br/>
Automatic Login From An Android Device, With Alway Online, Charging Only Mode, Track The Number Of Logins & More

<details>
  <summary>Click to expand!</summary>

### Template Availible In The Macrodroid Template Store!
<br/>
Download From Macrodroid Templates!<br/>
<br/>

![Screenshot_20220502-194637_MacroDroid](https://user-images.githubusercontent.com/11254983/166310061-5c8bb11f-a9ec-429a-aa6c-8796fb5f5a72.jpg)
 <br/>

  
### Variables Tab (Edit Settings & Add Account Here)
<details>
  <summary>Click to expand!</summary>

<br/>
Settings & Information Here<br/>
<br/>
	  
![3  Screenshot_20220415-230400_MacroDroid_copy_640x1422](https://user-images.githubusercontent.com/11254983/163649231-921d6e70-86e0-46d0-8064-635d2b450ab8.png) <br/>

 </details>

### Main Macro
<details>
  <summary>Click to expand!</summary>
<br/>
Macro Structure<br/>
<br/>
	
![Screenshot_20220502-190512_MacroDroid](https://user-images.githubusercontent.com/11254983/166310114-93b22ec4-a938-4d44-bcac-19ca1ae5f7ff.jpg)
  
<br/>

   </details>
   </details> 
 <br/>

# ![48 terminal-icon copy](https://user-images.githubusercontent.com/11254983/164985283-235c64c3-415e-4cb1-8ce9-8967c23add8e.png) Shell Script Autologin Linux (Bash & Openwrt Shell) (btwifi.sh)

This is a shell script to automate the sign in and always remain connected to BTWi-fi, Designed To Be Light, Simple & fast

<details>
  <summary>Click to expand!</summary>
  <br/>
 
 ### BTWi-fi Shell Script
[DOWNLOAD SCRIPT](https://github.com/aidanmacgregor/BT_Wi-Fi_Autologin_MACRODROID-WISPr-HTTP_POST-HTTP_GET-OpenWRT/blob/974fd6173b00c1a89c223cf41324b0b09de448da/btwifi.sh) (btwifi.sh)


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
