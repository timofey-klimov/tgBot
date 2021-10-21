using Core.HttpClients.Dto;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.HttpClients
{
    public class NotificationApiClient : BaseApiClient
    {
        public NotificationApiClient(string baseUrl) : base(baseUrl)
        {
        }

        public async Task<ApiResponse> EnableNotificationsAsync(long chatId)
        {
            var url = $"notify/{chatId}/enable";

            return await PutAsync(url, default);
        }

        public async Task<ApiResponse> DisableNotificationsAsync(long chatId)
        {
            var url = $"notify/{chatId}/disable";

            return await PutAsync(url, default);
        }

        public async Task<ApiResponse> ChangeNotificationTypeAsync(long chatId, NotificationType notificationType)
        {
            var url = $"notify/change-type/{chatId}";

            var body = new { Type = notificationType };

            return await PostAsync(url, body);
        }

        public async Task<ApiResponse<string>> GetTelegramNotificationAsMesssageAsync(long chatId)
        {
            var url = $"notify/telegram/{chatId}/messages";

            return await GetAsync<string>(url);
        }

        public async Task<ApiResponse<ICollection<NotificationDto>>> GetTelegramNotificationAsObjectAsync(long chatId)
        {
            var url = $"notify/telegram/{chatId}/objects";

            return await GetAsync<ICollection<NotificationDto>>(url);
        }
    }
}
