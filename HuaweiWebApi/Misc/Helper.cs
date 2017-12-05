using System.Text.RegularExpressions;

namespace HuaweiWebApi.Misc
{
    public static class Helper
    {
        public static string TrimJson(string content)
        {
            return content.Replace(" ", "").Replace("\r\n", "");
        }

        public static string GetVersion()
        {
            var _pattern = @"files\/([^\/]+)\/([^\/]+)\/([^\/]+)\/([^\/]+)\/([^\/]+)";
            var match = Regex.Match(Program.Configuration.FirmwareSettings.FirmwareLink, _pattern).Groups[5].Value;
            return Regex.Replace(match, "[^0-9]", "");
        }
    }
}
