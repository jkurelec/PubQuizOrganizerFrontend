using PubQuizOrganizerFrontend.Models.Dto.LocationDto;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _http;
        private readonly string BasePath = "location";

        public LocationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<LocationDetailedDto?> CheckIfExists(string? locationName = null, string? address = null, string? city = null, string? country = null)
        {
            var url = $"{BasePath}/check?" +
                      $"locationName={Uri.EscapeDataString(locationName ?? string.Empty)}&" +
                      $"address={Uri.EscapeDataString(address ?? string.Empty)}&" +
                      $"city={Uri.EscapeDataString(city ?? string.Empty)}&" +
                      $"country={Uri.EscapeDataString(country ?? string.Empty)}";

            var response = await _http.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return null;

            return await response.Content.ReadFromJsonAsync<LocationDetailedDto?>();
        }

        public async Task<List<LocationDetailedDto>> FindNew(string? locationName = null, string? address = null, string? city = null, string? country = null, int limit = 1)
        {
            var url = $"{BasePath}/new?" +
                      $"locationName={Uri.EscapeDataString(locationName ?? string.Empty)}&" +
                      $"address={Uri.EscapeDataString(address ?? string.Empty)}&" +
                      $"city={Uri.EscapeDataString(city ?? string.Empty)}&" +
                      $"country={Uri.EscapeDataString(country ?? string.Empty)}&" +
                      $"limit={limit}";

            return await _http.GetFromJsonAsync<List<LocationDetailedDto>>(url) ?? new List<LocationDetailedDto>();
        }

        public async Task<LocationDetailedDto?> GetById(int id)
        {
            return await _http.GetFromJsonAsync<LocationDetailedDto?>($"{BasePath}/{id}");
        }

        public async Task<LocationDetailedDto?> Add(LocationDetailedDto location)
        {
            var response = await _http.PostAsJsonAsync($"{BasePath}", location);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<LocationDetailedDto>()
                : null;
        }

        public async Task<LocationDetailedDto?> Update(LocationUpdateDto updatedLocation)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/{updatedLocation.Id}", updatedLocation);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<LocationDetailedDto>()
                : null;
        }

        public async Task<List<LocationDetailedDto>> Search(string search, int limit = 10)
        {
            var url = $"{BasePath}/list?search={Uri.EscapeDataString(search)}&limit={limit}";
            return await _http.GetFromJsonAsync<List<LocationDetailedDto>>(url) ?? new List<LocationDetailedDto>();
        }

        public async Task Delete(int id)
        {
            await _http.DeleteAsync($"{BasePath}/{id}");
        }
    }
}
