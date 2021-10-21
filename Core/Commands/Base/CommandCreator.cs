using Core.Models;
using Telegram.Bot.Types;

namespace Core.Commands.Base
{
    public abstract class CommandCreator
    {
        public abstract TelegramRequest CreateCommand(Update update, UserState state);
    }
}
