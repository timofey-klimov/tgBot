using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public partial class Strings
    {
        public static class ChangeMinimumPrice
        {
            public static string InvalidFormat => "Неверный формат";

            public static string InvalidValue => "Цена должна быть больше 0";

            public static string Ok => "Минимальная цена установлена";

            public static string Title => "Введите минимальную цену для поиска";
        }
    }
}
