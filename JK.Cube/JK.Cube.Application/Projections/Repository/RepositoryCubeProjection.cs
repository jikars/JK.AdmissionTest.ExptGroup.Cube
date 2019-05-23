using JK.Core.Architecture.CQRS;
using JK.Cube.Application.Projections.Repository.Config;
using LiteDB;
using System.Collections.Generic;

namespace JK.Cube.Application.Projections.Repository
{
    public class RepositoryCubeProjection : IRepository<CubeProjection>
    {
        private readonly LiteDbProjectionConfig _config;
        public RepositoryCubeProjection(LiteDbProjectionConfig config)
        {
            _config = config;
        }

        public bool Delete(string id)
        {
            using (var db = new LiteDatabase(_config.ConnectionString))
            {
                return db.GetCollection<CubeProjection>().Delete(it => it.Id == id) > 0;
            }
        }

        public IEnumerable<CubeProjection> GetAll()
        {
            using (var db = new LiteDatabase(_config.ConnectionString))
            {
                return db.GetCollection<CubeProjection>().FindAll();
            }
        }

        public CubeProjection GetById(string id)
        {
            using (var db = new LiteDatabase(_config.ConnectionString))
            {
                return db.GetCollection<CubeProjection>().FindById(id);
            }
        }

        public CubeProjection Insert(CubeProjection porjection)
        {
            using (var db = new LiteDatabase(_config.ConnectionString))
            {
                db.GetCollection<CubeProjection>().Insert(porjection);
                return GetById(porjection.Id);
            }
        }

        public CubeProjection Update(CubeProjection porjection)
        {
            using (var db = new LiteDatabase(_config.ConnectionString))
            {
                db.GetCollection<CubeProjection>().Update(porjection);
                return GetById(porjection.Id);
            }
        }
    }
}
