using JK.Core.Architecture.EDA;

namespace JK.Cube.Application.DomainEvents
{
    public class CubeDeleted : IDomainEvent
    {
        public string Id { get; set; }
    }
}
