using System.Globalization;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyTracker.Infrastructure.Configuration;
using MoneyTracker.Infrastructure.Ioc;
using MoneyTracker.Web.Infrastructure;

namespace MoneyTracker.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CurrencyViewHelper>();
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddLocalization(x => x.ResourcesPath = "Resources");
            services.AddMvc()
                //.AddDataAnnotationsLocalization()
                .AddViewLocalization();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<DomainModule>();
            builder.RegisterModule<PersistenceModule>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //var supportedCultures = new[]
            //{
            //    new CultureInfo("en"),
            //    new CultureInfo("ru")
            //};

            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture("en"),
            //    SupportedCultures = supportedCultures,
            //    SupportedUICultures = supportedCultures
            //});

            app.UseMvc(x => x.MapRoute("/", "{controller}/{action}", new
            {
                controller = "Home",
                action = "Index"
            }));
        }
    }
}
