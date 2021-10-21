using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Core.Commands.Base
{
    public abstract class TelegramHandler<T> : IRequestHandler<T>
        where T : TelegramRequest
    {
        protected ILogger<TelegramHandler<T>> Logger;
        protected ITelegramBotClient TgClient;

        public TelegramHandler(
            ILogger<TelegramHandler<T>> logger,
            ITelegramBotClient botClient)
        {
            Logger = logger;
            TgClient = botClient;
        }

        public async Task<Unit> Handle(T request, CancellationToken cancellationToken)
        {
            try
            {
                await HandleAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                await TgClient.SendTextMessageAsync(request.ChatId, "Произошла ошибка :(\nПопробуйте позже");
            }

            return Unit.Value;
        }

        public abstract Task HandleAsync(T request, CancellationToken token);
    }
}
