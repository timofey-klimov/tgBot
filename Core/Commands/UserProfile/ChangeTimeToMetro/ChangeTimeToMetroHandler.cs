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

namespace Core.Commands.UserProfile.ChangeTimeToMetro
{
    public class ChangeTimeToMetroHandler : TelegramHandler<ChangeTimeToMetroRequest>
    {
        private readonly UsersApiClient apiClient;

        public ChangeTimeToMetroHandler(
            ILogger<TelegramHandler<ChangeTimeToMetroRequest>> logger, 
            ITelegramBotClient botClient,
            UsersApiClient apiClient) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(ChangeTimeToMetroRequest request, CancellationToken token)
        {
            if (request.State == Models.UserState.ChangeTimeToMetro)
            {
                if (!int.TryParse(request.TimeToMetro, out var time))
                {
                    await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeTimeToMetro.InvalidFormat);
                    return;
                }

                if (time < 0)
                {
                    await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeTimeToMetro.InvalidValue);
                    return;
                }

                await apiClient.ChangeTimeToMetroAsync(request.ChatId, time);
                await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.ProfileSettings);
                await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeTimeToMetro.Ok);
            }
            else
            {
                await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.ChangeTimeToMetro);
                await TgClient.SendTextMessageAsync(request.ChatId, Strings.ChangeTimeToMetro.Title);
            }
        }
    }
}
