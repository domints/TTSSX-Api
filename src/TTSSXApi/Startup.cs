using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TTSSXApi.Models.Db;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace TTSSXApi
{
    public class Startup
    {
        ILogger log;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var connectionString = Configuration["Data:Conn"];
            Console.WriteLine("Configuration dump:");
            foreach(var kv in Configuration.AsEnumerable())
            {
                Console.WriteLine($"{kv.Key} : {kv.Value}");
            }
            services.AddDbContext<TtssxContext>(
                opts => opts.UseNpgsql(connectionString)
            );
            try
            {
                var dboptions = new DbContextOptionsBuilder<TtssxContext>();
                dboptions.UseNpgsql(connectionString);
                TtssxContext cx = new TtssxContext(dboptions.Options);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}\r\n{ex.StackTrace}");
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            log = loggerFactory.CreateLogger("error");
            try
            {
                app.UseMvc();
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler(
                    builder =>
                    {
                        builder.Run(
                          async context =>
                          {
                              context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                              context.Response.ContentType = "text/html";

                              var error = context.Features.Get<IExceptionHandlerFeature>();
                              if (error != null)
                              {
                                  await context.Response.WriteAsync($"<h1>Error: {error.Error.Message}</h1>{error.Error.StackTrace}").ConfigureAwait(false);
                                Console.WriteLine($"[ERROR] {error.Error.Message}\r\n{error.Error.StackTrace}");
                              }
                          });
                    });
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                Console.WriteLine($"[ERROR] {ex.Message}\r\n{ex.StackTrace}");
                app.Run(
                  async context =>
                  {
                      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                      context.Response.ContentType = "text/plain";
                      await context.Response.WriteAsync(ex.Message).ConfigureAwait(false);
                      await context.Response.WriteAsync(ex.StackTrace).ConfigureAwait(false);
                  });
            }
        }
    }
}
