using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DNS.Client;
using DNS.Server;


namespace HuaweiWebApi.Misc
{
    public static class Server
    {
        public static void MainAsync()
        {
            // Proxy to google's DNS
            var server = new DnsServer("8.8.8.8");

            // Resolve these domain to localhost
            server.MasterFile.AddIPAddressResourceRecord("query.hicloud.com", Program.Configuration.RedirectIP);

            //server.Requested += (request) => Console.WriteLine(request);
            // On every successful request log the request and the response
            server.Responded += (request, response) => Console.WriteLine("{0}", request.Questions.First());
            // Log errors
            server.Errored += (e) => Console.WriteLine(e.Message);

            Console.WriteLine("DNS server started");

            // Start the server (by default it listents on port 53)
#pragma warning disable 4014
            server.Listen();
#pragma warning restore 4014
        }

    }
}
