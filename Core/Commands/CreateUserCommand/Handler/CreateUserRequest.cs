using Core.Commands.Base;
using Core.Models;

namespace Core.Commands.CreateUserCommand.Handler
{
    public class CreateUserRequest : TelegramRequest
    {
        public string UserName { get; }

        public CreateUserRequest(long chatId, string userName, UserState userState) 
            : base(chatId, userState)
        {
            UserName = userName;
        }
    }
}
