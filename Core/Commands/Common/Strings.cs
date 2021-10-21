using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands
{
    public partial class Strings
    {
        public static class Error
        {
            public static string Messsage => "Произошла ошибка :( \n Попробуйте позже";
        }

        public static class Back
        {
            public static string BackToMainMenu => "Главное меню";

            public static string BackToProfileSettings => "Настройки профиля";

            public static string BackToNotificationSettings => "Настройка уведомлений";
        }
    }
}
