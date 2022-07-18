#!/bin/bash

###############- BTWifi Openwrt Autologin Script -###############
##############-- By: Aidan Macgregor (May 2022) --###############
# https://github.com/aidanmacgregor/BT_Wi-Fi_Autologin_MACRODROID-WISPr-HTTP_POST-HTTP_GET-OpenWRT
# (Tested On Ubuntu Via WSL2)

############### INFO ###############

# Copy To A Directory To Run It & Give Permission
#	chmod +x BTWi-fi_Autologin_Script.sh

#### Manual Run (Ensure The Script Is In The Current Directory)
# 	 ./BTWi-fi_Autologin_Script.sh

#### In The SETTINGS Section Choose Your Account Type & Add Email & Password

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
				wget -T 2 -O /dev/null --post-data "username=$USERNAME&password=$PASSWORD" 'https://btwifi.com:8443/tbbLogon'
			elif [ "$ACCOUNTTYPE" = "2" ]
			then
				logger -t BTWi-fi "Offline, attempting login URL2 (BT Buisness Broadband Account)"																	 
				wget -T 2 -O /dev/null --post-data "username=$USERNAME&password=$PASSWORD" 'https://btwifi.com:8443/ante?partnerNetwork=btb'
			elif [ "$ACCOUNTTYPE" = "3" ]
			then
				logger -t BTWi-fi "Offline, attempting login URL3 (BT Wi-fi Account)"														 
				wget -T 2 -O /dev/null --post-data "username=$USERNAME&password=$PASSWORD" 'https://btwifi.com:8443/ante'
			fi
		fi
	fi
sleep 1
done