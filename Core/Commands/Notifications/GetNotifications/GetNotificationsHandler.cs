using Core.Commands.Base;
using Core.Exceptions;
using Core.HttpClients;
using Core.HttpClients.Dto;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;

namespace Core.Commands.Notifications.GetNotifications
{
    public class GetNotificationsHandler : TelegramHandler<GetNotificationsRequest>
    {
        private readonly NotificationApiClient apiClient;

        public GetNotificationsHandler(
            ILogger<TelegramHandler<GetNotificationsRequest>> logger, 
            ITelegramBotClient botClient,
            NotificationApiClient apiClient) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(GetNotificationsRequest request, CancellationToken token)
        {
            var result = await apiClient.GetTelegramNotificationAsObjectAsync(request.ChatId);

            if (result?.Code != 0)
                throw new ApiException(result?.Message);

            foreach (var item in result.Data)
            {
                if (item.HasImage)
                    await TgClient.SendPhotoAsync(request.ChatId, new InputOnlineFile(new MemoryStream(item.Image)), caption: item.Message);
                else
                    await TgClient.SendTextMessageAsync(request.ChatId, item.Message);
            }
        }
    }
}
