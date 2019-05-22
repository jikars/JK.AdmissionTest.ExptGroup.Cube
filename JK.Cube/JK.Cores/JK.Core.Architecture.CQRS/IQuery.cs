using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JK.Core.Architecture.CQRS
{
    public interface IQuery<TProjection> where TProjection : IProjection
    {
        TProjection GetById(string id);
        IEnumerable<TProjection> GetByFillter(Expression<Func<TProjection, bool>> expression);
        TProjection GetFirts(Expression<Func<TProjection, bool>> expression);
    }
}
