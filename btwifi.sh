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
