# BT-WiFi-Autologin-URL-WISPr-FON
The URL to automatically log in to BT Wi-Fi Public Hotspots, no need to load the log in page & sign in<br/> 
Edit The URL with your Username &amp; Password (eg: aidan@btinternet.com)

Logging in is a 1 click process & instant OR automatic if uuising Macrodroid (Free)

### I Advise Using An Android Device & Macrodroid, Set up As Follows

Tested In A Home Internet Replacment Setting, using BT Home Hub 5 Flashed With OpenWRT 
Configured in Client & Access Point Mode, This allows one device to sign in every device inside my network<br/>
this runs well & downtime is almost non existant, manually logging out and letting it sign itself in 
didnt break an active download i had running

### Speeds For Me: (You Will Vary)
Ping Approx. 40 MS<br/>
Download 40 Mbps +<br/>
Upload Approx 17 Mbps

# OpenWRT BT Wi-fi YouTube Guide
[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/z7pTcrwUQkU/0.jpg)](https://www.youtube.com/watch?v=z7pTcrwUQkU)

# Login Automatically URLs

## Secure Page<br/>
(Normal Login, Does NOT Work With Other DNS Settings EG. Goggle DNS)<br/>
### DNS Rebind Protection = OFF
https://www.btwifi.com:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD

## Insecure Page<br/>
(SSL Error in Browser, but still works, Works With Other DNS Settings EG. Goggle DNS) DNS Rebind Protection = ON<br/>
https://192.168.23.21:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD

# Logoff Automatically URLs

## Secure Page <br/>
(Normal Logoff, Does NOT Work With Other DNS Settings EG. Goggle DNS) DNS Rebind Protection = OFF
https://www.btwifi.com:8443/accountLogoff/home?confirmed=true

## Insecure <br/>
(SSL Error in Browser, but still works, Works With Other DNS Settings EG. Goggle DNS) DNS Rebind Protection = ON
https://192.168.23.21:8443/accountLogoff/home?confirmed=true

# To Leave Rebind Protection On & Set Up Alternatave DNS Servers
Use The insecure URLs as these work without BTs DNS server<br/>
Im Using Google DNS on the internal network<br/>
Chose Network > Interfaces & EDIT the LAN Interface<br/>
Open DHCP Server Tab & Under DHCP-Options ADD<br/>
6,8.8.8.8<br/>
And Also<br/>
6,8.8.4.4<br/>

# Macrodroid set Up
![BT_WiFi_Automatic_Login_(Share)](https://user-images.githubusercontent.com/11254983/133694503-6597faea-71b6-4b85-8826-3904cc7e5e5d.png)
