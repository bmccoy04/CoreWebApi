﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MediatR;
using AutoMapper;
using CoreWebApi.Api.Configurations;
using CoreWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CoreWebApi.Core.Interfaces;
using FluentValidation.AspNetCore;
using CoreWebApi.Core.Dtos;
using CoreWebApi.Api.Filters;

namespace CoreWebApi.Api
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
            services.AddMvc(options =>{
                options.Filters.Add(new CustomExceptionFilter());
            })
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BlogDto>())
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            SwaggerConfig.ConfigureServices(services);

            SimpleInjectorConfig.ConfigureServices(services);

            services.AddLogging();

            services.AddDbContext<AppDbContext>(options => 
                //options.UseSqlServer(Configuration.GetConnectionString("AppDbContext"), b => b.MigrationsAssembly("CoreWebApi.Api"))
                options.UseInMemoryDatabase("CoreWebApi")
            );

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

            SwaggerConfig.Configure(app, env);
            SimpleInjectorConfig.Configure(app, env);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
