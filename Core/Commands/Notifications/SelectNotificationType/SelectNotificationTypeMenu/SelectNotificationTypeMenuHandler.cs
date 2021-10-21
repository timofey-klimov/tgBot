using Core.Commands.Base;
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

namespace Core.Commands.Notifications.SelectNotificationType.SelectNotificationTypeMenu
{
    public class SelectNotificationTypeMenuHandler : TelegramHandler<SelectNotificationTypeMenuRequest>
    {
        private readonly UsersApiClient apiClient;
        private readonly SelectNotificationTypeMenuCreator menuCreator;

        public SelectNotificationTypeMenuHandler(
            ILogger<TelegramHandler<SelectNotificationTypeMenuRequest>> logger, 
            ITelegramBotClient botClient,
            UsersApiClient apiClient,
            SelectNotificationTypeMenuCreator menuCreator) 
            : base(logger, botClient)
        {
            this.apiClient = apiClient;
            this.menuCreator = menuCreator;
        }

        public override async Task HandleAsync(SelectNotificationTypeMenuRequest request, CancellationToken token)
        {
            await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.NotificationTypeSettings);

            await TgClient.SendTextMessageAsync(request.ChatId, Strings.SelectNotificationType.Title, replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId));
        }
    }
}
