using Core.Commands.Base;
using Core.Commands.UserProfile.MinimumFloor;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Core.Commands.UserProfile.ChangeMinimumFloor
{
    public class ChangeMinimumFloorCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState state)
        {
            if (update.Message.Text == CommandsName.UserProfile.ChangeMinimumFloor || state == UserState.ChangeMinimumFloor)
                return new ChangeMinimumFloorRequest(update.Message.Chat.Id, state, update.Message.Text);

            return default;
        }
    }
}
