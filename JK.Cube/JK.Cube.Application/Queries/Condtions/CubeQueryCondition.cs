using JK.Core.Architecture.CQRS;
using JK.Cube.Application.DTO;

namespace JK.Cube.Application.Queries.Condtions
{
    public class CubeQueryCondition : ICondition
    {
        public string Id { get; set; }
        public Coordenate Coordenate1 { get; set; }
        public Coordenate Coordenate2 { get; set; }

    }
}
