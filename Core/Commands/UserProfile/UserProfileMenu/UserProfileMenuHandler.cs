using Core.Commands.Base;
using Core.HttpClients;
using Core.Menus;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.UserProfile.UserProfileMenu
{
    public class UserProfileMenuHandler : TelegramHandler<UserProfileMenuRequest>
    {
        private readonly ProfileSettingsMenuCreator menuCreator;
        private readonly UsersApiClient apiClient;

        public UserProfileMenuHandler(
            ILogger<TelegramHandler<UserProfileMenuRequest>> logger, 
            ITelegramBotClient botClient,
            ProfileSettingsMenuCreator menuCreator,
            UsersApiClient apiClient) 
            : base(logger, botClient)
        {
            this.menuCreator = menuCreator;
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(UserProfileMenuRequest request, CancellationToken token)
        {
            await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.ProfileSettings);
            await TgClient.SendTextMessageAsync(request.ChatId, Strings.UserProfileMenu.Title, replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId));
        }
    }
}
