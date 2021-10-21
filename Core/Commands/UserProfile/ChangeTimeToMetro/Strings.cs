using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public partial class Strings
    {
        public static class ChangeTimeToMetro
        {
            public static string InvalidFormat => "Неверный формат, попробуйте еще раз";

            public static string InvalidValue => "Значение должно быть больше 0";

            public static string Ok => "Время до метро установлено";

            public static string Title => "Введите время до метро";
        }
    }
}
