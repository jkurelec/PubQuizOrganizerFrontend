using PubQuizOrganizerFrontend.Authentication.Misc;
using PubQuizOrganizerFrontend.Models.Dto.ApplicationDto;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class QuizEditionApplicationService : IQuizEditionApplicationService
    {
        private readonly HttpClient _httpClient;
        private readonly UserInfoService _userInfoService;
        private const string BasePath = "application/";

        public QuizEditionApplicationService(HttpClient httpClient, UserInfoService userInfoService)
        {
            _httpClient = httpClient;
            _userInfoService = userInfoService;
        }

        public async Task<IEnumerable<AcceptedQuizEditionApplicationDto>> GetAcceptedApplicationsByEdition(int id)
        {
            var url = $"{BasePath}accepted/{id}";

            using var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<AcceptedQuizEditionApplicationDto>>() ?? new List<AcceptedQuizEditionApplicationDto>();
        }

        public async Task<bool> CheckIfUserApplied(int editionId)
        {
            var user = await _userInfoService.GetUserInfoAsync();

            if (user == null)
                return false;

            var url = $"{BasePath}check/{editionId}";

            using var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return false;

            var content = await response.Content.ReadAsStringAsync();

            if (bool.TryParse(content, out bool result))
                return result;

            return false;
        }

        public async Task ApplyForQuiz(QuizEditionApplicationRequestDto applicationRequestDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BasePath}apply", applicationRequestDto);

            if (!response.IsSuccessStatusCode)
                Console.Write(response.ToString());
        }
    }
}
