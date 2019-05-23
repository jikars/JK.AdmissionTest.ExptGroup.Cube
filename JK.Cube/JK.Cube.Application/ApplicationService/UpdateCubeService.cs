using AutoMapper;
using JK.Core.Architecture.DDD;
using JK.Core.Architecture.DDD.Persistence;
using JK.Core.Architecture.EDA;
using JK.Cube.Application.Commands;
using JK.Cube.Application.DomainEvents;
using System.Threading.Tasks;

namespace JK.Cube.Application.ApplicationService
{
    public class UpdatedCubeService : IApplicationService<UpdateCubeCommand>
    {
        private readonly IRepository<Domain.Models.Cube> _repository;
        private readonly IDispatcher _dispatcher;

        public UpdatedCubeService(IRepository<Domain.Models.Cube> repository, IDispatcher dispatcher)
        {
            _repository = repository;
            _dispatcher = dispatcher;
        }

        public Task<bool> Handle(UpdateCubeCommand command)
        {
            if (!string.IsNullOrEmpty(command.Id))
            {
                var cube = _repository.GetById(command.Id);
                if (cube != null)
                {
                    cube.Update(Mapper.Map<Domain.ValueObjects.Coordenate>(command.Coordenate),command.Value);
                    cube = _repository.Update(cube);
                    if(cube != null)
                    {
                        var cubeUpdatedEvent = Mapper.Map<CubeUpdated>(cube);
                        _dispatcher.Dispatch(cubeUpdatedEvent);
                        return Task.FromResult(true);
                    }
                }
            }
            return Task.FromResult(false);
        }
    }
}
