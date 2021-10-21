using Core.Commands.Base;
using Core.Models;

namespace Core.Commands.UserProfile.ChangeTimeToMetro
{
    public class ChangeTimeToMetroRequest : TelegramRequest
    {
        public string TimeToMetro { get; }
        public ChangeTimeToMetroRequest(long chatId, UserState state, string timeToMetro) 
            : base(chatId, state)
        {
            TimeToMetro = timeToMetro;
        }
    }
}
