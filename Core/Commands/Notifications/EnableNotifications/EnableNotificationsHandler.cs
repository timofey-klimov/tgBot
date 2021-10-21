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

namespace Core.Commands.Notifications.EnableNotifications
{
    public class EnableNotificationsHandler : TelegramHandler<EnableNotificationsRequest>
    {
        private readonly NotificationApiClient apiClient;
        private readonly EnableNotificationsMenuCreator menuCreator;

        public EnableNotificationsHandler(
            ILogger<TelegramHandler<EnableNotificationsRequest>> logger, 
            ITelegramBotClient botClient,
            NotificationApiClient apiClient, 
            EnableNotificationsMenuCreator menuCreator) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
            this.menuCreator = menuCreator;
        }

        public override async Task HandleAsync(EnableNotificationsRequest request, CancellationToken token)
        {
            var result = await apiClient.EnableNotificationsAsync(request.ChatId);

            if (result?.Code != 0)
                throw new ApiException(result?.Message);

            await TgClient.SendTextMessageAsync(request.ChatId, Strings.Notifications.Enable, replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId));
        }
    }
}
