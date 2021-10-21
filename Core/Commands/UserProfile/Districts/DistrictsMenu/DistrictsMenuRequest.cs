using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands.UserProfile.Districts.DistrictsMenu
{
    public class DistrictsMenuRequest : TelegramRequest
    {
        public DistrictsMenuRequest(long chatId, UserState state) 
            : base(chatId, state)
        {
        }
    }
}
