using JK.Core.Architecture.IoC.Interface;

namespace JK.Core.Architecture.EDA.Implementation
{
    public class Dispatcher : IDispatcher
    {
        private readonly IContainer _container;

        public Dispatcher(IContainer container)
        {
            _container = container;
        }

        public void Dispatch<T>(T @event) where T : IDomainEvent
        {
            var types =  _container.ResolveAll<IEventHandler<T>>();
            foreach (var type in types)
            {
                type.Handle(@event);
            }
        }
    }
}
