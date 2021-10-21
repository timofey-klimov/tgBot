using Core.Commands.Base;
using Core.HttpClients;
using Core.Menus;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.Common.BackToProfileSettings
{
    public class BackToProfileSettingsHandler : TelegramHandler<BackToProfileSettingsRequest>
    {
        private readonly ProfileSettingsMenuCreator menuCreator;
        private readonly UsersApiClient apiClient;

        public BackToProfileSettingsHandler(
            ILogger<TelegramHandler<BackToProfileSettingsRequest>> logger, 
            ITelegramBotClient botClient,
            ProfileSettingsMenuCreator menuCreator,
            UsersApiClient apiClient) 
            : base(logger, botClient)
        {
            this.menuCreator = menuCreator;
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(BackToProfileSettingsRequest request, CancellationToken token)
        {
            await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.ProfileSettings);

            await TgClient.SendTextMessageAsync(request.ChatId, Strings.Back.BackToProfileSettings, replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId));
        }
    }
}
