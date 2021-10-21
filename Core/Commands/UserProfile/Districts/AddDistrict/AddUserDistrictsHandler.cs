using Core.Commands.Base;
using Core.Exceptions;
using Core.HttpClients;
using Core.Menus;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.UserProfile.Districts.AddDistrict
{
    public class AddUserDistrictsHandler : TelegramHandler<AddUserDistrictRequest>
    {
        private readonly DistrictsApiClient apiClient;
        private readonly DistrictsMenuCreator menuCreator;

        public AddUserDistrictsHandler(
            ILogger<TelegramHandler<AddUserDistrictRequest>> logger, 
            ITelegramBotClient botClient,
            DistrictsApiClient apiClient,
            DistrictsMenuCreator menuCreator) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
            this.menuCreator = menuCreator;
        }

        public override async Task HandleAsync(AddUserDistrictRequest request, CancellationToken token)
        {
            var result = await apiClient.AddUserDistrictsAsync(request.ChatId, request.DistrictName);

            if (result?.Code != 0)
                throw new ApiException(result?.Message);

            await TgClient.SendTextMessageAsync(request.ChatId, $"{request.DistrictName} включен в список", replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId));
        }
    }
}
