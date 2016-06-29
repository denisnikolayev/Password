using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Epam.Password.Server.Configuration;
using Epam.Password.Server.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Epam.Password.Server
{
    public class Startup
    {
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

        public IServiceProvider ConfigureServicesBase(IServiceCollection services)
        {
            services.AddMvc();

            var autofacBuilder = new ContainerBuilder();
            autofacBuilder.Populate(services);
            autofacBuilder.RegisterModule<ServicesModule>();

            var container = autofacBuilder.Build();

            return container.Resolve<IServiceProvider>();
        }

       
        public IServiceProvider ConfigureDeveloperServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;";
            services.AddDbContext<Db>(options => options.UseSqlServer(connection));

            return ConfigureServicesBase(services);
        }

        /// <summary>
        /// For production environment
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //TODO: load db connection from appsettings.production.json
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;";
            services.AddDbContext<Db>(options => options.UseSqlServer(connection));
            
            return ConfigureServicesBase(services);
        }

        public IServiceProvider ConfigureTestServices(IServiceCollection services)
        {
            services.AddDbContext<Db>(options => options.UseInMemoryDatabase());

            return ConfigureServicesBase(services);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
