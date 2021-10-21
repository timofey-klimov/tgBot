using Core.Commands.Base;
using Core.HttpClients;
using Core.Menus;
using Core.Models;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.Common.BackToNoficationsSettings
{
    public class BacToNotificationSettingsHandler : TelegramHandler<BackToNotificationSettingsRequest>
    {
        private readonly UsersApiClient apiClient;
        private readonly NotificationSettingsMenuCreator menuCreator;

        public BacToNotificationSettingsHandler(
            ILogger<TelegramHandler<BackToNotificationSettingsRequest>> logger, 
            ITelegramBotClient botClient,
            UsersApiClient apiClient,
            NotificationSettingsMenuCreator menuCreator) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
            this.menuCreator = menuCreator;
        }

        public override async Task HandleAsync(BackToNotificationSettingsRequest request, CancellationToken token)
        {
            await apiClient.ChangeUserStateAsync(request.ChatId, UserState.NotificationSettings);

            await TgClient.SendTextMessageAsync(request.ChatId, Strings.Back.BackToNotificationSettings, replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId));
        }
    }
}
