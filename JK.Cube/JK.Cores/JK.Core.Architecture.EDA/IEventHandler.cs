namespace JK.Core.Architecture.EDA
{
    public interface IEventHandler<in TDomainEvent> where TDomainEvent: IDomainEvent
    {
        void Handle(TDomainEvent @event);
    }
}
