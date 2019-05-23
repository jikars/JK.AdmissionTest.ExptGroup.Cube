using JK.Core.Architecture.CQRS;
using JK.Core.Architecture.DDD;
using JK.Core.Architecture.IoC;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JK.Cube.Api.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        public async Task<bool> SendCommand<T>(T command ) where T : ICommand
        {
            var applicationService = IoC.GetInstance().Resolve<IApplicationService<T>>();
            return await applicationService.Handle(command);
        }

        public IEnumerable<TProjection> QueryGetAll<TCondition,TProjection,TResult>() 
            where TProjection : IProjection where TCondition : ICondition
        {
            var query = IoC.GetInstance().Resolve<IQuery<TCondition, TProjection, TResult>>();
            return query.GetAll();
        }
        public TProjection QueryGetById<TCondition, TProjection, TResult>(string id)
           where TProjection : IProjection where TCondition : ICondition
        {
            var query = IoC.GetInstance().Resolve<IQuery<TCondition, TProjection, TResult>>();
            return query.GetById(id);
        }
        public TResult QueryGetCondition<TCondition, TProjection, TResult>(TCondition condition)
        where TProjection : IProjection where TCondition : ICondition
        {
            var query = IoC.GetInstance().Resolve<IQuery<TCondition, TProjection, TResult>>();
            return query.GetCondition(condition);
        }
    }
}
