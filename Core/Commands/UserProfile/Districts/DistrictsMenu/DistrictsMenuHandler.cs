using Core.Commands.Base;
using Core.HttpClients;
using Core.Menus;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.UserProfile.Districts.DistrictsMenu
{
    public class DistrictsMenuHandler : TelegramHandler<DistrictsMenuRequest>
    {
        private readonly DistrictsMenuCreator menuCreator;
        private readonly UsersApiClient apiClient;

        public DistrictsMenuHandler(
            ILogger<TelegramHandler<DistrictsMenuRequest>> logger, 
            ITelegramBotClient botClient,
            DistrictsMenuCreator menuCreator,
            UsersApiClient apiClient) 
            : base(logger, botClient)
        {
            this.menuCreator = menuCreator;
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(DistrictsMenuRequest request, CancellationToken token)
        {
            await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.UpdateDistricts);
            await TgClient.SendTextMessageAsync(request.ChatId, Strings.Districts.Title, replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId), cancellationToken: token);
        }
    }
}
