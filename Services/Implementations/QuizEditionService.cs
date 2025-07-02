using Newtonsoft.Json.Linq;
using PubQuizOrganizerFrontend.Enums;
using PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class QuizEditionService : IQuizEditionService
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "edition/";

        public QuizEditionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(IEnumerable<QuizEditionMinimalDto> Items, int TotalCount)> GetAllPage(int page, int pageSize, EditionFilter filter)
        {
            var url = $"{BasePath}paged/all?page={page}&pageSize={pageSize}&filter={filter}";

            using var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var items = await response.Content.ReadFromJsonAsync<List<QuizEditionMinimalDto>>() ?? new List<QuizEditionMinimalDto>();

            int totalCount = 0;

            if (response.Headers.TryGetValues("X-Total-Count", out var values))
                _ = int.TryParse(values.FirstOrDefault(), out totalCount);

            return (items, totalCount);
        }

        public async Task<(IEnumerable<QuizEditionMinimalDto> Items, int TotalCount)> GetUpcomingPage(int page, int pageSize, EditionFilter filter)
        {
            var url = $"{BasePath}paged/upcoming?page={page}&pageSize={pageSize}&filter={filter}";

            using var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var items = await response.Content.ReadFromJsonAsync<List<QuizEditionMinimalDto>>() ?? new List<QuizEditionMinimalDto>();

            int totalCount = 0;

            if (response.Headers.TryGetValues("X-Total-Count", out var values))
                _ = int.TryParse(values.FirstOrDefault(), out totalCount);

            return (items, totalCount);
        }

        public async Task<(IEnumerable<QuizEditionMinimalDto> Items, int TotalCount)> GetCompletedPage(int page, int pageSize, EditionFilter filter)
        {
            var url = $"{BasePath}paged/completed?page={page}&pageSize={pageSize}&filter={filter}";
            
            using var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var items = await response.Content.ReadFromJsonAsync<List<QuizEditionMinimalDto>>() ?? new List<QuizEditionMinimalDto>();

            int totalCount = 0;

            if (response.Headers.TryGetValues("X-Total-Count", out var values))
                _ = int.TryParse(values.FirstOrDefault(), out totalCount);

            return (items, totalCount);
        }

        public async Task<QuizEditionDetailedDto> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"edition/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to fetch edition.");

            var json = await response.Content.ReadAsStringAsync();

            var jObject = JObject.Parse(json);

            var time = jObject["time"]?.ToObject<DateTime>();

            if (time.HasValue && time.Value < DateTime.UtcNow)
            {
                return jObject.ToObject<PastQuizEditionDetailedDto>()!;
            }
            else
            {
                return jObject.ToObject<QuizEditionDetailedDto>()!;
            }
        }
    }
}
