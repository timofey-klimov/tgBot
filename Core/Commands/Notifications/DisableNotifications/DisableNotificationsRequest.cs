using Core.Commands.Base;
using Core.Models;

namespace Core.Commands.Notifications.DisableNotifications
{
    public class DisableNotificationsRequest : TelegramRequest
    {
        public DisableNotificationsRequest(long chatId, UserState state) 
            : base(chatId, state)
        {
        }
    }
}
