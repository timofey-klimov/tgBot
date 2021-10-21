using Core.Commands.Base;
using Core.Models;

namespace Core.Commands.UserProfile.ChangeMinimumPrice
{
    public class ChangeMinimumPriceRequest : TelegramRequest
    {
        public string Price { get; }
        public ChangeMinimumPriceRequest(long chatId, UserState state, string price) 
            : base(chatId, state)
        {
            Price = price;
        }
    }
}
