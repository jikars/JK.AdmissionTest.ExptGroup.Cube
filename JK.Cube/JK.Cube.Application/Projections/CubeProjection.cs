using JK.Core.Architecture.CQRS;
using System.Collections.Generic;

namespace JK.Cube.Application.Projections
{
    public class CubeProjection : IProjection
    {
        public string Id { get; set; }

        public int XLenght { get; set; }

        public int YLenght { get; set; }

        public int ZLenght { get; set; }

        public Dictionary<CoordenateProjection, long> Nodes { get; set; }
    }
}
