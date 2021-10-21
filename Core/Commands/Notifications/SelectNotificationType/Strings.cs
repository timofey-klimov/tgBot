using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public partial class Strings
    {
        public static class SelectNotificationType
        {
            public static string Title => "Выбери как часто отправлять новые квартиры :)";

            public static string ASAP => "Объявления будут отправляться по обнаружению";

            public static string EveryDay => "Объявления будут оправляться раз в день";

            public static string EveryWeek => "Объявления будут отправляться раз в неделю";
        }
    }
}
