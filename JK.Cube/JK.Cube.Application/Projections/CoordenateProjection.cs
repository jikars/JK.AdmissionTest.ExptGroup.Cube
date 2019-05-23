using JK.Core.Architecture.CQRS;

namespace JK.Cube.Application.Projections
{
    public class CoordenateProjection : IProjection
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
