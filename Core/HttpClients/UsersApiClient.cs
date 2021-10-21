using Core.Models;
using Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.HttpClients
{
    public class UsersApiClient : BaseApiClient
    {
        public UsersApiClient(string baseUrl)
            : base(baseUrl)
        {
        }

        public async Task<ApiResponse> CreateUserAsync(long chatId, string userName)
        {
            var url = $"user/{chatId}/{userName}/create";
            return await PostAsync(url, default);
        }

        public async Task<ApiResponse> ChangeMinimumPriceAsync(long chatId, decimal price)
        {
            var url = $"user/{chatId}/{price}/minimum-price";

            return await PutAsync(url, default);
        }

        public async Task<ApiResponse> ChangeMaximumPriceAsync(long chatId, decimal price)
        {
            var url = $"user/{chatId}/{price}/maximum-price";

            return await PutAsync(url, default);
        }

        public async Task<ApiResponse> ChangeTimeToMetroAsync(long chatId, int time)
        {
            var url = $"user/{chatId}/{time}/set-time-to-metro";

            return await PostAsync(url, default);
        }

        public async Task<ApiResponse<string>> GetUserProfileAsync(long chatId)
        {
            var url = $"user/{chatId}/profile";

            return await GetAsync<string>(url);
        }

        public async Task<ApiResponse<UserDto>> GetUserAsync(long chatId)
        {
            var url = $"user/{chatId}";

            return await GetAsync<UserDto>(url);
        }

        public async Task<ApiResponse<UserState>> GetUserStateAsync(long chatId)
        {
            var url = $"user/state/{chatId}/get";

            return await GetAsync<UserState>(url);
        }

        public async Task<ApiResponse> ChangeUserStateAsync(long chatId, UserState userState)
        {
            var url = $"user/state/{chatId}/change";

            return await PostAsync(url, new { UserState = userState });
        }

        public async Task<ApiResponse> ChangeMinimumFloor(long chatId, int floor)
        {
            var url = $"user/{chatId}/{floor}/minimum-floor";

            return await PutAsync(url, default);
        }
    }
}
