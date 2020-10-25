using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public static class Application
    {
        public class Auth0ConfigSection
        {
            public string Domain { get; set; }
            public string Audience { get; set; }
            public string ClientId { get; set; }
            public string RoleClaimType { get; set; }
            public string AdminRoleName { get; set; }
        }

        public static IConfiguration Configuration { get; set; }
        public static Auth0ConfigSection Auth0Config => Configuration.GetSection("Auth0").Get<Auth0ConfigSection>();
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
