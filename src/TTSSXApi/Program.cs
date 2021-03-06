﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace TTSSXApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if !DEBUG
            string listenPort = string.Empty; 
            if(args.Length > 0)
            {
                listenPort = args[0];
            }
            else
{
            string appPath = Directory.GetCurrentDirectory();
            if (!Directory.GetFiles(appPath).Any(file => file.ToLower().Contains("ttssxapi.dll")))
            {
                appPath = Path.Combine(appPath, "root");
            }

            var builder = new ConfigurationBuilder()
                    .SetBasePath(appPath)
                    .AddJsonFile("appsettings.production.json");
            var config = builder.Build();  

 }        
Console.WriteLine("BOOTING ON PORT " + listenPort);
#endif

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
#if DEBUG
                .UseIISIntegration()
#endif
                .UseStartup<Startup>()
#if !DEBUG
                .UseUrls(string.Format("http://*:{0}", listenPort))
#endif
                .Build();

            host.Run();
        }
    }
}
