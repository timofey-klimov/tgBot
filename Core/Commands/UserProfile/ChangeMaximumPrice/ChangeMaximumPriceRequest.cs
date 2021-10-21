using Core.Commands.Base;
using Core.Models;

namespace Core.Commands.UserProfile.ChangeMaximumPrice
{
    public class ChangeMaximumPriceRequest : TelegramRequest
    {
        public string Price { get; }
        public ChangeMaximumPriceRequest(long chatId, string price, UserState userState) 
            : base(chatId, userState)
        {
            Price = price;
        }
    }
}
