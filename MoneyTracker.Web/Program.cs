using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MoneyTracker.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(x => x.AddAutofac())
                .ConfigureAppConfiguration((host, builder) => RegisterConfiguration(host.HostingEnvironment, builder))
                .UseStartup<Startup>();

        private static void RegisterConfiguration(IHostingEnvironment env, IConfigurationBuilder builder)
        {
            builder = builder
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }
        }
    }
}
