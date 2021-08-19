# BT-WiFi-Autologin-URL-WISPr-FON
The URL to automatically log in to BT Wi-Fi Public Hotspots, no need to load the log in page @ sign in, Edit The URL with your Username &amp; Password (eg: aidan@btinternet.com)

Logging in is a 1 click process & instant

I Advise Using An Android Device & Macrodroid, Set up As Follows

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

# Login URLS:

## Secure Page
https://www.btwifi.com:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD

## Insecure
https://192.168.23.21:8443/wbacOpen?username=USERNAME@btinternet.com&password=PASSWORD

# Logoff Automatically'

## Secure Page
https://www.btwifi.com:8443/accountLogoff/home?confirmed=true

## Insecure
https://192.168.23.21:8443/accountLogoff/home?confirmed=true
