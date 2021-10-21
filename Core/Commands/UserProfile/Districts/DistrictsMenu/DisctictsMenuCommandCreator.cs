using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Core.Commands.UserProfile.Districts.DistrictsMenu
{
    public class DisctictsMenuCommandCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState state)
        {
            if (update.Message.Text == CommandsName.UserProfile.Districts)
                return new DistrictsMenuRequest(update.Message.Chat.Id, state);

            return default;
        }
    }
}
