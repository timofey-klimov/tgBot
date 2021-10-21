using Core.Commands;
using Core.Menu.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Core.Menus
{
    public class EnableNotificationsMenuCreator : BaseMenuCreator
    {
        public override async Task<IReplyMarkup> CreateMenuAsync(long chatId)
        {
            var keyBoard = new List<List<KeyboardButton>>();

            keyBoard.Add(new List<KeyboardButton>() { new KeyboardButton($"{CommandsName.Notifications.Disable}") });

            keyBoard.Add(new List<KeyboardButton>() { new KeyboardButton($"{CommandsName.Notifications.SelectNotificationType}") });

            keyBoard.Add(new List<KeyboardButton>() { new KeyboardButton($"{CommandsName.Back.BackToMainMenu}") });

            return new ReplyKeyboardMarkup()
            {
                Keyboard = keyBoard,
                ResizeKeyboard = true
            };
        }
    }
}
