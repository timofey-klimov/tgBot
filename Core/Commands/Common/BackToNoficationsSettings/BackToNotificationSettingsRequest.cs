using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands.Common.BackToNoficationsSettings
{
    public class BackToNotificationSettingsRequest : TelegramRequest
    {
        public BackToNotificationSettingsRequest(long chatId, UserState state) : base(chatId, state)
        {
        }
    }
}
