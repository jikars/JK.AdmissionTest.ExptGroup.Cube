﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JK.Cube.Api._Autommaper;
using JK.Cube.Api._IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace JK.Cube.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            IoCBoostrapper.RegisterModules();
            services.AddSingleton<IControllerActivator>(new IoCControllerActivator());
            SwaggerConfig.Config(services);
            AutommapperBoostrapper.RegisterProfiles();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            SwaggerConfig.Config(app);
            app.UseMvc();
        }
    }
}
