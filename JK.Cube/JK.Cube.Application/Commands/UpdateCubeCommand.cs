using JK.Core.Architecture.DDD;
using JK.Cube.Application.DTO;

namespace JK.Cube.Application.Commands
{
    public class UpdateCubeCommand : ICommand
    {
        public string Id { get; set; }
        public Coordenate Coordenate { get; set; }
        public long Value { get; set; }

    }
}
