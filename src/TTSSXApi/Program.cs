using System;
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
            string appPath = Directory.GetCurrentDirectory();
	    string sAppPath = env.ContentRootPath;
     string sRootPath = Path.GetFullPath(Path.Combine(sAppPath, @"..\..\"));
     string sBinFolderPath = @"artifacts\bin\" + appenv.ApplicationName;
     string sBinPath = Path.Combine(sRootPath, sBinFolderPath);
Console.WriteLine("AppPath: " + appPath);
Console.WriteLine("sAppPath: " + sAppPath);
Console.WriteLine("sRootPath: " + aRootPath);
Console.WriteLine("sBinFolderPath: " + sBinFolderPath);
Console.WriteLine("sBinPath: " + sBinPath);
            if (!Directory.GetFiles(appPath).Any(file => file.ToLower().Contains("ttssxapi.dll")))
            {
                appPath = Path.Combine(appPath, "root");
            }

            var builder = new ConfigurationBuilder()
                    .SetBasePath(appPath)
                    .AddJsonFile("appsettings.production.json");
            var config = builder.Build();            
#endif

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
#if DEBUG
                .UseIISIntegration()
#endif
                .UseStartup<Startup>()
#if !DEBUG
                .UseUrls("http://*:{0}", config["ListenPort"])
#endif
                .Build();

            host.Run();
        }
    }
}
