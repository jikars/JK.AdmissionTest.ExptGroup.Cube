using JK.Core.Architecture.EDA;
using JK.Cube.Application.DTO;
using System.Collections.Generic;

namespace JK.Cube.Application.DomainEvents
{
    public class CubeCreated : IDomainEvent
    {
        public string Id { get; set; }

        public int XLenght { get; set; }

        public int YLenght { get; set; }

        public int ZLenght { get; set; }

        public Dictionary<Coordenate, long> Nodes { get; set; }
    }
}
