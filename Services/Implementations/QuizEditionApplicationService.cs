using PubQuizOrganizerFrontend.Models.Dto.ApplicationDto;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class QuizEditionApplicationService : IQuizEditionApplicationService
    {
        private readonly HttpClient _http;
        private const string Base = "application";

        public QuizEditionApplicationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> Apply(QuizEditionApplicationRequestDto application)
        {
            var response = await _http.PostAsJsonAsync($"{Base}/apply", application);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> WithdrawFromEdition(int editionId)
        {
            var response = await _http.DeleteAsync($"{Base}/withdraw/{editionId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<QuizEditionApplicationDto>> GetApplications(int editionId, bool unanswered = true)
        {
            var response = await _http.GetAsync($"{Base}/{editionId}?unanswered={unanswered.ToString().ToLower()}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<QuizEditionApplicationDto>>() ?? new List<QuizEditionApplicationDto>()
                : new List<QuizEditionApplicationDto>();
        }

        public async Task<bool> RespondToApplication(ApplicationResponseDto responseDto)
        {
            var response = await _http.PostAsJsonAsync($"{Base}/respond", responseDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveTeamFromEdition(int editionId, int teamId)
        {
            var response = await _http.DeleteAsync($"{Base}/team/{teamId}/{editionId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<AcceptedQuizEditionApplicationDto>> GetAcceptedApplicationsByEdition(int editionId)
        {
            var response = await _http.GetAsync($"{Base}/accepted/{editionId}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<AcceptedQuizEditionApplicationDto>>() ?? new List<AcceptedQuizEditionApplicationDto>()
                : new List<AcceptedQuizEditionApplicationDto>();
        }

        public async Task<bool> CheckIfUserApplied(int editionId)
        {
            var response = await _http.GetAsync($"{Base}/check/applied/{editionId}");
            return response.IsSuccessStatusCode && await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> CanUserWithdraw(int teamId, int editionId)
        {
            var response = await _http.GetAsync($"{Base}/check/withdraw/{teamId}/{editionId}");
            return response.IsSuccessStatusCode && await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
