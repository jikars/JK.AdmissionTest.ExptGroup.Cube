namespace JK.Core.Architecture.EDA
{
    public interface IDispatcher
    {
        void Dispatch<T>(T @event) where T: IDomainEvent;
    }
}
