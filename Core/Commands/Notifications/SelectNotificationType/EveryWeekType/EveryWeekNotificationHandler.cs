using Core.Commands.Base;
using Core.Exceptions;
using Core.HttpClients;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.Notifications.SelectNotificationType.EveryWeekType
{
    public class EveryWeekNotificationHandler : TelegramHandler<EveryWeekNotificationRequest>
    {
        private readonly NotificationApiClient apiClient;

        public EveryWeekNotificationHandler(
            ILogger<TelegramHandler<EveryWeekNotificationRequest>> logger, 
            ITelegramBotClient botClient,
            NotificationApiClient apiClient) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(EveryWeekNotificationRequest request, CancellationToken token)
        {
            var result = await apiClient.ChangeNotificationTypeAsync(request.ChatId, Models.NotificationType.EveryWeek);

            if (result?.Code != 0)
                throw new ApiException(result?.Message);

            await TgClient.SendTextMessageAsync(request.ChatId, Strings.SelectNotificationType.EveryWeek);
        }
    }
}
