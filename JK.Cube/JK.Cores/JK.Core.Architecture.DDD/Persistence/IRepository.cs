using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JK.Core.Architecture.DDD.Persistence
{
    public interface IRepository<TAggregateRoot>  where TAggregateRoot : IAggregateRoot
    {
        TAggregateRoot Insert(TAggregateRoot aggregateRoot);
        TAggregateRoot Update(TAggregateRoot aggregateRoot);
        bool Delete(string id);
        TAggregateRoot GetById(string id);
        IEnumerable<TAggregateRoot> GetAll();
    }
}
