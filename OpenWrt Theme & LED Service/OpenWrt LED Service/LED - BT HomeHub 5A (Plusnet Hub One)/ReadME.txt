Install The Backup Archive For Your OpenWrt Version, Select The Wireless Interface (Default 2.4Ghz Client Mode Radio 1)

# Run This Command To Select Correct Interface
#	cat /proc/net/wireless | awk {print}

# My Client Mode Connection NR==4 in the RSSI is chosen as im conneccted to AP on wlan1 (See Example Below)

	#	1		Inter-| sta-|   Quality        |   Discarded packets               | Missed | WE
	#	2		face | tus | link level noise |  nwid  crypt   frag  retry   misc | beacon | 22
	#	3 		wlan0: 0000     0     0     0        0      0      0      0      0        0
	#   4 (NR==4)	wlan1: 0000   33.  -77.  -256        0      0      0     15    173        0
	#	5	  	wlan1-1: 0000   0     0     0        0      0      0      0      0        0
             
# Replace Interface Number If Needed On Line Number 67 (Eg. For wlan0 in my example set: NR==3)