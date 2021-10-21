using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Core.Commands.UserProfile.ChangeTimeToMetro
{
    public class ChangeTimeToMetroCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState state)
        {
            if (update.Message.Text == CommandsName.UserProfile.ChangeTimeToMetro || state == UserState.ChangeTimeToMetro)
                return new ChangeTimeToMetroRequest(update.Message.Chat.Id, state, update.Message.Text);

            return default;
        }
    }
}
