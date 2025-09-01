using PubQuizOrganizerFrontend.Services.Interfaces;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class PrivateMediaService : IPrivateMediaService
    {
        private readonly HttpClient _http;

        public PrivateMediaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<byte[]?> GetMediaFile(string mediaType, int editionId, string fileName)
        {
            try
            {
                var mediaUrl = $"https://localhost:7246/question/{mediaType}/{editionId}/{fileName}";
                var response = await _http.GetAsync(mediaUrl);

                if (!response.IsSuccessStatusCode)
                    return null;

                return await response.Content.ReadAsByteArrayAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
