using Microsoft.AspNetCore.Components.Forms;
using PubQuizOrganizerFrontend.Models.Dto.QuizDto;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class QuizService : IQuizService
    {
        private readonly HttpClient _http;
        private readonly string BasePath = "quiz";

        public QuizService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<QuizBriefDto>> GetAllBrief()
            => await _http.GetFromJsonAsync<IEnumerable<QuizBriefDto>>($"{BasePath}?detailed=0")
               ?? Enumerable.Empty<QuizBriefDto>();

        public async Task<IEnumerable<QuizDetailedDto>> GetAllDetailed()
            => await _http.GetFromJsonAsync<IEnumerable<QuizDetailedDto>>($"{BasePath}?detailed=1")
               ?? Enumerable.Empty<QuizDetailedDto>();

        public async Task<QuizBriefDto?> GetBriefById(int id)
            => await _http.GetFromJsonAsync<QuizBriefDto>($"{BasePath}/{id}?detailed=0");

        public async Task<QuizDetailedDto?> GetDetailedById(int id)
            => await _http.GetFromJsonAsync<QuizDetailedDto>($"{BasePath}/{id}?detailed=1");

        public async Task<QuizDetailedDto?> Add(NewQuizDto quiz)
        {
            var response = await _http.PostAsJsonAsync($"{BasePath}", quiz);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizDetailedDto>()
                : null;
        }

        public async Task<QuizDetailedDto?> Update(NewQuizDto quiz)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/{quiz.Id}", quiz);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizDetailedDto>()
                : null;
        }

        public async Task Delete(int id)
            => await _http.DeleteAsync($"{BasePath}/{id}");

        public async Task<IEnumerable<QuizMinimalDto>> GetByHostAndOrganization(int organizationId) =>
            await _http.GetFromJsonAsync<IEnumerable<QuizMinimalDto>>($"{BasePath}/host/{organizationId}")
                ?? Enumerable.Empty<QuizMinimalDto>();

        public async Task<string?> UpdateProfileImage(IBrowserFile image, int quizId)
        {
            if (image == null)
                return null;

            using var content = new MultipartFormDataContent();

            var streamContent = new StreamContent(image.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024));
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType);

            content.Add(streamContent, "image", image.Name);

            var response = await _http.PostAsync($"{BasePath}/profile-image/{quizId}", content);

            if (response.IsSuccessStatusCode)
            {
                var fileName = await response.Content.ReadAsStringAsync();
                return fileName.Trim('"');
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to upload image: {error}");
            }
        }
    }
}
