using JK.Core.Architecture.DDD;

namespace JK.Cube.Application.Commands
{
    public class CreateCubeCommand : ICommand
    {
        public int Size { get; set; }
    }
}
