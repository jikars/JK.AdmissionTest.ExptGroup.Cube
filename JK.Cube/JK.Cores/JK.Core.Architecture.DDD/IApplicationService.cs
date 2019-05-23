using JK.Core.Architecture.DDD.Handlers;

namespace JK.Core.Architecture.DDD
{
    public interface IApplicationService<in TCommand> : ICommandHandler<TCommand>
                where TCommand : ICommand
    {
    }
}
