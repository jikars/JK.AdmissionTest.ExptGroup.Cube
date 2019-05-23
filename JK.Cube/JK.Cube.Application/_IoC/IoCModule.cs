using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JK.Core.Architecture.CQRS;
using JK.Core.Architecture.DDD;
using JK.Core.Architecture.DDD.Handlers;
using JK.Core.Architecture.EDA;
using JK.Core.Architecture.IoC;
using JK.Core.Architecture.IoC.Interface;
using JK.Cube.Application.Projections;
using JK.Cube.Application.Queries;
using JK.Cube.Application.Queries.Condtions;
using Module = JK.Core.Architecture.IoC.Model.Module;

namespace JK.Cube.Application._IoC
{
    public class IoCModule : IModuleIoC
    {
        public List<Module> Register()
        {
            List<Module> modules = new List<Module>();
            var typeCommandHablder = typeof(ICommandHandler<>);
            var typeEventHandler = typeof(IEventHandler<>);
            var typeRepositoryProjection = typeof(IRepository<>);
            var typeApplicationService = typeof(IApplicationService<>);
            var typesController = Assembly.GetExecutingAssembly().GetTypes().Where(p => (typeEventHandler.IsAssignableFrom(p) || 
            typeCommandHablder.IsAssignableFrom(p) || typeRepositoryProjection.IsAssignableFrom(p)
            || typeApplicationService.IsAssignableFrom(p)) && !p.IsAbstract && !p.IsInterface)?.ToList();

            typesController?.ForEach(it => {
                var module = Module.RegisterType(it.BaseType, it, it.Name);
                modules.Add(module);
            });

            IoC.GetInstance().RegisterType<IQuery<CubeQueryCondition, CubeProjection, long>,CubeQueryProjection>();

            return modules;
        }
    }
}
