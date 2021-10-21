using Core.Commands;
using Core.Commands.Common.UnknownCommand;
using Core.Commands.CreateUserCommand.Handler;
using Core.CommandsManager;
using Core.HttpClients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Core.Services
{
    public class MessageHandlerService
    {
        private readonly IMediator mediator;
        private readonly UsersApiClient apiclient;
        private readonly CommandsCreatorManager manager;
        private readonly ITelegramBotClient telegramBotClient;

        public MessageHandlerService(
            IMediator mediator,
            UsersApiClient apiclient,
            CommandsCreatorManager manager,
            ITelegramBotClient telegramBotClient
            )
        {
            this.mediator = mediator;
            this.apiclient = apiclient;
            this.manager = manager;
            this.telegramBotClient = telegramBotClient;
        }

        public async Task HandleMessageAsync(Update update)
        {
            var chatId = update?.Message?.Chat?.Id;

            if (chatId == default)
            {
                return;
            }

            var message = update?.Message?.Text;

            if (message == null)
            {
                await telegramBotClient.SendTextMessageAsync(chatId, Strings.Error.Messsage);
                return;
            }

            if (message == "/start")
            {
                var command = new CreateUserRequest(chatId.Value, update.Message.From?.Username ?? "Unknown", Models.UserState.MainMenu);
                await mediator.Send(command);
                return;
            }

            var result = await apiclient.GetUserStateAsync(chatId.Value);

            if (result.Code != 0)
            {
                await telegramBotClient.SendTextMessageAsync(chatId, Strings.Error.Messsage);
                return;
            }

            var creators = manager.GetCreators();

            foreach (var creator in creators)
            {
                var command = creator.CreateCommand(update, result.Data);

                if (command != null)
                {
                    await mediator.Send(command);
                    return;
                }

            }

            await mediator.Send(new UnknownCommandRequest(chatId.Value, result.Data));
        }
    }
}
