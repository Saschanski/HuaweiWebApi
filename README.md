# Emulation of the Huawei API endpoint for firmware updates and recovery.


----------

This is a Asp.Net Core Web Api endpoint providing a replica of the Huawei API to get the recovery / update service to actually work.

I only tested it against the **PRA-LX1** right now but it should be the same for every Huawei phone.

----------

It works using a local DNS server to redirect the phones traffic to the local API offering the desired firmware infos.

----------

Usage
-----
In order to run this you need the current **.Net Core SDK** from the following site:
https://www.microsoft.com/net/learn/get-started/windows

After installing the SDK and cloning this repository open a CMD and `cd` into the project folder.
Then simply just type **`dotnet run`** and .Net Core will build and run the application.

*Make sure there's no process listening already on port **80 (HTTP)** and **53 (DNS)**.*

Upon first launch the application will generate a config.json if not present. Open it with your desired text editor and put in the wanted firmware link for your phone.

It will look like this:

    {
      "FirmwareSettings": {
        "FirmwareName": "PRA-LX1C432B110",
        "FirmwareVersion": "PRA-LX1C432B110",
        "FirmwareLink": "http://update.hicloud.com:8180/TDS/data/files/p3/s15/G1458/g104/v76120/f1/"
      }
    }
    
You can get the FirmwareLink for your phone at the website of pro-teammt:
http://pro-teammt.ru/firmware-database/

FirmwareName & FirmwareVersion are actually not important. You can put whatever in. Just make sure the link is like above.

If your phone is currently soft bricked you should get a **FullOTA-MF** variant for a complete restore.


----------
Next thing is to actually route the phones traffic to the machine the application is running on.

You can do it through your router and change the DNS entry to the IP of the machine where the application is running. I can't help on that tho since there are a million different router. So yeah.

Another way would be creating a **Virtual WIFI**. If you got a laptop/netbook or a wifi stick you can setup one easily.

For Linux there are plenty guides out there on google for whatever distro you are using.
For macOS I really dont know. Guess there is an exploit for it? /sarcasm

For Windows 7 or higher I'll describe it here.


----------

Open up a CMD and enter following commands

    netsh wlan set hostednetwork mode=allow ssid="Huawei Recovery Service" key=password123 keyUsage=persistent
    
    netsh wlan start hostednetwork

You'll see a new connection in your network settings. Now you need to enable internet sharing.

![enter image description here](https://i.gyazo.com/4b23cb2f6ab6b3a99e39e78ef7352e73.png)

Click on the Ethernet or Wifi label of your default internet connection.
Now click on properties and switch to Sharing tab.

![enter image description here](https://i.gyazo.com/f073de174a08f0e37cd9e235dbabd0e2.png)

Check the "Allow other network users..." checkbox and choose the created virtual wifi in the dropdown.

Switch back to the Networking tab and double click on **Internet Protocol Version 4 (TCP/IPv4)**

![enter image description here](https://i.gyazo.com/224ced41754280cab95e25608cbcba47.png)

Select "Use the following DNS server addresses" and put in the IP of the machine the application is running on.

Click OK and Close.

Now restart the Virtual Wifi. Again commands in cmd.

    netsh wlan stop hostednetwork
    netsh wlan start hostednetwork

That should cover it.

----------


Once you redirected the traffic you can use the E Recovery to restore or the update function in Android itself.

Make sure to change the DNS settings back to normal after you're done. Good luck!

