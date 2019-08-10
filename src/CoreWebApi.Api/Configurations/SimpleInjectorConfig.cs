﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AutoMapper;
using AutoMapper.Configuration;
using CoreWebApi.Core.Entities;
using CoreWebApi.Core.Handlers;
using CoreWebApi.Core.Interfaces;
using CoreWebApi.Infrastructure.Data;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SimpleInjector;
using SimpleInjector.Lifestyles;


namespace CoreWebApi.Api.Configurations
{
    public class SimpleInjectorConfig
    {
        private static Container _container;

        public static void ConfigureServices(IServiceCollection services)
        {
            _container = new Container();

            services.AddSimpleInjector(_container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation()
                    .AddViewComponentActivation();
            });

            _container.RegisterSingleton<ILogger>(() => new LoggerConfiguration()
                                                    .MinimumLevel.Debug()
                                                    .WriteTo.Console()
                                                    .CreateLogger());

            _container.Register<IRepository, EfRepository>(Lifestyle.Transient);

            _container.RegisterSingleton<IMediator, Mediator>();

            _container.RegisterSingleton(() => GetMapper(_container));

            var assemblies = GetAssemblies().ToArray();
            _container.Register(typeof(IRequestHandler<,>), assemblies);
            var notificationHandlerTypes = _container.GetTypesToRegister(typeof(INotificationHandler<>), assemblies, new TypesToRegisterOptions
            {
                IncludeGenericTypeDefinitions = true,
                IncludeComposites = false,
            });
            _container.Collection.Register(typeof(INotificationHandler<>), notificationHandlerTypes);
            _container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
            {
                typeof(RequestPreProcessorBehavior<,>),
                typeof(RequestPostProcessorBehavior<,>),
            });

            _container.Collection.Register(typeof(IRequestPreProcessor<>), Enumerable.Empty<Type>());
            _container.Collection.Register(typeof(IRequestPostProcessor<,>), Enumerable.Empty<Type>());

            _container.Register(() => new ServiceFactory(_container.GetInstance), Lifestyle.Singleton);

            services.AddHttpContextAccessor();
            services.EnableSimpleInjectorCrossWiring(_container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);

        }

        private static AutoMapper.IMapper GetMapper(Container container)
        {
            var mapperProvider = container.GetInstance<MapperProvider>();
            return mapperProvider.GetMapper();
        }

        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            _container.CrossWire<AppDbContext>(app);
            app.UseSimpleInjector(_container, options => { options.UseLogging(); });
            
            _container.Verify();
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).GetTypeInfo().Assembly;
            yield return typeof(EfRepository).GetTypeInfo().Assembly;
            yield return typeof(IRepository).GetTypeInfo().Assembly;
        }
    }

    public class MapperProvider
    {
        private Container _container;

        public MapperProvider(Container container)
        {
            _container = container;
        }

        public IMapper GetMapper()
        {
            var mce = new MapperConfigurationExpression();
            mce.ConstructServicesUsing(_container.GetInstance);
            
            mce.AddProfiles(typeof(MapperProfile).Assembly);

            var mc = new MapperConfiguration(mce);

            IMapper m = new Mapper(mc, t => _container.GetInstance(t));

            return m;
        }

    }
}