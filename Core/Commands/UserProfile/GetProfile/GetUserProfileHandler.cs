using Core.Commands.Base;
using Core.Exceptions;
using Core.HttpClients;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.UserProfile.GetProfile
{
    public class GetUserProfileHandler : TelegramHandler<GetUserProfileRequest>
    {
        private readonly UsersApiClient apiClient;

        public GetUserProfileHandler(
            ILogger<TelegramHandler<GetUserProfileRequest>> logger, 
            ITelegramBotClient botClient,
            UsersApiClient apiClient) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(GetUserProfileRequest request, CancellationToken token)
        {
            var result = await apiClient.GetUserProfileAsync(request.ChatId);

            if (result?.Code != 0)
                throw new ApiException(result?.Message);

            await TgClient.SendTextMessageAsync(request.ChatId, result.Data);
        }
    }
}
