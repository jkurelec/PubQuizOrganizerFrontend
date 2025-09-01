using Microsoft.AspNetCore.Components.Forms;
using PubQuizOrganizerFrontend.Enums;
using PubQuizOrganizerFrontend.Models.Dto.QuizQuestionsDto.Basic;
using PubQuizOrganizerFrontend.Models.Dto.QuizQuestionsDto.Specific;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class UpcomingQuizQuestionService : IUpcomingQuizQuestionService
    {
        private readonly HttpClient _http;
        private const string BasePath = "upcoming/question";

        public UpcomingQuizQuestionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<QuizQuestionDto?> GetQuestion(int id)
            => await _http.GetFromJsonAsync<QuizQuestionDto>($"{BasePath}/{id}");

        public async Task<QuizSegmentDto?> GetSegment(int id)
            => await _http.GetFromJsonAsync<QuizSegmentDto>($"{BasePath}/segment/{id}");

        public async Task<QuizRoundDto?> GetRound(int id)
            => await _http.GetFromJsonAsync<QuizRoundDto>($"{BasePath}/round/{id}");

        public async Task<IEnumerable<QuizRoundBriefDto>> GetRoundsBrief(int editionId)
            => await _http.GetFromJsonAsync<IEnumerable<QuizRoundBriefDto>>($"{BasePath}/rounds/{editionId}")
               ?? new List<QuizRoundBriefDto>();

        public async Task<IEnumerable<QuizRoundDto>> GetRounds(int editionId)
            => await _http.GetFromJsonAsync<IEnumerable<QuizRoundDto>>($"{BasePath}/rounds/{editionId}?detailed=true")
               ?? new List<QuizRoundDto>();

        public async Task<bool> DeleteQuestion(int id)
            => (await _http.DeleteAsync($"{BasePath}/{id}")).IsSuccessStatusCode;

        public async Task<bool> DeleteSegment(int id)
            => (await _http.DeleteAsync($"{BasePath}/segment/{id}")).IsSuccessStatusCode;

        public async Task<bool> DeleteRound(int id)
            => (await _http.DeleteAsync($"{BasePath}/round/{id}")).IsSuccessStatusCode;

        public async Task<QuizQuestionDto?> AddQuestion(QuizQuestionDto dto, IBrowserFile? file)
        {
            using var content = new MultipartFormDataContent();

            var dtoJson = JsonSerializer.Serialize(dto);
            var dtoContent = new StringContent(dtoJson, Encoding.UTF8, "application/json");
            content.Add(dtoContent, "questionDto");

            if (file != null)
            {
                var maxSize = dto.Type switch
                {
                    QuestionType.IMAGE => 10 * 1024 * 1024,
                    QuestionType.AUDIO => 20 * 1024 * 1024,
                    QuestionType.VIDEO => 100 * 1024 * 1024,
                    _ => 1 * 1024 * 1024
                };

                var streamContent = new StreamContent(file.OpenReadStream(maxAllowedSize: maxSize));
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                content.Add(streamContent, "file", file.Name);
            }

            var response = await _http.PostAsync(BasePath, content);

            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizQuestionDto>()
                : null;
        }

        public async Task<QuizSegmentDto?> AddSegment(QuizSegmentDto dto)
        {
            var response = await _http.PostAsJsonAsync($"{BasePath}/segment", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizSegmentDto>()
                : null;
        }

        public async Task<QuizRoundDto?> AddRound(QuizRoundDto dto)
        {
            var response = await _http.PostAsJsonAsync($"{BasePath}/round", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizRoundDto>()
                : null;
        }

        public async Task<QuizQuestionDto?> EditQuestion(QuizQuestionDto dto, IBrowserFile? file)
        {
            using var content = new MultipartFormDataContent();

            var dtoJson = JsonSerializer.Serialize(dto);
            var dtoContent = new StringContent(dtoJson, Encoding.UTF8, "application/json");
            content.Add(dtoContent, "questionDto");

            if (file != null)
            {
                var maxSize = dto.Type switch
                {
                    QuestionType.IMAGE => 10 * 1024 * 1024,
                    QuestionType.AUDIO => 20 * 1024 * 1024,
                    QuestionType.VIDEO => 100 * 1024 * 1024,
                    _ => 1 * 1024 * 1024
                };

                var streamContent = new StreamContent(file.OpenReadStream(maxAllowedSize: maxSize));
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                content.Add(streamContent, "file", file.Name);
            }

            var response = await _http.PutAsync($"{BasePath}/{dto.Id}", content);

            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizQuestionDto>()
                : null;
        }

        public async Task<QuizSegmentDto?> EditSegment(QuizSegmentDto dto)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/segment/{dto.Id}", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizSegmentDto>()
                : null;
        }

        public async Task<QuizRoundBriefDto?> EditRound(QuizRoundBriefDto dto)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/round/{dto.Id}", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizRoundBriefDto>()
                : null;
        }

        public async Task<QuizSegmentDto?> UpdateQuestionOrder(UpdateOrderDto dto)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/order/{dto.Id}", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizSegmentDto>()
                : null;
        }

        public async Task<QuizRoundDto?> UpdateSegmentOrder(UpdateOrderDto dto)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/segment/order/{dto.Id}", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<QuizRoundDto>()
                : null;
        }

        public async Task<List<QuizRoundDto>> UpdateRoundOrder(UpdateOrderDto dto)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/round/order/{dto.Id}", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<List<QuizRoundDto>>() ?? new List<QuizRoundDto>()
                : new List<QuizRoundDto>();
        }

        public async Task<bool> DoesEditionHaveQuestions(int editionId)
        {
            return await _http.GetFromJsonAsync<bool>($"{BasePath}/has-questions/{editionId}");
        }
    }
}
