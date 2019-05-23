using System.Collections.Generic;
using AutoMapper;
using JK.Core.Architecture.CQRS;
using JK.Cube.Application.Projections;
using JK.Cube.Application.Queries.Condtions;

namespace JK.Cube.Application.Queries
{
    public class CubeQueryProjection : IQuery<CubeQueryCondition,CubeProjection,long>
    {
        private readonly IRepository<CubeProjection> _repository;
        public CubeQueryProjection(IRepository<CubeProjection> repository)
        {
            _repository = repository;
        }
        public IEnumerable<CubeProjection> GetAll()
        {
            return _repository.GetAll();
        }

        public CubeProjection GetById(string id)
        {
            return _repository.GetById(id);
        }

        public long GetCondition(CubeQueryCondition condition)
        {
            var cubeProjection = _repository.GetById(condition.Id);
            if(cubeProjection != null)
            {
                var cube = Mapper.Map<Domain.Models.Cube>(cubeProjection);
                return cube?.Query(Mapper.Map<Domain.ValueObjects.Coordenate>(condition.Coordenate1), Mapper.Map<Domain.ValueObjects.Coordenate>(condition.Coordenate2)) ?? 0;
            }
            return 0;
        }
    }
}
