using Core.Commands;
using Core.Exceptions;
using Core.HttpClients;
using Core.Menu.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Core.Menus
{
    public class NotificationSettingsMenuCreator : BaseMenuCreator
    {
        private readonly UsersApiClient apiClient;

        public NotificationSettingsMenuCreator(UsersApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public override async Task<IReplyMarkup> CreateMenuAsync(long chatId)
        {
            var result = await apiClient.GetUserAsync(chatId);

            if (result?.Code != 0)
                throw new ApiException(result?.Message);

            var keyBoard = new List<List<KeyboardButton>>();

            if (result.Data.IsActive)
                keyBoard.Add(new List<KeyboardButton> { new KeyboardButton($"{CommandsName.Notifications.Disable}") });
            else
                keyBoard.Add(new List<KeyboardButton> { new KeyboardButton($"{CommandsName.Notifications.Enable}") });

            keyBoard.Add(new List<KeyboardButton>() { new KeyboardButton($"{CommandsName.Notifications.SelectNotificationType}") });
            keyBoard.Add(new List<KeyboardButton>() { new KeyboardButton($"{CommandsName.Back.BackToMainMenu}") });

            return new ReplyKeyboardMarkup
            {
                Keyboard = keyBoard,
                ResizeKeyboard = true
            };
        }
    }
}
