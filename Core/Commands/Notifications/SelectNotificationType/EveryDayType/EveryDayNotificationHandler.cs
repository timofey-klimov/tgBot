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

namespace Core.Commands.Notifications.SelectNotificationType.EveryDayType
{
    public class EveryDayNotificationHandler : TelegramHandler<EveryDayNotificationRequest>
    {
        private readonly NotificationApiClient apiClient;

        public EveryDayNotificationHandler(
            ILogger<TelegramHandler<EveryDayNotificationRequest>> logger, 
            ITelegramBotClient botClient,
            NotificationApiClient apiClient) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(EveryDayNotificationRequest request, CancellationToken token)
        {
            var result = await apiClient.ChangeNotificationTypeAsync(request.ChatId, Models.NotificationType.EveryDay);

            if (result?.Code != 0)
                throw new ApiException(result?.Message);

            await TgClient.SendTextMessageAsync(request.ChatId, Strings.SelectNotificationType.EveryDay);
        }
    }
}
