namespace HuaweiWebApi.Misc
{
    public class ApplicationConfiguration
    {
        public ApplicationConfiguration()
        {
            FirmwareSettings = new FirmwareSettings();
            RedirectIP = "192.168.178.20";

        }
        public FirmwareSettings FirmwareSettings { get; set; }
        public string RedirectIP { get; set; } = "192.168.178.20";

    }

    public class FirmwareSettings
    {
        public FirmwareSettings()
        {
            FirmwareName = "PRA-LX1C432B110";
            FirmwareVersion = "PRA-LX1C432B110";
            FirmwareLink = "http://update.hicloud.com:8180/TDS/data/files/p3/s15/G1458/g104/v76120/f1/";
        }

        public string FirmwareName { get; set; } = "PRA-LX1C432B110";
        public string FirmwareVersion { get; set; } = "PRA-LX1C432B110";
        public string FirmwareLink { get; set; } = "http://update.hicloud.com:8180/TDS/data/files/p3/s15/G1458/g104/v76120/f1/";
    }
}
