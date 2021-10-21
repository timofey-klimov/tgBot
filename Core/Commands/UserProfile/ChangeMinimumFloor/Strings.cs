using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public partial class Strings
    {
        public static class ChangeMinimumFloor
        {
            public static string InvalidFormat => "Неверный формат. Попробуйте еще раз";

            public static string InvalidValue => "Значение должно быть больше 0";

            public static string Ok => "Минимальный этаж установлен";

            public static string Title => "Введите минимальный этаж для поиска";
        }
    }
}
