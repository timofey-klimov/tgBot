using Core.Commands.Base;
using Core.Models;
using Telegram.Bot.Types;

namespace Core.Commands.UserProfile.UserProfileMenu
{
    public class UserProfileCommandCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState userState)
        {
            if (update.Message.Text == CommandsName.UserProfile.Settings)
                return new UserProfileMenuRequest(update.Message.Chat.Id, userState);

            return default;
        }
    }
}
