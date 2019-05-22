using JK.Core.Architecture.DDD.Persistence;
using JK.Core.Architecture.IoC;
using JK.Core.Architecture.IoC.Interface;
using JK.Core.Architecture.IoC.Model;
using JK.Cube.Infrastructure;
using JK.Cube.Infrastructure.DbLite;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var type = typeof(ControllerBase);
            var typesController = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface)?.ToList();

            typesController?.ForEach(it => {
                var module = Module.RegisterType(it, it,it.Name);
                modules.Add(module);
            });

            return modules;
        }
    }
}
