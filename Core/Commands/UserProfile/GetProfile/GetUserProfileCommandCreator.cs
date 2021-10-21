using Core.Commands.Base;
using Core.Models;
using Telegram.Bot.Types;

namespace Core.Commands.UserProfile.GetProfile
{
    public class GetUserProfileCommandCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState state)
        {
            if (update.Message.Text == CommandsName.UserProfile.LookupProfile)
                return new GetUserProfileRequest(update.Message.Chat.Id, state);

            return default;
        }
    }
}
