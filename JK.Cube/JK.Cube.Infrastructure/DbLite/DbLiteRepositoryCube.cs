using System;
using System.Collections.Generic;
using JK.Core.Architecture.DDD.Persistence;
using LiteDB;

namespace JK.Cube.Infrastructure.DbLite
{
    public class DbLiteRepositoryCube : IRepository<Domain.Models.Cube>
    {
        private readonly DbLiteConfig _dbLiteConfig;

        public DbLiteRepositoryCube(DbLiteConfig dbLiteConfig)
        {
            _dbLiteConfig = dbLiteConfig;
        }

        public bool Delete(string id)
        {
            using (var db = new LiteDatabase(_dbLiteConfig.ConnectioString))
            {
                return db.GetCollection<Domain.Models.Cube>().Delete(it => it.Id == id) > 0;
            }
        }

        public IEnumerable<Domain.Models.Cube> GetAll()
        {
            using (var db = new LiteDatabase(_dbLiteConfig.ConnectioString))
            {
                return db.GetCollection<Domain.Models.Cube>().FindAll();
            }
        }

        public Domain.Models.Cube GetById(string id)
        {
            using (var db = new LiteDatabase(_dbLiteConfig.ConnectioString))
            {
                return db.GetCollection<Domain.Models.Cube>().FindById(id);
            }
        }
    
        public Domain.Models.Cube Insert(Domain.Models.Cube aggregateRoot)
        {
            using (var db = new LiteDatabase(_dbLiteConfig.ConnectioString))
            {
                db.GetCollection<Domain.Models.Cube>().Insert(aggregateRoot);
                return GetById(aggregateRoot.Id);
            }
        }

        public Domain.Models.Cube Update(Domain.Models.Cube aggregateRoot)
        {
            using (var db = new LiteDatabase(_dbLiteConfig.ConnectioString))
            {
                db.GetCollection<Domain.Models.Cube>().Update(aggregateRoot);
                return GetById(aggregateRoot.Id);
            }
        }
    }
}
