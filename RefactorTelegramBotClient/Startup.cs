using Core.CommandsManager;
using Core.Extensions;
using Core.JsonConverters;
using Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Telegram.Bot;

namespace RefactorTelegramBotClient
{
    public class Startup
    {
        private IConfiguration _cfg;
        public Startup(IConfiguration configuration)
        {
            _cfg = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.Converters.Add(new MemoryStreamConverter()));

            services.RegisterTelegramCommandCreators();
            services.RegisterMenuCreators();
            services.RegisterClients(_cfg);
            services.RegisterMediatorDi();

            services.AddSingleton<ITelegramBotClient>(x =>
            {
                return new TelegramBotClient(_cfg.GetSection("Key").Get<string>());
            });


            services.AddSingleton<MessageHandlerService>();
            services.AddSingleton<CommandsCreatorManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ITelegramBotClient telegramBotClient, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(x =>
            {
                x.MapControllers();
            });

            try
            {
                var appUrl = _cfg.GetSection("AppUrl").Get<string>();
                telegramBotClient.SetWebhookAsync($"{appUrl}/api/bot").Wait();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}
