using Core.Models;
using MediatR;

namespace Core.Commands.Base
{
    public abstract class TelegramRequest : IRequest
    {
        public long ChatId { get; }

        public UserState State { get; }

        public TelegramRequest(long chatId, UserState state)
        {
            ChatId = chatId;
            State = state;
        }
    }
}
