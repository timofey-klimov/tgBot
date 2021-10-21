using System.Collections.Generic;
using System.IO;

namespace Core.HttpClients.Dto
{
    public class NotificationDto
    {
        public string Message { get; set; }

        public byte[] Image { get; set; }

        public bool HasImage { get; set; }
    }
}
