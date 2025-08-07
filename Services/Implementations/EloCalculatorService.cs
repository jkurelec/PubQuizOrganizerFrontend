using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class EloCalculatorService : IEloCalculatorService
    {
        private readonly HttpClient _http;
        private readonly string BasePath = "elo";

        public EloCalculatorService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CalculateEditionElo(int editionId)
        {
            var response = await _http.PostAsync($"{BasePath}?editionId={editionId}", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> IsEditionRated(int editionId)
        {
            return await _http.GetFromJsonAsync<bool?>($"{BasePath}/{editionId}")
                ?? false;
        }
    }
}
