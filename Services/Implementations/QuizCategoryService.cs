using PubQuizOrganizerFrontend.Models.Dto.QuizCategoryDto;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class QuizCategoryService : IQuizCategoryService
    {
        private readonly HttpClient _http;
        private readonly string BasePath = "category";

        public QuizCategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<QCategoryDto> GetById(int id)
        {
            var result = await _http.GetFromJsonAsync<QCategoryDto>($"{BasePath}/{id}");
            return result ?? new QCategoryDto();
        }

        public async Task<IEnumerable<QCategoryDto>> GetByName(string name)
        {
            var result = await _http.GetFromJsonAsync<IEnumerable<QCategoryDto>>($"{BasePath}/name/{name}");
            return result ?? Enumerable.Empty<QCategoryDto>();
        }

        public async Task<IEnumerable<QCategoryDto>> GetBySuperCategoryId(int? superCategoryId)
        {
            string url = superCategoryId.HasValue
                ? $"{BasePath}/super/{superCategoryId.Value}"
                : $"{BasePath}/super";

            var result = await _http.GetFromJsonAsync<IEnumerable<QCategoryDto>>(url);
            return result ?? Enumerable.Empty<QCategoryDto>();
        }

        public async Task<IEnumerable<QCategoryDto>> GetAll()
        {
            var result = await _http.GetFromJsonAsync<IEnumerable<QCategoryDto>>($"{BasePath}");
            return result ?? Enumerable.Empty<QCategoryDto>();
        }

        public async Task<QCategoryDto> Add(QCategoryDto quizCategory)
        {
            var response = await _http.PostAsJsonAsync($"{BasePath}", quizCategory);
            if (!response.IsSuccessStatusCode)
                return new QCategoryDto();

            var result = await response.Content.ReadFromJsonAsync<QCategoryDto>();
            return result ?? new QCategoryDto();
        }
    }
}
