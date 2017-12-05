using HuaweiWebApi.Firmware;
using HuaweiWebApi.Misc;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HuaweiWebApi.Controllers
{
    [Route("sp_ard_common/[controller]")]
    public class v1 : Controller
    {
        // GET sp_ard_common/v1/onestopCheck.action
        [HttpPost]
        [Route("onestopCheck.action")]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public string OnestopCheck()
        {
            var writer = new ResponseWriter();
            writer.WriteStart();
            writer.WriteItem("status", "0");
            writer.WriteDictionary("components", Manager.GetFirmware());
            writer.WriteItem("checkEnd", "1");
            writer.WriteEnd();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Response onestopCheck.action sent");
            Console.ForegroundColor = ConsoleColor.White;

            var json = Helper.TrimJson(writer.GetJsonString());
            Response.ContentLength = json.Length;

            return json;
        }
    }
}