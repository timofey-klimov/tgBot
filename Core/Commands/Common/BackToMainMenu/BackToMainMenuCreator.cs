using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Core.Commands.Common.BackToMainMenu
{
    public class BackToMainMenuCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState state)
        {
            if (update.Message.Text == CommandsName.Back.BackToMainMenu)
                return new BackToMainMenuRequest(update.Message.Chat.Id, state);

            return default;
        }
    }
}
