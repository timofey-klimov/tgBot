using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;
using WebApp.Dto;

namespace WebApp.Controllers
{
    [Route("api/notify")]
    public class NotificationController : ControllerBase
    {
        private readonly ITelegramBotClient telegramBotClient;
        private readonly ILogger<NotificationController> logger;

        public NotificationController(
            ITelegramBotClient telegramBotClient,
            ILogger<NotificationController> logger)
        {
            this.telegramBotClient = telegramBotClient;
            this.logger = logger;
        }

        [HttpPost("{chatId}/new/messages")]
        public async Task HandleNewMessageNotification([FromBody] NotificationMessageDto message, long chatId)
        {
            logger.LogInformation("New notification");
            await telegramBotClient.SendTextMessageAsync(chatId, message.Message);
        }

        [HttpPost("{chatId}/new/objects")]
        public async Task HandleNewObjectsNotification([FromBody] NotificationObjectsDto message, long chatId)
        {
            logger.LogInformation("New notification");

            foreach (var item in message?.Messages)
            {
                if (item.HasImage)
                    await telegramBotClient.SendPhotoAsync(chatId, new InputOnlineFile(new MemoryStream(item.Image)), caption: item.Message);
                else
                    await telegramBotClient.SendTextMessageAsync(chatId, item.Message);
            }
        }
    }
}
