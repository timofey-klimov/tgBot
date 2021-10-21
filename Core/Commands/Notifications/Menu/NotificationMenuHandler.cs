using Core.Commands.Base;
using Core.HttpClients;
using Core.Menus;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.Notifications.Menu
{
    public class NotificationMenuHandler : TelegramHandler<NotificationsMenuRequest>
    {
        private readonly NotificationSettingsMenuCreator menuCreator;
        private readonly UsersApiClient apiClient;

        public NotificationMenuHandler(
            ILogger<TelegramHandler<NotificationsMenuRequest>> logger, 
            ITelegramBotClient botClient,
            NotificationSettingsMenuCreator menuCreator,
            UsersApiClient apiClient) 
            : base(logger, botClient)
        {
            this.menuCreator = menuCreator;
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(NotificationsMenuRequest request, CancellationToken token)
        {
            await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.NotificationSettings);

            await TgClient.SendTextMessageAsync(request.ChatId, Strings.Notifications.Title, replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId));
        }
    }
}
