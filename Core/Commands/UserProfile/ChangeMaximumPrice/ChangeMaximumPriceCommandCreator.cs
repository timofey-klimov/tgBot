using Core.Commands.Base;
using Core.Models;
using Telegram.Bot.Types;

namespace Core.Commands.UserProfile.ChangeMaximumPrice
{
    public class ChangeMaximumPriceCommandCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState userState)
        {
            if (update.Message.Text == CommandsName.UserProfile.ChangeMaxixmumPrice || userState == UserState.ChangeMaximumPrice)
                return new ChangeMaximumPriceRequest(update.Message.Chat.Id, update.Message.Text, userState);

            return default;
        }
    }
}
