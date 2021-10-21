using Core.Commands.Base;
using Core.HttpClients;
using Core.Menu;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.Common.UnknownCommand
{
    public class UnknownCommandHandler : TelegramHandler<UnknownCommandRequest>
    {
        private readonly MainMenuCreator menuCreator;
        private readonly UsersApiClient apiClient;

        public UnknownCommandHandler(
            ILogger<TelegramHandler<UnknownCommandRequest>> logger, 
            ITelegramBotClient botClient,
            MainMenuCreator menuCreator,
            UsersApiClient apiClient) 
            : base(logger, botClient)
        {
            this.menuCreator = menuCreator;
            this.apiClient = apiClient;
        }

        public override async Task HandleAsync(UnknownCommandRequest request, CancellationToken token)
        {
            await apiClient.ChangeUserStateAsync(request.ChatId, Models.UserState.MainMenu);

            await TgClient.SendTextMessageAsync(request.ChatId, "Воспользуйся меню", replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId));
        }
    }
}
