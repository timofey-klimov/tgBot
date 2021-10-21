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
    public class SelectNotificationTypeMenuCreator : BaseMenuCreator
    {
        public override async Task<IReplyMarkup> CreateMenuAsync(long chatId)
        {
            var keyBoard = new List<List<KeyboardButton>>();

            keyBoard.Add(new List<KeyboardButton>() { new KeyboardButton($"{CommandsName.Notifications.SelectASAP}"), new KeyboardButton($"{CommandsName.Notifications.SelectOneTimeInDay}") });
            keyBoard.Add(new List<KeyboardButton>() { new KeyboardButton($"{CommandsName.Notifications.SelectOneTimeInWeek}"), new KeyboardButton($"{CommandsName.Back.BackToNotificationSettings}") });

            return new ReplyKeyboardMarkup()
            {
                Keyboard = keyBoard,
                ResizeKeyboard = true
            };
        }
    }
}
