using AutoMapper;
using JK.Core.Architecture.CQRS;
using JK.Core.Architecture.EDA;
using JK.Cube.Application.DomainEvents;
using JK.Cube.Application.Projections;

namespace JK.Cube.Application.DomainEventHandlers
{
    public class CubeDesnormalizerHandler : IEventHandler<CubeCreated>, IEventHandler<CubeDeleted>, IEventHandler<CubeUpdated>
    {
        private readonly IRepository<CubeProjection> _repository;
        public CubeDesnormalizerHandler(IRepository<CubeProjection> repository)
        {
            _repository = repository;
        }

        public void Handle(CubeCreated @event)
        {
            _repository.Insert(Mapper.Map<CubeProjection>(@event));
        }

        public void Handle(CubeDeleted @event)
        {
            _repository.Delete(@event.Id);
        }

        public void Handle(CubeUpdated @event)
        {
            _repository.Update(Mapper.Map<CubeProjection>(@event));
        }
    }
}
