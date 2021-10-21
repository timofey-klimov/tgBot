using Core.Commands.Base;
using Core.HttpClients;
using Core.Menu;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.Common.BackToMainMenu
{
    public class BackToMainMenuHandler : TelegramHandler<BackToMainMenuRequest>
    {
        private readonly MainMenuCreator menuCreator;
        private readonly UsersApiClient apiClient;

        public BackToMainMenuHandler(ILogger<TelegramHandler<BackToMainMenuRequest>> logger, 
            ITelegramBotClient botClient,
            MainMenuCreator menuCreator,
            UsersApiClient apiClient) 
            : base(logger, botClient)
        {
            this.menuCreator = menuCreator;
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(BackToMainMenuRequest request, CancellationToken token)
        {
            await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.MainMenu);

            await TgClient.SendTextMessageAsync(request.ChatId, Strings.Back.BackToMainMenu, replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId), cancellationToken: token);
        }
    }
}
