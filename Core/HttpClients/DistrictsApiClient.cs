using Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.HttpClients
{
    public class DistrictsApiClient : BaseApiClient
    {
        public DistrictsApiClient(string baseUrl) 
            : base(baseUrl)
        {
        }

        public async Task<ApiResponse<ICollection<DistrictDto>>> GetUserDistrictsAsync(long chatId)
        {
            var url = $"districts/{chatId}";

            return await GetAsync<ICollection<DistrictDto>>(url);
        }

        public async Task<ApiResponse> AddUserDistrictsAsync(long chatId, string district)
        {
            var url = $"districts/add/{chatId}";

            var body = new { Name = district };

            return await PostAsync(url, body);
        }

        public async Task<ApiResponse> RemoveUserDistrictAsync(long chatId, string district)
        {
            var url = $"districts/remove/{chatId}";

            var body = new { Name = district };

            return await PostAsync(url, body);
        }

        public async Task<ApiResponse<ICollection<DistrictDto>>> GetDistrictsAsync()
        {
            var url = $"districts";

            return await GetAsync<ICollection<DistrictDto>>(url);
        }
    }
}
