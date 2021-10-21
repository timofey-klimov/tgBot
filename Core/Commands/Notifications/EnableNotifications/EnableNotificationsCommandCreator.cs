using Core.Commands.Base;
using Core.Models;
using Telegram.Bot.Types;

namespace Core.Commands.Notifications.EnableNotifications
{
    public class EnableNotificationsCommandCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState state)
        {
            if (update.Message.Text == CommandsName.Notifications.Enable)
                return new EnableNotificationsRequest(update.Message.Chat.Id, state);

            return default;
        }
    }
}
