using Core.Commands.Base;
using Core.HttpClients;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.UserProfile.ChangeMaximumPrice
{
    public class ChangeMaximumPriceHandler : TelegramHandler<ChangeMaximumPriceRequest>
    {
        private readonly UsersApiClient apiClient;

        public ChangeMaximumPriceHandler(
            ILogger<TelegramHandler<ChangeMaximumPriceRequest>> logger, 
            ITelegramBotClient botClient,
            UsersApiClient apiClient) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(ChangeMaximumPriceRequest request, CancellationToken token)
        {
            if (request.State == Models.UserState.ChangeMaximumPrice)
            {
                if (!decimal.TryParse(request.Price, out var price))
                {
                    await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeMaximumPrice.InvalidFormat);
                    return;
                }

                if (price < 0)
                {
                    await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeMaximumPrice.InvalidValue);
                    return;
                }

                await apiClient.ChangeMaximumPriceAsync(request.ChatId, price);
                await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.ProfileSettings);
                await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeMaximumPrice.Ok);
            }
            else
            {
                await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.ChangeMaximumPrice);
                await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeMaximumPrice.Title);
            }
        }
    }
}
