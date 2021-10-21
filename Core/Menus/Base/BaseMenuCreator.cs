using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Core.Menu.Base
{
    public abstract class BaseMenuCreator
    {
        public abstract Task<IReplyMarkup> CreateMenuAsync(long chatId);
    }
}
