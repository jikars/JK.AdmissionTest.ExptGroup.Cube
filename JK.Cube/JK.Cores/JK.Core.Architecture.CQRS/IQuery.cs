using System.Collections.Generic;

namespace JK.Core.Architecture.CQRS
{
    public interface IQuery<in TCondition, out TProjection, out TResult> where TProjection : IProjection where TCondition : ICondition
    {
        TProjection GetById(string id);
        IEnumerable<TProjection> GetAll();
        TResult GetCondition(TCondition condition);
    }
}
