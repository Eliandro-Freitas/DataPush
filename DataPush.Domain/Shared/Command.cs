using Flunt.Notifications;
using MediatR;

namespace DataPush.Domain.Shared
{
    public abstract class Command<TCommandResult> : Notifiable, IRequest<TCommandResult>
        where TCommandResult : CommandResult
    {
        public abstract bool Validate();
    }
}
