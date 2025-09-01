using Microsoft.AspNetCore.Components.Forms;
using PubQuizOrganizerFrontend.Enums;
using PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizQuestionsDto.Basic;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class QuizEditionService : IQuizEditionService
    {
        private readonly HttpClient _http;
        private const string BasePath = "edition";

        public QuizEditionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<QuizEditionBriefDto>> GetAll()
        {
            var response = await _http.GetAsync(BasePath);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<QuizEditionBriefDto>>() ?? new List<QuizEditionBriefDto>()
                : new List<QuizEditionBriefDto>();
        }

        public async Task<IEnumerable<QuizEditionBriefDto>> GetByQuizId(int quizId)
        {
            var response = await _http.GetAsync($"{BasePath}/quiz/{quizId}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<QuizEditionBriefDto>>() ?? new List<QuizEditionBriefDto>()
                : new List<QuizEditionBriefDto>();
        }

        public async Task<IEnumerable<QuizEditionMinimalDto>> GetByTeamId(int teamId)
        {
            var response = await _http.GetAsync($"{BasePath}/team/{teamId}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<QuizEditionMinimalDto>>() ?? new List<QuizEditionMinimalDto>()
                : new List<QuizEditionMinimalDto>();
        }

        public async Task<QuizEditionDetailedDto?> GetById(int id)
        {
            var response = await _http.GetAsync($"{BasePath}/{id}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizEditionDetailedDto>()
                : null;
        }

        public async Task<IEnumerable<QuizEditionMinimalDto>> GetUpcomingPaged(int page, int pageSize, EditionFilter filter)
        {
            var response = await _http.GetAsync($"{BasePath}/paged/upcoming?page={page}&pageSize={pageSize}&filter={filter}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<QuizEditionMinimalDto>>() ?? new List<QuizEditionMinimalDto>()
                : new List<QuizEditionMinimalDto>();
        }

        public async Task<IEnumerable<QuizEditionMinimalDto>> GetCompletedPaged(int page, int pageSize, EditionFilter filter)
        {
            var response = await _http.GetAsync($"{BasePath}/paged/completed?page={page}&pageSize={pageSize}&filter={filter}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<QuizEditionMinimalDto>>() ?? new List<QuizEditionMinimalDto>()
                : new List<QuizEditionMinimalDto>();
        }

        public async Task<IEnumerable<QuizEditionMinimalDto>> GetAllPaged(int page, int pageSize, EditionFilter filter)
        {
            var response = await _http.GetAsync($"{BasePath}/paged/all?page={page}&pageSize={pageSize}&filter={filter}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<QuizEditionMinimalDto>>() ?? new List<QuizEditionMinimalDto>()
                : new List<QuizEditionMinimalDto>();
        }

        public async Task<QuizEditionDetailedDto?> Add(NewQuizEditionDto dto)
        {
            var response = await _http.PostAsJsonAsync(BasePath, dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizEditionDetailedDto>()
                : null;
        }

        public async Task<QuizEditionDetailedDto?> Update(NewQuizEditionDto dto)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/{dto.Id}", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizEditionDetailedDto>()
                : null;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"{BasePath}/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<QuizEditionBriefDto>> GetByLocationId(int locationId)
        {
            var response = await _http.GetAsync($"{BasePath}/location/{locationId}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<QuizEditionBriefDto>>() ?? new List<QuizEditionBriefDto>()
                : new List<QuizEditionBriefDto>();
        }

        public async Task<string?> UpdateProfileImage(IBrowserFile image, int editionId)
        {
            if (image == null)
                return null;

            using var content = new MultipartFormDataContent();

            var streamContent = new StreamContent(image.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024));
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType);

            content.Add(streamContent, "image", image.Name);

            var response = await _http.PostAsync($"{BasePath}/profile-image/{editionId}", content);

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

        public async Task<bool?> HasDetailedQuestions(int editionId)
        {
            var response = await _http.GetAsync($"{BasePath}/detailed-questions/{editionId}");
            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<DetailedQuestionStatusDto>();
            return result?.Value;
        }

        public async Task<bool> SetDetailedQuestions(int editionId, bool detailed)
        {
            var dto = new DetailedQuestionStatusDto { Value = detailed };
            var response = await _http.PatchAsJsonAsync($"{BasePath}/detailed-questions/{editionId}", dto);

            return response.IsSuccessStatusCode;
        }
    }
}
