using HuaweiWebApi.Firmware;
using HuaweiWebApi.Misc;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HuaweiWebApi.Controllers
{
    [Route("sp_ard_common/[controller]")]
    public class v2 : Controller
    {
        // POST sp_ard_common/v2/Check.action
        [HttpPost]
        [Route("Check.action")]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        //public JsonResult Post(bool latest = true, bool ruleAttr = true, bool defenceHijack = true, bool verType = true, [FromBody]string content = "-1")
        public string Check()
        {
            var writer = new ResponseWriter();
            writer.WriteStart();
            writer.WriteItem("status", "0");
            writer.WriteDictionary("components", Manager.GetFirmware());
            writer.WriteItem("checkEnd", "1");
            writer.WriteEnd();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Response Check.action sent");
            Console.ForegroundColor = ConsoleColor.White;

            var json = Helper.TrimJson(writer.GetJsonString());
            Response.ContentLength = json.Length;

            return json;
        }
    }
}
