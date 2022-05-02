![NEW LOGO 7 (2)](https://user-images.githubusercontent.com/11254983/164937155-679db244-df83-4aa6-a6f2-9a3fee0dfad7.png)<br/> 
## BT Wi-Fi Autologin MACRODROID - WISPr - HTTP POST - HTTP GET - Android - OpenWrt

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

### I Advise Using An Android Device & Macrodroid, Set up As Follows <br/>

Tested In A Home Internet Replacment Setting, using BT Home Hub 5 Flashed With OpenWRT Configured in Client & Access Point Mode <br/>
- This allows one device to sign in every device inside my network <br/>
- this runs well & downtime is almost non existant <br/>
- manually logging out and letting it sign itself in didnt break an active download i had running

### Speeds For Me: (You Will Vary) <br/>
- Ping Approx. 40 MS<br/>
- Download 40 Mbps +<br/>
- Upload Approx 17 Mbps<br/>

# ![youtube-logo-png-46026](https://user-images.githubusercontent.com/11254983/164994883-0a78494e-ae24-4eee-bdbe-a165a7c7d890.png) OpenWRT BT Wi-fi YouTube Guide<br/>

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/z7pTcrwUQkU/0.jpg)](https://www.youtube.com/watch?v=z7pTcrwUQkU)
<br/>
# ![48 terminal-icon copy](https://user-images.githubusercontent.com/11254983/164985283-235c64c3-415e-4cb1-8ce9-8967c23add8e.png) Autologin (HTTP POST & Wget)

<details>
  <summary>Click to expand!</summary>

## ![48 green icon](https://user-images.githubusercontent.com/11254983/164984530-03352fa6-2b61-427a-b92c-911b60fee1bb.png) Secure HTTP POST (With SSL Certificate) <br/>
(Normal Login, Does NOT Work With Other DNS Settings EG. Google DNS)<br/>

- BT Home Broadband:<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/tbbLogon<br/>
<br/>
  
- BT Wi-Fi (Pay & Go):<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/ante<br/>
<br/>
  
- BT Buisness Broadband:<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/ante?partnerNetwork=btb <br/>

## ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure HTTP POST (Must Allow Any Certificate) <br/>
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
 <br/>

# ![48 http copy 2](https://user-images.githubusercontent.com/11254983/164985125-01ad4452-6b6a-42e7-94d5-a04020e1ded5.png) Autologin (HTTP GET & Browser URL) <br/>

<details>
  <summary>Click to expand!</summary>

## ![48 green icon](https://user-images.githubusercontent.com/11254983/164993018-7814c4d6-baee-4602-aae1-a9def39702cd.png) Secure HTTP GET (With SSL Certificate)<br/>
(Normal Login, Does NOT Work With Other DNS Settings EG. Google DNS) <br/>

https://www.btwifi.com:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD

## ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure HTTP GET (Must Allow Any Certificate)<br/>
(SSL Error in Browser, Works With Other DNS Settings EG. Google DNS) <br/>

https://192.168.23.21:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD
 
</details>

 <br/>
 <br/>

# ![48 logoffpng](https://user-images.githubusercontent.com/11254983/164995694-4273493d-8bb6-4df4-91b4-ba90b926ce6c.png) Logoff (HTTP GET & Browser URL) <br/>

<details>
  <summary>Click to expand!</summary>

## ![48 green icon](https://user-images.githubusercontent.com/11254983/164993018-7814c4d6-baee-4602-aae1-a9def39702cd.png) Secure Page <br/>
(Normal Logoff, Does NOT Work With Other DNS Settings EG. Google DNS) <br/>

https://www.btwifi.com:8443/accountLogoff/home?confirmed=true

## ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure <br/>
(SSL Error in Browser, Work With Other DNS Settings EG. Google DNS) <br/>

https://192.168.23.21:8443/accountLogoff/home?confirmed=true

</details>

 <br/>
 <br/>

# ![MacroDroid_forum_48](https://user-images.githubusercontent.com/11254983/164982041-be7d0dd7-5c9a-4b24-a5a4-4e8f82a17bc5.png) Macrodroid Autologin Setup<br/>

<details>
  <summary>Click to expand!</summary>

## Template Availible In The Macrodroid Template Store!
<br/>

![1 Screenshot_20220412-123013_MacroDroidStore](https://user-images.githubusercontent.com/11254983/163649134-b3bc7d86-01b2-42ee-a469-ac74f1c2c86b.jpg) <br/>

## Variables Tab (Ajust Settings & Add Account Here)
<br/>

![3  Screenshot_20220415-230400_MacroDroid_copy_640x1422](https://user-images.githubusercontent.com/11254983/163649231-921d6e70-86e0-46d0-8064-635d2b450ab8.png) <br/>

## Main Macro

<details>
  <summary>Click to expand!</summary>
  
![2  Screenshot_20220415-230329_MacroDroid_copy_640x6225](https://user-images.githubusercontent.com/11254983/163649196-6d36793d-7038-4684-b65e-305aaa9dc821.jpg)
<br/>

   </details>
   
  ## HTTP POST Request<br/>
   
  <details>
   <summary>Click to expand!</summary>
   
![3 Screenshot_20220412-123013_MacroDroid](https://user-images.githubusercontent.com/11254983/163034409-5751704c-937f-4461-9342-fe42f943fb53.jpg) <br/>
<br/>

  </details>

## HTTP POST Body

<details>
  <summary>Click to expand!</summary>

![4  Screenshot_20220412-123022_MacroDroid_copy_648x1440](https://user-images.githubusercontent.com/11254983/163034412-4e559a75-585d-4368-a9d5-3ab1d91de674.png) <br/>

  </details>
  
   </details>
   
 <br/>
 <br/>
   
   
  
 # ![2528830](https://user-images.githubusercontent.com/11254983/164993973-1b534096-84a8-4785-bf39-ea177eea4274.png) OpenWrt Setup <br/>
 
 <details>
  <summary>Click to expand!</summary>
  
  <br/>
  
## System - Administration (Set Password)
  
  ![1 - System - Administration (Set Password)](https://user-images.githubusercontent.com/11254983/166240566-d8d4fc01-ef00-479c-8592-e3845ebe96a6.JPG)
  
 <br/>
  
## Network - Wireless (delete WiFi)
  ![2 - Network - Wireless (delete WiFi)](https://user-images.githubusercontent.com/11254983/166240817-9a8fb916-d3fd-4791-b4cb-dd2ae2649272.JPG)

  <br/>
  
## Network - Wireless (Connect BT WiFi)
![3 - Network - Wireless (Connect BT WiFi)](https://user-images.githubusercontent.com/11254983/166240933-f0e76120-650b-4d0f-9fd7-6407fe92e5d2.JPG)

  <br/>
  
## Network - Wireless (inactivity & Low ACK)
  ![4  - Network - Wireless (inactivity   Low ACK)](https://user-images.githubusercontent.com/11254983/166241142-6537767b-f52a-49e4-959b-6837102b9b61.JPG)
  
  <br/>
  
## Network - Wireless (Create An Access Point)
  ![4 1 - Network - Wireless (Create An Access Point)](https://user-images.githubusercontent.com/11254983/166241248-638a4873-0d93-4a99-bda9-f2a0ff2080ae.JPG)
  
  <br/>
  
## Network - Interface (delete wan & wan6)
  ![5 - Network - Interface (delete wan   wan6)](https://user-images.githubusercontent.com/11254983/166241334-f505c56f-23db-4e25-9941-55cffcd3bc47.JPG)
  
  <br/>
  
## Network - Interface - LAN - Edit (Use custom DNS servers)
![6 - Network - Interface - LAN - Edit (Use custom DNS servers)](https://user-images.githubusercontent.com/11254983/166241402-27dc1998-64c3-41da-a3c0-390827530e47.JPG)
  
  <br/>
  
## Network - Interface - LAN - Edit - DHCP Server - Advanced Settings- (DHCP-options)
  ![7 - Network - Interface - LAN - Edit - DHCP Server - Advanced Settings- (DHCP-options)](https://user-images.githubusercontent.com/11254983/166241561-665686c0-3435-4bc8-9f2e-2a3fe3b5cfcd.JPG)
  
  <br/>
  
## Network - DHCP & DNS (disable rebind protection)
  ![8 - Network - DHCP   DNS (disable rebind protection)](https://user-images.githubusercontent.com/11254983/166241698-471e5593-043a-4ffe-9f3a-7e6ad959831b.JPG)
  
  <br/>
  
## Login Manually
  ![9 - Login Manually](https://user-images.githubusercontent.com/11254983/166241894-2aa59758-a5bb-4863-a13c-a2874aca56d1.JPG)
  
  <br/>
  
## System - Software (install libustream-mbedtls)
  ![10 - System - Software](https://user-images.githubusercontent.com/11254983/166242079-36c6912e-d3cc-489d-a03e-3652604631aa.JPG)
  
  <br/>
  
## System - Software (install tmux)
  ![11 - System - Software](https://user-images.githubusercontent.com/11254983/166242150-36d4c4e7-f1b6-45c6-95f0-15fc8e9e0343.JPG)
  
  <br/>
  
## Add Account Details to the Script
  ![12 - Add Account Details to SH](https://user-images.githubusercontent.com/11254983/166242263-c55bd6ba-1414-4332-bc85-b356d2bf17aa.JPG)
  
  <br/>
  
## Copy Script To /sbin (Use WinSCP to transfer)
  ![13 - Copy sh To sbin](https://user-images.githubusercontent.com/11254983/166242422-9e4e91bd-16a4-4500-a51f-5ee796ddee61.JPG)
  
  <br/>
  
## Set Permissions (755)
  ![14 - Set Permissions (755)](https://user-images.githubusercontent.com/11254983/166242532-b2aefdd3-215e-47f6-87db-b0255253ce72.JPG)
  
  <br/>
  
## System - Startup - Local startup
  ![15 - System - Startup - Local startup](https://user-images.githubusercontent.com/11254983/166242600-ff456463-fded-4b3c-8421-d6828284c164.JPG)
  
  <br/>
  
## Network - DHCP & DNS (enable rebind protection)
  ![16 - Network - DHCP   DNS (enable rebind protection)](https://user-images.githubusercontent.com/11254983/166242694-f7b918ad-f751-4473-b396-63a526b30d0f.JPG)
  
  <br/>
  
  ## Manual Run The Script (For Tetsing)
  
  ![17 - Manual Run](https://user-images.githubusercontent.com/11254983/166243577-bc600601-d463-4ee7-942f-af60fc8c8552.JPG)

  <br/>
  
  
</details>

 <br/>
 <br/>
  
 ## ![48 Yellow Info](https://user-images.githubusercontent.com/11254983/164985697-861a5a64-e88a-4279-a317-13859676e50e.png) Rebind Protection & Alternatave DNS (Safesearch Remove)
 
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
 <br/>
