using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands.Notifications.GetNotifications
{
    public class GetNotificationsRequest : TelegramRequest
    {
        public GetNotificationsRequest(long chatId, UserState state) 
            : base(chatId, state)
        {
        }
    }
}
