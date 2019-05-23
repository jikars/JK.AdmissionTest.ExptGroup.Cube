using System.Threading.Tasks;

namespace JK.Core.Architecture.DDD.Handlers
{
    public interface ICommandHandler<in TCommand>  where TCommand : ICommand
    { 
        Task<bool> Handle(TCommand command);
    }
}
