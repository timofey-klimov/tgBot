using Core.Commands.Base;
using Core.Exceptions;
using Core.HttpClients;
using Core.Menu;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.CreateUserCommand.Handler
{
    public class CreateUserHandler : TelegramHandler<CreateUserRequest>
    {
        private readonly UsersApiClient usersApi;
        private readonly MainMenuCreator menuCreator;

        public CreateUserHandler(
            ILogger<TelegramHandler<CreateUserRequest>> logger, 
            ITelegramBotClient botClient,
            UsersApiClient usersApi,
            MainMenuCreator menuCreator) 
            : base(logger, botClient)
        {
            this.usersApi = usersApi;
            this.menuCreator = menuCreator;
        }

        public override async Task HandleAsync(CreateUserRequest request, CancellationToken token)
        {
            var result = await usersApi.CreateUserAsync(request.ChatId, request.UserName);

            if (result.Code != 0)
                throw new ApiException(result.Message);

            await TgClient.SendTextMessageAsync(request.ChatId, Strings.CreateNewUser.Title, replyMarkup: await menuCreator.CreateMenuAsync(request.ChatId));
        }
    }
}
