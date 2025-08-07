using PubQuizOrganizerFrontend.Models.Dto.QuizLeagueDto;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class QuizLeagueService : IQuizLeagueService
    {
        private readonly HttpClient _http;
        private readonly string BasePath = "league";

        public QuizLeagueService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<QuizLeagueBriefDto>> GetByQuizId(int quizId)
            => await _http.GetFromJsonAsync<IEnumerable<QuizLeagueBriefDto>>($"{BasePath}/quiz/{quizId}")
               ?? Enumerable.Empty<QuizLeagueBriefDto>();

        public async Task<QuizLeagueBriefDto?> GetBriefById(int id)
            => await _http.GetFromJsonAsync<QuizLeagueBriefDto>($"{BasePath}/{id}");

        public async Task<QuizLeagueDetailedDto?> GetDetailedById(int id)
            => await _http.GetFromJsonAsync<QuizLeagueDetailedDto>($"{BasePath}/{id}?detailed=1");

        public async Task<QuizLeagueDetailedDto?> Add(NewQuizLeagueDto league)
        {
            var response = await _http.PostAsJsonAsync($"{BasePath}", league);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizLeagueDetailedDto>()
                : null;
        }

        public async Task<QuizLeagueDetailedDto?> Update(NewQuizLeagueDto league)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/{league.Id}", league);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizLeagueDetailedDto>()
                : null;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"{BasePath}/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<QuizLeagueDetailedDto?> FinishLeagueAsync(int leagueId)
        {
            var response = await _http.PatchAsync($"{BasePath}/close/{leagueId}", null);

            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizLeagueDetailedDto>()
                : null;
        }

    }
}
