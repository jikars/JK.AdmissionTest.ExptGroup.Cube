using JK.Core.Architecture.DDD;

namespace JK.Cube.Domain.ValueObjects
{
    public class Coordenate : IValueObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
