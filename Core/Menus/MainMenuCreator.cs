using Core.Commands;
using Core.Commands.CreateUserCommand;
using Core.Menu.Base;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Core.Menu
{
    public class MainMenuCreator : BaseMenuCreator
    {
        public override async Task<IReplyMarkup> CreateMenuAsync(long chatId)
        {
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                   {
                        new[]
                        {
                            new KeyboardButton($"{CommandsName.UserProfile.Settings}")
                        },
                        new[]
                        {
                            new KeyboardButton($"{CommandsName.UserProfile.LookupProfile}")
                        },
                        new[]
                        {
                            new KeyboardButton($"{CommandsName.Notifications.Settings}")
                        },
                        new[]
                        {
                            new KeyboardButton($"{CommandsName.Notifications.GetNotifications}")
                        }
                    },
                ResizeKeyboard = true
            };

            return keyBoard;
        }
    }
}
