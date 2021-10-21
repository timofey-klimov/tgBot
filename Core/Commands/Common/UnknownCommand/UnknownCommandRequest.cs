using Core.Commands.Base;
using Core.Models;

namespace Core.Commands.Common.UnknownCommand
{
    public class UnknownCommandRequest : TelegramRequest
    {
        public UnknownCommandRequest(long chatId, UserState state) 
            : base(chatId, state)
        {
        }
    }
}
