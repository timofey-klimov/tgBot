using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands.UserProfile.UserProfileMenu
{
    public class UserProfileMenuRequest : TelegramRequest
    {
        public UserProfileMenuRequest(long chatId, UserState userState)
            : base(chatId, userState)
        {

        }
    }
}
