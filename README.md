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

Upon fist launch the application will generate a config.json. Open it with your desired text editor and put in the wanted firmware link for your phone.

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

Once you redirected the traffic you can use the E Recovery to restore or the update function in Android itself.

Make sure to change the DNS settings back to normal after you're done. Good luck!
