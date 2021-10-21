using Core.Commands.Base;
using Core.Models;
using Telegram.Bot.Types;

namespace Core.Commands.UserProfile.ChangeMinimumPrice
{
    public class ChangeMinimumPriceCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState state)
        {
            if (update.Message.Text == CommandsName.UserProfile.ChangeMinimumPrice || state == UserState.ChangeMinimumPrice)
                return new ChangeMinimumPriceRequest(update.Message.Chat.Id, state, update.Message.Text);

            return default;
        }
    }
}
