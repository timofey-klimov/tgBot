using Core.Commands.Base;
using Core.Commands.CreateUserCommand.Handler;
using Core.Models;
using Telegram.Bot.Types;

namespace Core.Commands.CreateUserCommand
{
    public class CreateUserCommandCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState userState)
        {
            if (update.Message.Text == CommandsName.CreateNewUser.Name)
                return new CreateUserRequest(update.Message.Chat.Id, update.Message.Chat?.Username ?? "Unknown", userState);

            return default;
        }
    }
}
