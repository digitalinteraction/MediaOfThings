using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenLab.Kitchen.Repository;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.WebApi
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IReadOnlyRepository<Production>>(s => new MongoRepository<Production>(Configuration.GetConnectionString("MongoConnection"), "Production"));
            services.AddTransient<IReadOnlyRepository<Wax3Data>>(s => new MongoRepository<Wax3Data>(Configuration.GetConnectionString("MongoConnection"), "Wax3"));
            services.AddTransient<IReadOnlyRepository<Wax9Data>>(s => new MongoRepository<Wax9Data>(Configuration.GetConnectionString("MongoConnection"), "Wax9"));
            services.AddTransient<IReadOnlyRepository<WaterFlow>>(s => new MongoRepository<WaterFlow>(Configuration.GetConnectionString("MongoConnection"), "WaterFlow"));
            services.AddTransient<IReadOnlyRepository<RfidData>>(s => new MongoRepository<RfidData>(Configuration.GetConnectionString("MongoConnection"), "Rfid"));

            // Add framework services.
            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
