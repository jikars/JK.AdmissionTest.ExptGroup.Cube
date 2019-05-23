using JK.Core.Architecture.DDD.Persistence;
using JK.Core.Architecture.EDA;
using JK.Core.Architecture.EDA.Implementation;
using JK.Core.Architecture.IoC;
using JK.Core.Architecture.IoC.Interface;
using JK.Cube.Api.Controllers;
using JK.Cube.Infrastructure;
using JK.Cube.Infrastructure.DbLite;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Module = JK.Core.Architecture.IoC.Model.Module;

namespace JK.Cube.Api._IoC
{
    public class IoCModule : IModuleIoC
    {
        public List<Module> Register()
        {
            List<Module> modules = new List<Module>()
            {
                Module.RegisterInstance(new DbLiteConfig{ ConnectioString = "gfdgfdfsfdsdsa"}),
                Module.RegisterType<IRepository<Domain.Models.Cube>,DbLiteRepositoryCube>()
            };
            var typeController = typeof(CustomControllerBase);
            var typesController = Assembly.GetEntryAssembly().GetTypes().Where(p => typeController.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface)?.ToList();

            typesController?.ForEach(it => {
                var module = Module.RegisterType(it, it,it.Name);
                modules.Add(module);
            });
            var typeaggregate = typeof(IRepository<>);

            var typesRepositoryAggregate = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => typeaggregate.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface)?.ToList();

            typesRepositoryAggregate?.ForEach(it => {
                var module = Module.RegisterType(it.BaseType, it, it.Name);
                modules.Add(module);
            });
            IoC.GetInstance().RegisterInstance(IoC.GetInstance());
            IoC.GetInstance().RegisterType<IDispatcher, Dispatcher>();
            return modules;
        }
    }
}
