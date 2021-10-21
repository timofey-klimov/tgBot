using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Core.Commands.Notifications.Menu
{
    public class NotificationMenuCommandCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState state)
        {
            if (update.Message.Text == CommandsName.Notifications.Settings)
                return new NotificationsMenuRequest(update.Message.Chat.Id, state);

            return default;
        }
    }
}
