using AutoMapper;
using JK.Core.Architecture.DDD;
using JK.Core.Architecture.DDD.Persistence;
using JK.Core.Architecture.EDA;
using JK.Cube.Application.Commands;
using JK.Cube.Application.DomainEvents;
using System.Threading.Tasks;

namespace JK.Cube.Application.ApplicationService
{
    public class CubeQueryService : IApplicationService<CreateCubeCommand>
    {
        private readonly IRepository<Domain.Models.Cube> _repository;
        private readonly IDispatcher _dispatcher;

        public CubeQueryService(IRepository<Domain.Models.Cube> repository, IDispatcher dispatcher)
        {
            _repository = repository;
            _dispatcher = dispatcher;
        }

        public Task<bool> Handle(CreateCubeCommand command)
        {
            if(command != null)
            {
                var cube = new Domain.Models.Cube();
                cube.GenerateCube(command.Size);
                cube = _repository.Insert(cube);
                if (cube != null)
                {
                    var cubeCreatedEvent = Mapper.Map<CubeCreated>(cube);
                    _dispatcher.Dispatch(cubeCreatedEvent);
                    return Task.FromResult(true);
                }
            }
            return Task.FromResult(false);
        }
    }
}
