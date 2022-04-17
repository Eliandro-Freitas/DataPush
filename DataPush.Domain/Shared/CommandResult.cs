using Flunt.Notifications;

namespace DataPush.Domain.Shared
{
    public abstract class CommandResult : Notifiable
    {
        public object Response { get; set; }

        public void Merge(CommandResult from)
        {
            AddNotifications(from.Notifications);
            Response = from.Response;
        }

        public virtual bool Validate() => Valid;
    }
}