using PubQuizOrganizerFrontend.Enums;
using PubQuizOrganizerFrontend.Models.Dto.RatingHistory;
using PubQuizOrganizerFrontend.Models.Dto.UserDto;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        private readonly string BasePath = "user";

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<UserBriefDto>> GetAll()
            => await _http.GetFromJsonAsync<IEnumerable<UserBriefDto>>($"{BasePath}")
               ?? Enumerable.Empty<UserBriefDto>();

        public async Task<UserBriefDto?> GetById(int id)
            => await _http.GetFromJsonAsync<UserBriefDto>($"{BasePath}/{id}");

        public async Task<UserBriefDto?> Update(UserDto user)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}", user);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<UserBriefDto>()
                : null;
        }

        public async Task Delete(int id)
            => await _http.DeleteAsync($"{BasePath}/{id}");

        public async Task<IEnumerable<UserBriefDto>> Search(string? username = null, string? sortBy = null, bool descending = false, int limit = 25)
        {
            var query = $"{BasePath}/search?" +
                        $"username={Uri.EscapeDataString(username ?? string.Empty)}&" +
                        $"sortBy={Uri.EscapeDataString(sortBy ?? string.Empty)}&" +
                        $"descending={descending}&" +
                        $"limit={limit}";

            return await _http.GetFromJsonAsync<IEnumerable<UserBriefDto>>(query)
                   ?? Enumerable.Empty<UserBriefDto>();
        }

        public async Task<UserDetailedDto?> GetDetailedById(int id) =>
            await _http.GetFromJsonAsync<UserDetailedDto>($"{BasePath}/detailed/{id}");

        public async Task<List<RatingHistoryDto>> GetRatingHistories(int id, TimePeriod timePeriod) =>
            await _http.GetFromJsonAsync<List<RatingHistoryDto>>($"{BasePath}/rating-history/{id}/{timePeriod}")
            ?? new List<RatingHistoryDto>();
    }
}
