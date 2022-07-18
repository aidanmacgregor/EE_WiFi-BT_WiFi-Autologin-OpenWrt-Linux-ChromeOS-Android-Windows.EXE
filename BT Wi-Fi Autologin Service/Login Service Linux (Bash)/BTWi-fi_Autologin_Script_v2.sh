#!/bin/bash

##############-- BT Wi-Fi Openwrt Autologin Script v2 --##############
##############-     By: Aidan Macgregor (July 2022)    -##############

# https://github.com/aidanmacgregor/
# (Tested On Ubuntu Via WSL2)

############### INFO ###############

# Copy To A Directory To Run It & Give Permission
#	chmod +x BTWi-fi_Autologin_Script_v2.sh

#### Manual Run (Ensure The Script Is In The Current Directory)
# 	 ./BTWi-fi_Autologin_Script_v2.sh

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

LOGSIZE=40
PING1=1.1.1.1
PING2=8.8.8.8
PING3=9.9.9.9
LOGPATH=LOGPATH=/BTWi-fi_Autologin_Service_LOG.txt

##########################################
#####---- DO NOT EDIT BELOW HERE ----#####
##########################################

# Ensure PATH is sensible
export PATH=/usr/sbin:/usr/bin:/sbin:/bin:$PATH

logger -t BTWi-fi_Autologin_Script Started "$(date) BTWi-fi Autologin Script Started"
	echo "$(date) BTWi-fi Autologin Script Started" >> $LOGPATH
	echo "btwifi.sh is RUNNING! Press [ctrl] & [c] to stop or test by logging out Manually"
	
while true
do
	if ! ping -c 1 -W 1 $PING1 2>/dev/null >/dev/null	 
	then							 
		if ! ping -c 1 -W 1 $PING2 2>/dev/null >/dev/null			 
		then
			if ! ping -c 1 -W 1 $PING3 2>/dev/null >/dev/null
			then
				if [ "$ACCOUNTTYPE" = "1" ]
				then
				logger -t BTWi-fi_Autologin_Service "$(date) Offline, attempting login URL 1 (BT Home Broadband Account)"
				echo "$(date) Offline, attempting login URL 1 (BT Home Broadband Account)" >> $LOGPATH
				wget -T 2 -O /dev/null --post-data "username=$USERNAME&password=$PASSWORD" 'https://btwifi.com:8443/tbbLogon'
					
		        elif [ "$ACCOUNTTYPE" = "2" ]
		        then
				logger -t BTWi-fi_Autologin_Service "$(date) Offline, attempting login URL 2 (BT Buisness Broadband Account)"
				echo "$(date) Offline, attempting login URL 2 (BT Buisness Broadband Account)" >> $LOGPATH
		        wget -T 2 -O /dev/null --post-data "username=$USERNAME&password=$PASSWORD" 'https://btwifi.com:8443/ante?partnerNetwork=btb'
					
		        elif [ "$ACCOUNTTYPE" = "3" ]
		        then
				logger -t BTWi-fi_Autologin_Service "$(date) Offline, attempting login URL 3 (BT Wi-Fi Account)"
				echo "$(date) Offline, attempting login URL 3 (BT Wi-Fi Account)" >> $LOGPATH
		        wget -T 2 -O /dev/null --post-data "username=$USERNAME&password=$PASSWORD" 'https://btwifi.com:8443/ante'

					if [[ "$LOGSIZE" -ge "$LOGSIZE" ]]
					then
					echo "$(tail -$LOGSIZE $LOGPATH)" > $LOGPATH
					fi
			    fi
			fi
		fi
	fi
sleep 1
done
