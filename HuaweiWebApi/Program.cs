using System;
using HuaweiWebApi.Misc;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Hosting;

namespace HuaweiWebApi
{
    public class Program
    {
        public static ApplicationConfiguration Configuration { get; private set; }

        public static void Main(string[] args)
        {
            LoadConfig();

            JsonApplicationConfiguration.Save("Config", Configuration, false);

            Console.WriteLine($"Redirecting to: {Program.Configuration.RedirectIP}");

            Server.MainAsync();
            BuildWebHost(args).Run();
        }

        public static void LoadConfig()
        {
            Configuration = JsonApplicationConfiguration.Load<ApplicationConfiguration>("Config", false, false);
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*/")
                .Build();
    }
}
