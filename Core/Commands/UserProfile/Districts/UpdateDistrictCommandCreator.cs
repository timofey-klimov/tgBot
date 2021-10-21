using Core.Commands.Base;
using Core.Commands.UserProfile.Districts.AddDistrict;
using Core.Commands.UserProfile.Districts.RemoveDistrict;
using Core.Models;
using System.Linq;
using Telegram.Bot.Types;

namespace Core.Commands.UserProfile.Districts
{
    public class UpdateDistrictCommandCreator : CommandCreator
    {
        public override TelegramRequest CreateCommand(Update update, UserState state)
        {
            var message = update?.Message;
            if (message.Text?.StartsWith("ЦАО") == true)
            {
                switch (message.Text.Split(':').ElementAt(1))
                {
                    case "Да":
                        return new RemoveUserDistrictRequest(message.Chat.Id, state, "ЦАО");
                    case "Нет":
                        return new AddUserDistrictRequest(message.Chat.Id, state, "ЦАО");
                }
            }

            if (message.Text?.StartsWith("СВАО") == true)
            {
                switch (message.Text.Split(':').ElementAt(1))
                {
                    case "Да":
                        return new RemoveUserDistrictRequest(message.Chat.Id, state, "СВАО");
                    case "Нет":
                        return new AddUserDistrictRequest(message.Chat.Id, state, "СВАО");
                }
            }

            if (message.Text?.StartsWith("СЗАО") == true)
            {
                switch (message.Text.Split(':').ElementAt(1))
                {
                    case "Да":
                        return new RemoveUserDistrictRequest(message.Chat.Id, state, "СЗАО");
                    case "Нет":
                        return new AddUserDistrictRequest(message.Chat.Id, state, "СЗАО");
                }
            }

            if (message.Text?.StartsWith("ЮАО") == true)
            {
                switch (message.Text.Split(':').ElementAt(1))
                {
                    case "Да":
                        return new RemoveUserDistrictRequest(message.Chat.Id, state, "ЮАО");
                    case "Нет":
                        return new AddUserDistrictRequest(message.Chat.Id, state, "ЮАО");
                }
            }

            if (message.Text?.StartsWith("ЗАО") == true)
            {
                switch (message.Text.Split(':').ElementAt(1))
                {
                    case "Да":
                        return new RemoveUserDistrictRequest(message.Chat.Id, state, "ЗАО");
                    case "Нет":
                        return new AddUserDistrictRequest(message.Chat.Id, state, "ЗАО");
                }
            }

            if (message.Text?.StartsWith("САО") == true)
            {
                switch (message.Text.Split(':').ElementAt(1))
                {
                    case "Да":
                        return new RemoveUserDistrictRequest(message.Chat.Id, state, "САО");
                    case "Нет":
                        return new AddUserDistrictRequest(message.Chat.Id, state, "САО");
                }
            }

            if (message.Text?.StartsWith("ВАО") == true)
            {
                switch (message.Text.Split(':').ElementAt(1))
                {
                    case "Да":
                        return new RemoveUserDistrictRequest(message.Chat.Id, state, "ВАО");
                    case "Нет":
                        return new AddUserDistrictRequest(message.Chat.Id, state, "ВАО");
                }
            }

            if (message.Text?.StartsWith("ЮВАО") == true)
            {
                switch (message.Text.Split(':').ElementAt(1))
                {
                    case "Да":
                        return new RemoveUserDistrictRequest(message.Chat.Id, state, "ЮВАО");
                    case "Нет":
                        return new AddUserDistrictRequest(message.Chat.Id, state, "ЮВАО");
                }
            }

            if (message.Text?.StartsWith("ЮЗАО") == true)
            {
                switch (message.Text.Split(':').ElementAt(1))
                {
                    case "Да":
                        return new RemoveUserDistrictRequest(message.Chat.Id, state, "ЮЗАО");
                    case "Нет":
                        return new AddUserDistrictRequest(message.Chat.Id, state, "ЮЗАО");
                }
            }

            return default;
        }
    }
}
