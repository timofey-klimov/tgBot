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

namespace Core.Commands.Notifications.SelectNotificationType.DefaultType
{
    public class DefaultNotificationTypeHandler : TelegramHandler<DefaultNotificationTypeRequest>
    {
        private readonly NotificationApiClient notificationApiClient;

        public DefaultNotificationTypeHandler(
            ILogger<TelegramHandler<DefaultNotificationTypeRequest>> logger, 
            ITelegramBotClient botClient,
            NotificationApiClient notificationApiClient) 
            : base(logger, botClient)
        {
            this.notificationApiClient = notificationApiClient;
        }

        public override async Task HandleAsync(DefaultNotificationTypeRequest request, CancellationToken token)
        {
            var result = await notificationApiClient.ChangeNotificationTypeAsync(request.ChatId, Models.NotificationType.Default);

            if (result?.Code != 0)
                throw new ApiException(result?.Message);

            await TgClient.SendTextMessageAsync(request.ChatId, Strings.SelectNotificationType.ASAP);
        }
    }
}
