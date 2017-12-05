using System;
using System.Collections.Generic;
using System.Linq;
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
            DnsServer server = new DnsServer("8.8.8.8");

            // Resolve these domain to localhost
            server.MasterFile.AddIPAddressResourceRecord("query.hicloud.com", "192.168.178.26");

            // Log every request


            //server.Requested += (request) => Console.WriteLine(request);
            // On every successful request log the request and the response
            server.Responded += (request, response) => Console.WriteLine("{0}", request.Questions.First());
            // Log errors
            server.Errored += (e) => Console.WriteLine(e.Message);

            // Start the server (by default it listents on port 53)
            server.Listen();
        }

    }
}
