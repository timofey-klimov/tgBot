using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands.Notifications.SelectNotificationType.EveryDayType
{
    public class EveryDayNotificationRequest : TelegramRequest
    {
        public EveryDayNotificationRequest(long chatId, UserState state) : base(chatId, state)
        {
        }
    }
}
