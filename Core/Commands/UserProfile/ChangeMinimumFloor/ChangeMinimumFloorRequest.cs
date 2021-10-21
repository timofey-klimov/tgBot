using Core.Commands.Base;
using Core.Models;

namespace Core.Commands.UserProfile.MinimumFloor
{
    public class ChangeMinimumFloorRequest : TelegramRequest
    {
        public string Floor { get; }
        public ChangeMinimumFloorRequest(long chatId, UserState state, string floor) 
            : base(chatId, state)
        {
            Floor = floor;
        }
    }
}
