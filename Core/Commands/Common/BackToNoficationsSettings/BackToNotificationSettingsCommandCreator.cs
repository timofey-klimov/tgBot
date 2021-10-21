using Core.Commands.Base;
using Core.Models;
using Telegram.Bot.Types;

namespace Core.Commands.Common.BackToNoficationsSettings
{
    public class BackToNotificationSettingsCommandCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState state)
        {
            if (update.Message.Text == CommandsName.Back.BackToNotificationSettings)
                return new BackToNotificationSettingsRequest(update.Message.Chat.Id, state);

            return default;
        }
    }
}
