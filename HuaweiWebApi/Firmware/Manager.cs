using HuaweiWebApi.Misc;
using System.Collections.Generic;

namespace HuaweiWebApi.Firmware
{
    public static class Manager
    {
        public static Dictionary<string, string> GetFirmware()
        {
            Program.LoadConfig();

            var dic = new Dictionary<string, string>
            {
                {"name", Program.Configuration.FirmwareSettings.FirmwareName},
                {"version", Program.Configuration.FirmwareSettings.FirmwareVersion},
                {"versionID", Helper.GetVersion()},
                {"description", ""},
                {"ruleAttr", ""},
                {"createTime", ""},
                {"url", Program.Configuration.FirmwareSettings.FirmwareLink},
                {"reserveUrl", "update8.hicloud.com"},
                {"componentID", "1"},
                {"versionType", "1"},
                {"pointVersion", "0"}
            };
            return dic;
        }
    }
}
