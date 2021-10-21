using Core.Commands.Base;
using Core.Exceptions;
using Core.HttpClients;
using Core.Menus;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.Notifications.DisableNotifications
{
    public class DisableNotificationsHandler : TelegramHandler<DisableNotificationsRequest>
    {
        private readonly DisableNotificationsMenuCreator menuCreator;
        private readonly NotificationApiClient apiClient;

        public DisableNotificationsHandler(
            ILogger<TelegramHandler<DisableNotificationsRequest>> logger,
            ITelegramBotClient botClient,
            DisableNotificationsMenuCreator menuCreator,
            NotificationApiClient apiClient) 
            : base(logger, botClient)
        {
            this.menuCreator = menuCreator;
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(DisableNotificationsRequest request, CancellationToken token)
        {
            var result = await apiClient.DisableNotificationsAsync(request.ChatId);

            if (result?.Code != 0)
                throw new ApiException(result?.Message);

            await TgClient.SendTextMessageAsync(request.ChatId, Strings.Notifications.Disable, replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId));
        }
    }
}
