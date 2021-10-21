using Core.Commands.Base;
using Core.HttpClients;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.UserProfile.ChangeMinimumPrice
{
    public class ChangeMinimumPriceHandler : TelegramHandler<ChangeMinimumPriceRequest>
    {
        private readonly UsersApiClient apiClient;

        public ChangeMinimumPriceHandler(
            ILogger<TelegramHandler<ChangeMinimumPriceRequest>> logger, 
            ITelegramBotClient botClient,
            UsersApiClient apiClient) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(ChangeMinimumPriceRequest request, CancellationToken token)
        {
            if (request.State == Models.UserState.ChangeMinimumPrice)
            {
                if (!decimal.TryParse(request.Price, out var price))
                {
                    await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeMinimumPrice.InvalidFormat);
                    return;
                }

                if (price < 0)
                {
                    await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeMinimumPrice.InvalidValue);
                    return;
                }

                await apiClient.ChangeMinimumPriceAsync(request.ChatId, price);
                await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.ProfileSettings);
                await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeMinimumPrice.Ok);
            }
            else
            {
                await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.ChangeMinimumPrice);
                await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeMinimumPrice.Title);
            }
        }
    }
}
