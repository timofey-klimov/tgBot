using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands.Notifications.Menu
{
    public class NotificationsMenuRequest : TelegramRequest
    {
        public NotificationsMenuRequest(long chatId, UserState state) 
            : base(chatId, state)
        {
        }
    }
}
