using Core.CommandsManager;
using Core.HttpClients;
using Core.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace WebApp.Controllers
{
    [Route("api/bot")]
    public class BotController : ControllerBase
    {
        private readonly MessageHandlerService messageHandler;

        public BotController(MessageHandlerService messageHandler)
        {
            this.messageHandler = messageHandler;
        }

        [HttpGet]
        public string Get() => "Ok";

        [HttpPost]
        public async Task Update([FromBody] Update update, CancellationToken token)
        {
            await messageHandler.HandleMessageAsync(update);
        }
    }
}
