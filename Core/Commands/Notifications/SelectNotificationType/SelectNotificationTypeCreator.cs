using Core.Commands.Base;
using Core.Commands.Notifications.SelectNotificationType.DefaultType;
using Core.Commands.Notifications.SelectNotificationType.EveryDayType;
using Core.Commands.Notifications.SelectNotificationType.EveryWeekType;
using Core.Models;
using Telegram.Bot.Types;

namespace Core.Commands.Notifications.SelectNotificationType
{
    public class SelectNotificationTypeCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState state)
        {
            if (update.Message.Text == CommandsName.Notifications.SelectASAP)
                return new DefaultNotificationTypeRequest(update.Message.Chat.Id, state);


            if (update.Message.Text == CommandsName.Notifications.SelectOneTimeInDay)
                return new EveryDayNotificationRequest(update.Message.Chat.Id, state);

            if (update.Message.Text == CommandsName.Notifications.SelectOneTimeInWeek)
                return new EveryWeekNotificationRequest(update.Message.Chat.Id, state);

            return default;
        }
    }
}
