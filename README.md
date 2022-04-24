![NEW LOGO 7 (2)](https://user-images.githubusercontent.com/11254983/164937155-679db244-df83-4aa6-a6f2-9a3fee0dfad7.png)<br/> 
## BT Wi-Fi Autologin MACRODROID - WISPr - HTTP POST - HTTP GET - Android - OpenWrt

### Generel Information<br/>

The BT Wi-Fi Service Comes With Several Options To Gain Access To The Network
- Pay & Go On Demand (1 Hour To 30 Days)
- Pay & Go Subscription (3 OR 12 Months Up To 5 Devices Online, 5 People Could Split 12 Months and pay £3 Each Per Month)
- As A BT Broadband OR BT Mobile Customer (BT Broadband and BT Mobile customers get free, unlimited access to the BT Wi-Fi network)

Therse Ate The URLs I Have Found To Login Without Loading A Webpage, Typing Credidetials Every Time<br/>
There Are 4 URLs, (HTTP GET May Only Work With Home Broadband, Others Untested) <br/> 
If Using Inside A Script Edit The URL To Include Your Account Info<br/> 
If Using Macrodroid (FREE & RECOMMENDED) Download The Macro & Edit The Variaables Drawer To Add Account

### I Advise Using An Android Device & Macrodroid, Set up As Follows <br/>

Tested In A Home Internet Replacment Setting, using BT Home Hub 5 Flashed With OpenWRT Configured in Client & Access Point Mode <br/>
This allows one device to sign in every device inside my network <br/>
this runs well & downtime is almost non existant <br/>
manually logging out and letting it sign itself in didnt break an active download i had running

### Speeds For Me: (You Will Vary) <br/>
- Ping Approx. 40 MS<br/>
- Download 40 Mbps +<br/>
- Upload Approx 17 Mbps



# ![youtube-logo-png-46026](https://user-images.githubusercontent.com/11254983/164994883-0a78494e-ae24-4eee-bdbe-a165a7c7d890.png) OpenWRT BT Wi-fi YouTube Guide<br/>

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/z7pTcrwUQkU/0.jpg)](https://www.youtube.com/watch?v=z7pTcrwUQkU)



# ![48 terminal-icon copy](https://user-images.githubusercontent.com/11254983/164985283-235c64c3-415e-4cb1-8ce9-8967c23add8e.png) Autologin (HTTP POST & Wget)

<details>
  <summary>Click to expand!</summary><br/>

## ![48 green icon](https://user-images.githubusercontent.com/11254983/164984530-03352fa6-2b61-427a-b92c-911b60fee1bb.png) Secure (With SSL Cert) <br/>
- BT Home Broadband:<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/tbbLogon<br/>
<br/>
- Bt WiFi (Pay & Go)<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/ante<br/>
<br/>
- Bt Buisness Broadband
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/ante?partnerNetwork=btb

## ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure (Must Allow Any Certificate)( <br/>
- BT Home Broadband:<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://192.168.23.21:8443/tbbLogon<br/>
<br/>
- Bt WiFi (Pay & Go)<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://192.168.23.21:8443/ante<br/>
<br/>
- Bt Buisness Broadband<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://192.168.23.21:8443/ante?partnerNetwork=btb<br/>

</details>



# ![48 http copy 2](https://user-images.githubusercontent.com/11254983/164985125-01ad4452-6b6a-42e7-94d5-a04020e1ded5.png) Autologin (HTTP GET & Browser URL)<br/>

<details>
  <summary>Click to expand!</summary><br/>

## ![48 green icon](https://user-images.githubusercontent.com/11254983/164993018-7814c4d6-baee-4602-aae1-a9def39702cd.png) Secure Page <br/>
(Normal Login, Does NOT Work With Other DNS Settings EG. Goggle DNS = DNS Rebind Protection OFF)<br/>
https://www.btwifi.com:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD

## ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure Page <br/>
(SSL Error in Browser, but still works, Works With Other DNS Settings EG. Goggle DNS = DNS Rebind Protection ON) <br/>
https://192.168.23.21:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD
 
</details>



# Instant Logoff URLs<br/>

<details>
  <summary>Click to expand!</summary><br/>

## ![48 green icon](https://user-images.githubusercontent.com/11254983/164993018-7814c4d6-baee-4602-aae1-a9def39702cd.png) Secure Page <br/>
(Normal Logoff, Does NOT Work With Other DNS Settings EG. Goggle DNS = DNS Rebind Protection OFF) <br/>
https://www.btwifi.com:8443/accountLogoff/home?confirmed=true

## ![48 red icon](https://user-images.githubusercontent.com/11254983/164984548-c5ebaa6f-e76a-4752-8700-ed836cc31165.png) Insecure <br/>
(SSL Error in Browser, but still works, Works With Other DNS Settings EG. Goggle DNS = DNS Rebind Protection ON) <br/>
https://192.168.23.21:8443/accountLogoff/home?confirmed=true

</details> 
  
  
  
# ![48 Yellow Info](https://user-images.githubusercontent.com/11254983/164985697-861a5a64-e88a-4279-a317-13859676e50e.png) To Leave Rebind Protection On & Set Up Alternatave DNS Servers

<details>
  <summary>Click to expand!</summary><br/>
 
Use The insecure URLs as these work without BTs DNS server<br/>
Im Using Google DNS on the internal network To Remove Forced Google Safe Search<br/>
Chose Network > Interfaces & EDIT the LAN Interface<br/>
Open DHCP Server Tab & Under DHCP-Options ADD<br/>
  
6,8.8.8.8,8.8.4.4 (LEDE 17)<br/>

  </details>
 
 

# ![MacroDroid_forum_48](https://user-images.githubusercontent.com/11254983/164982041-be7d0dd7-5c9a-4b24-a5a4-4e8f82a17bc5.png) Macrodroid Setup<br/>

<details>
  <summary>Click to expand!</summary>

## Template Availible In The Macrodroid Template Store!<br/>
![1 Screenshot_20220412-123013_MacroDroidStore](https://user-images.githubusercontent.com/11254983/163649134-b3bc7d86-01b2-42ee-a469-ac74f1c2c86b.jpg)
<br/>

## Variables Tab (Ajust Settings & Add Account Here)<br/>
![3  Screenshot_20220415-230400_MacroDroid_copy_640x1422](https://user-images.githubusercontent.com/11254983/163649231-921d6e70-86e0-46d0-8064-635d2b450ab8.png)
<br/>

## Main Macro<br/>

<details>
  <summary>Click to expand!</summary>

![2  Screenshot_20220415-230329_MacroDroid_copy_640x6225](https://user-images.githubusercontent.com/11254983/163649196-6d36793d-7038-4684-b65e-305aaa9dc821.jpg)
<br/>

   </details>
   
  ## HTTP POST Request<br/>
   
  <details>
   <summary>Click to expand!</summary>
   
![3 Screenshot_20220412-123013_MacroDroid](https://user-images.githubusercontent.com/11254983/163034409-5751704c-937f-4461-9342-fe42f943fb53.jpg)<br/>
<br/>

  </details>

## HTTP POST Body<br/>

<details>
  <summary>Click to expand!</summary>

![4  Screenshot_20220412-123022_MacroDroid_copy_648x1440](https://user-images.githubusercontent.com/11254983/163034412-4e559a75-585d-4368-a9d5-3ab1d91de674.png)<br/>

  </details>
  
   </details>
   
   
  
 # ![2528830](https://user-images.githubusercontent.com/11254983/164993973-1b534096-84a8-4785-bf39-ea177eea4274.png) OpenWrt Setup<br/>
 
 <details>
  <summary>Click to expand!</summary>
  
  In Progress
  
  </details>
  
