using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public partial class CommandsName
    {
        public static class Back
        {
            public static string BackToMainMenu => "Назад в главное меню";

            public static string BackToProfileSettings => "Назад к настройкам профиля";

            public static string BackToNotificationSettings => "Назад к настройкам уведомлений";

        }
    }
}
