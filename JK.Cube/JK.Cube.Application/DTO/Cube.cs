using System.Collections.Generic;

namespace JK.Cube.Application.DTO
{
    public class Cube
    {
        public string Id { get; set; }

        public int XLenght { get; set; }

        public int YLenght { get; set; }

        public int ZLenght { get; set; }

        public Dictionary<Coordenate, long> Nodes { get; set; }
    }
}
