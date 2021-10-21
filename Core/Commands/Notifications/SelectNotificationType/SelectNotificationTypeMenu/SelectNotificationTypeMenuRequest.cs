using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands.Notifications.SelectNotificationType.SelectNotificationTypeMenu
{
    public class SelectNotificationTypeMenuRequest : TelegramRequest
    {
        public SelectNotificationTypeMenuRequest(long chatId, UserState state) 
            : base(chatId, state)
        {
        }
    }
}
