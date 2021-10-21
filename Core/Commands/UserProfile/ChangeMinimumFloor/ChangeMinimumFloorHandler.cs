using Core.Commands.Base;
using Core.HttpClients;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.UserProfile.MinimumFloor
{
    public class ChangeMinimumFloorHandler : TelegramHandler<ChangeMinimumFloorRequest>
    {
        private readonly UsersApiClient apiClient;

        public ChangeMinimumFloorHandler(
            ILogger<TelegramHandler<ChangeMinimumFloorRequest>> logger, 
            ITelegramBotClient botClient,
            UsersApiClient apiClient) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(ChangeMinimumFloorRequest request, CancellationToken token)
        {
            if (request.State == Models.UserState.ChangeMinimumFloor)
            {
                if (!int.TryParse(request.Floor, out var floor))
                {
                    await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeMinimumFloor.InvalidFormat);
                    return;
                }

                if (floor < 0)
                {
                    await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeMinimumFloor.InvalidValue);
                    return;
                }

                await apiClient.ChangeMinimumFloor(request.ChatId, floor);
                await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.ProfileSettings);
                await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeMinimumFloor.Ok);
            }
            else
            {
                await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.ChangeMinimumFloor);
                await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeMinimumFloor.Title);
            }
        }
    }
}
