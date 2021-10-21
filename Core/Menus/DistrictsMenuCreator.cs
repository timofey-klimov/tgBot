using Core.Commands;
using Core.Exceptions;
using Core.HttpClients;
using Core.Menu.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Core.Menus
{
    public class DistrictsMenuCreator : BaseMenuCreator
    {
        private readonly DistrictsApiClient apiClient;

        public DistrictsMenuCreator(DistrictsApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public override async Task<IReplyMarkup> CreateMenuAsync(long chatId)
        {
            var result = await apiClient.GetUserDistrictsAsync(chatId);

            if (result?.Code != 0)
                throw new ApiException(result?.Message);

            var keyBoard = new List<List<KeyboardButton>>();

            var chunkSize = 3;

            var chunks = (int)Math.Round((double)result.Data.Count / chunkSize);

            for (int i = 0; i < chunks; i++)
            {
                var districts = result.Data.Skip(i * chunkSize).Take(chunkSize);

                var list = new List<KeyboardButton>();

                keyBoard.Add(districts.Select(x => new KeyboardButton($"{x.Name}:" + (x.IsSelected == true ? "Да" : "Нет"))).ToList());
            }

            keyBoard.Add(new List<KeyboardButton>() { new KeyboardButton($"{CommandsName.Back.BackToProfileSettings}") });

            var replyMarkUp = new ReplyKeyboardMarkup()
            {
                Keyboard = keyBoard,
                ResizeKeyboard = true
            };
            return replyMarkUp; 
        }
    }
}
