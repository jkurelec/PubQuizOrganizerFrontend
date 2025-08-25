using PubQuizOrganizerFrontend.Models.Dto.QuizAnswerDto;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class QuizAnswerService : IQuizAnswerService
    {
        private readonly HttpClient _http;
        private const string BasePath = "answer";

        public QuizAnswerService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<QuizRoundResultDetailedDto>> GetTeamAnswers(int editionResultId)
            => await _http.GetFromJsonAsync<IEnumerable<QuizRoundResultDetailedDto>>($"{BasePath}/teamAnswer/{editionResultId}")
               ?? Enumerable.Empty<QuizRoundResultDetailedDto>();

        public async Task<IEnumerable<QuizEditionResultBriefDto>> GetEditionResults(int editionId)
            => await _http.GetFromJsonAsync<IEnumerable<QuizEditionResultBriefDto>>($"{BasePath}/{editionId}")
               ?? Enumerable.Empty<QuizEditionResultBriefDto>();

        public async Task<IEnumerable<QuizEditionResultDetailedDto>> GetEditionResultsDetailed(int editionId)
            => await _http.GetFromJsonAsync<IEnumerable<QuizEditionResultDetailedDto>>($"{BasePath}/{editionId}?detailed=true")
               ?? Enumerable.Empty<QuizEditionResultDetailedDto>();

        public async Task<IEnumerable<QuizEditionResultBriefDto>> RankTeamsOnEdition(int editionId)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/rank/{editionId}", new { });

            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<QuizEditionResultBriefDto>>()
                    ?? Enumerable.Empty<QuizEditionResultBriefDto>()
                : Enumerable.Empty<QuizEditionResultBriefDto>();
        }

        public async Task<IEnumerable<QuizEditionResultBriefDto>> BreakTie(int promotedId, int editionId)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/rank/breaktie/{promotedId}/{editionId}", new { });

            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<QuizEditionResultBriefDto>>()
                    ?? Enumerable.Empty<QuizEditionResultBriefDto>()
                : Enumerable.Empty<QuizEditionResultBriefDto>();
        }

        public async Task<QuizRoundResultDetailedDto?> GradeTeamAnswers(NewQuizRoundResultDto roundDto)
        {
            var response = await _http.PostAsJsonAsync($"{BasePath}/grade", roundDto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizRoundResultDetailedDto>()
                : null;
        }

        public async Task<QuizRoundResultDetailedDto?> GradeExistingTeamAnswers(QuizRoundResultDetailedDto roundDto)
        {
            var response = await _http.PostAsJsonAsync($"{BasePath}/grade/existing", roundDto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizRoundResultDetailedDto>()
                : null;
        }

        public async Task<QuizRoundResultMinimalDto?> AddTeamRoundPoints(NewQuizRoundResultDto roundDto)
        {
            var response = await _http.PostAsJsonAsync($"{BasePath}/round/points", roundDto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizRoundResultMinimalDto>()
                : null;
        }

        public async Task<QuizRoundResultDetailedDto?> AddTeamRoundPointsDetailed(NewQuizRoundResultDto roundDto)
        {
            var response = await _http.PostAsJsonAsync($"{BasePath}/round/points?detailed=true", roundDto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizRoundResultDetailedDto>()
                : null;
        }

        public async Task<QuizRoundResultMinimalDto?> UpdateTeamRoundPoints(NewQuizRoundResultDto roundDto)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/points/{roundDto.EditionResultId}", roundDto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizRoundResultMinimalDto>()
                : null;
        }

        public async Task<QuizAnswerDetailedDto?> UpdateAnswerPoints(QuizAnswerDetailedDto answerDto)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/{answerDto.Id}", answerDto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizAnswerDetailedDto>()
                : null;
        }

        public async Task<QuizRoundResultDetailedDto?> UpdateTeamRoundPointsDetailed(QuizRoundResultDetailedDto roundDto)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/points/detailed/{roundDto.Id}", roundDto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizRoundResultDetailedDto>()
                : null;
        }

        public async Task DeleteRoundResultSegments(int roundResultId)
        {
            var response = await _http.DeleteAsync($"{BasePath}/segment/{roundResultId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> IsDetailedResult(int roundResultId)
        {
            return await _http.GetFromJsonAsync<bool>($"{BasePath}/is-detailed/{roundResultId}");
        }
    }
}
