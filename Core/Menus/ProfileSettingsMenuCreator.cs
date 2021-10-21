using Core.Commands;
using Core.Menu.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Core.Menus
{
    public class ProfileSettingsMenuCreator : BaseMenuCreator
    {
        public override async Task<IReplyMarkup> CreateMenuAsync(long chatId)
        {
            var keyBoard = new List<List<KeyboardButton>>();

            keyBoard.Add(new List<KeyboardButton>() { new KeyboardButton($"{CommandsName.UserProfile.ChangeMaxixmumPrice}"), new KeyboardButton($"{CommandsName.UserProfile.ChangeMinimumPrice}") });
            keyBoard.Add(new List<KeyboardButton>() { new KeyboardButton($"{CommandsName.UserProfile.Districts}"), new KeyboardButton($"{CommandsName.UserProfile.ChangeMinimumFloor}") });
            keyBoard.Add(new List<KeyboardButton>() { new KeyboardButton($"{CommandsName.UserProfile.ChangeTimeToMetro}"), new KeyboardButton($"{CommandsName.Back.BackToMainMenu}") });

            var replyMarkUp = new ReplyKeyboardMarkup
            {
                Keyboard = keyBoard,
                ResizeKeyboard = true
            };

            return replyMarkUp;
        }
    }
}
