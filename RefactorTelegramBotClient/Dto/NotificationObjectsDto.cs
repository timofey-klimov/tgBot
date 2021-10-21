using Core.HttpClients.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Dto
{
    public class NotificationObjectsDto
    {
        public ICollection<NotificationDto> Messages { get; set; }
    }
}
