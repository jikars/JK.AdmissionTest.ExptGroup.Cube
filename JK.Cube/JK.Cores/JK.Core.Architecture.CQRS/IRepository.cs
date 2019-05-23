using System.Collections.Generic;

namespace JK.Core.Architecture.CQRS
{
    public interface IRepository<TProjection> where TProjection : IProjection
    {
        TProjection Insert(TProjection porjection);
        TProjection Update(TProjection porjection);
        bool Delete(string id);
        TProjection GetById(string id);
        IEnumerable<TProjection> GetAll();
    }
}
