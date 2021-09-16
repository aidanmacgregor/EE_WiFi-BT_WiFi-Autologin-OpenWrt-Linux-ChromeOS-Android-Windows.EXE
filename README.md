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

### Trigger: 
1 - Every 5 Seconds

### Action:
1 - Connectivity Check (Block Next Action Untill This One Complete & write to a local Variable)

2 - Open Website (And include your modified URL)
2.1 - [CONSTRAINT] Macrodroid Variable - Internet Connectivity = False
2.2 - [CONSTRAINT] Wifi Connected (Optional)

3 - Press Back Button (Optional)
3.1 - [CONSTRAINT] Macrodroid Variable - Internet Connectivity = True
3.2 - [CONSTRAINT] App Foreground (Browser app that opens the URL automatically Eg. Chrome)

### Constraints

NONE

# OpenWRT BT Wi-fi YouTube Guide
[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/z7pTcrwUQkU/0.jpg)](https://www.youtube.com/watch?v=z7pTcrwUQkU)

# To Leave Rebind Protection On & Set Up Alternatave DNS Servers, Use The insecure URLs as these work without BTs DNS server
# Im Using Googel DNS on the internal network Chose Network > Interfaces & EDIT the LAN Interface
# Open DHCP Server Tab & Under DHCP-Options ADD 
# 6,8.8.8.8
# And Also
# 6,8.8.4.4

# Login URLS:

## Secure Page (Normal Login, works, Does NOT Work With Other DNS Settings EG. Goggle DNS) DNS Rebind Protection = OFF
https://www.btwifi.com:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD

## Insecure (SSL Error in Browser, but still works, Works With Other DNS Settings EG. Goggle DNS) DNS Rebind Protection = ON
https://192.168.23.21:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD

# Logoff Automatically'

## Secure Page (Normal Logoff, works, Does NOT Work With Other DNS Settings EG. Goggle DNS) DNS Rebind Protection = OFF
https://www.btwifi.com:8443/accountLogoff/home?confirmed=true

## Insecure (SSL Error in Browser, but still works, Works With Other DNS Settings EG. Goggle DNS) DNS Rebind Protection = ON
https://192.168.23.21:8443/accountLogoff/home?confirmed=true
