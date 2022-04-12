# BT-WiFi-Autologin-URL-WISPr-FON
<br/> 
The URL to automatically log in to BT Wi-Fi Public Hotspots, no need to load the log in page & sign in<br/> 
Edit The URL with your Username &amp; Password (eg: aidan@btinternet.com)

Logging in is a 1 click process & instant OR automatic if uuising Macrodroid (Free)

### I Advise Using An Android Device & Macrodroid, Set up As Follows <br/>

Tested In A Home Internet Replacment Setting, using BT Home Hub 5 Flashed With OpenWRT Configured in Client & Access Point Mode <br/>
This allows one device to sign in every device inside my network <br/>
this runs well & downtime is almost non existant <br/>
manually logging out and letting it sign itself in didnt break an active download i had running

### Speeds For Me: (You Will Vary) <br/>
Ping Approx. 40 MS<br/>
Download 40 Mbps +<br/>
Upload Approx 17 Mbps

# OpenWRT BT Wi-fi YouTube Guide <br/>
[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/z7pTcrwUQkU/0.jpg)](https://www.youtube.com/watch?v=z7pTcrwUQkU)

# Login Automatically URLs (HTTP GET & Browser URL Bar)<br/>
These work in a browser & inside Macrodroid
## Secure Page <br/>
(Normal Login, Does NOT Work With Other DNS Settings EG. Goggle DNS = DNS Rebind Protection OFF)<br/>
https://www.btwifi.com:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD

## Insecure Page <br/>
(SSL Error in Browser, but still works, Works With Other DNS Settings EG. Goggle DNS = DNS Rebind Protection ON) <br/>
https://192.168.23.21:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD

# Alternative Using HTTP POST & Wget
## Secure (With SSL Cert) <br/>
BT Home Broadband:<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/tbbLogon<br/>
<br/>
Bt WiFi (Pay & Go)<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/ante<br/>
<br/>
Bt Buisness Broadband
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://www.btwifi.com:8443/ante?partnerNetwork=btb

## Insecure (Must Allow Any Certificate)( <br/>
BT Home Broadband:<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://192.168.23.21:8443/tbbLogon<br/>
<br/>
Bt WiFi (Pay & Go)<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://192.168.23.21:8443/ante<br/>
<br/>
Bt Buisness Broadband<br/>
wget -O /dev/null --post-data "username=USERNAME@btinternet.com&password=PASSWORD" https://192.168.23.21:8443/ante?partnerNetwork=btb<br/>

# Instant Logoff URLs<br/>

## Secure Page <br/>
(Normal Logoff, Does NOT Work With Other DNS Settings EG. Goggle DNS = DNS Rebind Protection OFF) <br/>
https://www.btwifi.com:8443/accountLogoff/home?confirmed=true

## Insecure <br/>
(SSL Error in Browser, but still works, Works With Other DNS Settings EG. Goggle DNS = DNS Rebind Protection ON) <br/>
https://192.168.23.21:8443/accountLogoff/home?confirmed=true


# To Leave Rebind Protection On & Set Up Alternatave DNS Servers
Use The insecure URLs as these work without BTs DNS server<br/>
Im Using Google DNS on the internal network To Remove Forced Google Safe Search<br/>
Chose Network > Interfaces & EDIT the LAN Interface<br/>
Open DHCP Server Tab & Under DHCP-Options ADD<br/>
6,8.8.8.8,8.8.4.4 (LEDE 17)<br/>
<br/>
### Macrodroid set Up<br/>
# Template Availible In The Macrodroid Template Store!<br/>
![Template](https://user-images.githubusercontent.com/11254983/162732928-27fa7882-2115-4912-b886-ae7e76809c88.png)<br/>
<br/>
# The Macro<br/>
Variables Tab (Ajust Settings & Add Account Here)<br/>
![1 Screenshot_20220412-122923_MacroDroid_copy_648x1440 (2)](https://user-images.githubusercontent.com/11254983/163034098-5f6895a6-1c1c-44d7-9dbe-61c660d230fb.png)<br/>
<br/>
# Main Macro<br/>
![2 Screenshot_20220412-122856_MacroDroid](https://user-images.githubusercontent.com/11254983/163034820-3abc3c5f-cd50-413f-9bd9-67070f5a9ca8.jpg)<br/>
<br/>
# HTTP POST Request<br/>
![3 Screenshot_20220412-123013_MacroDroid](https://user-images.githubusercontent.com/11254983/163034409-5751704c-937f-4461-9342-fe42f943fb53.jpg)<br/>
<br/>
# HTTP POST Body<br/>
![4  Screenshot_20220412-123022_MacroDroid_copy_648x1440](https://user-images.githubusercontent.com/11254983/163034412-4e559a75-585d-4368-a9d5-3ab1d91de674.png)<br/>
<br/>
Manual Macro Download: https://bit.ly/bt-wifi-macro<br/>
