using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands.Notifications.SelectNotificationType.EveryWeekType
{
    public class EveryWeekNotificationRequest : TelegramRequest
    {
        public EveryWeekNotificationRequest(long chatId, UserState state) : base(chatId, state)
        {
        }
    }
}
