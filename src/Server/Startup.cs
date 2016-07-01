using System;
using System.Linq;
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
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection.Extensions;

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

        public void SetInitializerDatabase(IServiceProvider provider)
        {
            var db = provider.GetService<Db>();
            db.Database.Migrate();
        }

        public IServiceProvider ConfigureServicesBase(IServiceCollection services)
        {
            services.AddMvc();

            var autofacBuilder = new ContainerBuilder();
            autofacBuilder.Populate(services);
            autofacBuilder.RegisterModule<ServicesModule>();

            var container = autofacBuilder.Build();

            return container.Resolve<IServiceProvider>();
        }

       
        public IServiceProvider ConfigureDevelopmentServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Db>(options => options.UseSqlServer(connection));

            var provider = ConfigureServicesBase(services);

            SetInitializerDatabase(provider);

            return provider;
        }

        /// <summary>
        /// For production environment
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //TODO: load db connection from appsettings.production.json
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Db>(options => options.UseSqlServer(connection));

            var provider = ConfigureServicesBase(services);

            SetInitializerDatabase(provider);

            return provider;
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
