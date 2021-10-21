using Core.Commands.Base;
using Core.Exceptions;
using Core.HttpClients;
using Core.Menus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.UserProfile.Districts.RemoveDistrict
{
    public class RemoveUserDistictHandler : TelegramHandler<RemoveUserDistrictRequest>
    {
        private readonly DistrictsApiClient apiClient;
        private readonly DistrictsMenuCreator menuCreator;

        public RemoveUserDistictHandler(
            ILogger<TelegramHandler<RemoveUserDistrictRequest>> logger, 
            ITelegramBotClient botClient,
            DistrictsApiClient apiClient,
            DistrictsMenuCreator menuCreator) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
            this.menuCreator = menuCreator;
        }

        public override async Task HandleAsync(RemoveUserDistrictRequest request, CancellationToken token)
        {
            var result = await apiClient.RemoveUserDistrictAsync(request.ChatId, request.DistrictName);

            if (result?.Code != 0)
                throw new ApiException(result?.Message);

            await TgClient.SendTextMessageAsync(request.ChatId, $"{request.DistrictName} исключен из поиска", replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId));
        }
    }
}
