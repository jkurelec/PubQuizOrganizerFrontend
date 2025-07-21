using Microsoft.AspNetCore.Components.Forms;
using PubQuizOrganizerFrontend.Models.Dto.ApplicationDto;
using PubQuizOrganizerFrontend.Models.Dto.OrganizationDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizDto;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.IO.Enumeration;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly HttpClient _http;
        private readonly string BasePath = "organizer";

        public OrganizationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<OrganizationBriefDto>> GetAll()
            => await _http.GetFromJsonAsync<IEnumerable<OrganizationBriefDto>>($"{BasePath}")
               ?? Enumerable.Empty<OrganizationBriefDto>();

        public async Task<OrganizationBriefDto?> GetById(int id)
            => await _http.GetFromJsonAsync<OrganizationBriefDto>($"{BasePath}/{id}");

        public async Task<IEnumerable<HostQuizzesDto>> GetHostsFromOrganization(int organizerId)
            => await _http.GetFromJsonAsync<IEnumerable<HostQuizzesDto>>($"{BasePath}/hosts/{organizerId}")
               ?? Enumerable.Empty<HostQuizzesDto>();

        public async Task<HostDto?> GetHost(int organizerId, int hostId, int quizId)
            => await _http.GetFromJsonAsync<HostDto>($"{BasePath}/{organizerId}/host/{hostId}/quiz/{quizId}");

        public async Task<OrganizationBriefDto?> Add(NewOrganizationDto newOrganizer)
        {
            var response = await _http.PostAsJsonAsync($"{BasePath}", newOrganizer);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<OrganizationBriefDto>()
                : null;
        }

        public async Task<HostDto?> AddHost(NewHostDto newHost)
        {
            var response = await _http.PostAsJsonAsync($"{BasePath}/host", newHost);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<HostDto>()
                : null;
        }

        public async Task<OrganizationBriefDto?> Update(OrganizationUpdateDto updatedOrganizer)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}", updatedOrganizer);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<OrganizationBriefDto>()
                : null;
        }

        public async Task<HostDto?> UpdateHost(NewHostDto updatedHost)
        {
            var response = await _http.PutAsJsonAsync($"{BasePath}/host", updatedHost);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<HostDto>()
                : null;
        }

        public async Task Delete(int id)
            => await _http.DeleteAsync($"{BasePath}/{id}");

        public async Task DeleteHost(int organizerId, int hostId)
            => await _http.DeleteAsync($"{BasePath}/{organizerId}/host/{hostId}");

        public async Task RemoveHostFromQuiz(int organizerId, int hostId, int quizId)
            => await _http.DeleteAsync($"{BasePath}/{organizerId}/host/{hostId}/quiz/{quizId}");

        public async Task InviteHostToOrganization(QuizInvitationRequestDto request)
            => await _http.PostAsJsonAsync($"{BasePath}/invite/send", request);

        public async Task RespondToInvitation(ApplicationResponseDto response)
            => await _http.PostAsJsonAsync($"{BasePath}/invite/respond", response);

        public async Task<IEnumerable<QuizInvitationDto>> GetInvitations()
            => await _http.GetFromJsonAsync<IEnumerable<QuizInvitationDto>>($"{BasePath}/invite")
               ?? Enumerable.Empty<QuizInvitationDto>();

        public async Task<IEnumerable<OrganizationMinimalDto>> GetByHost()
            => await _http.GetFromJsonAsync<IEnumerable<OrganizationMinimalDto>>($"{BasePath}/host")
               ?? Enumerable.Empty<OrganizationMinimalDto>();

        public async Task<IEnumerable<QuizMinimalDto>> GetAvaliableQuizzesForNewHost(int hostId)
            => await _http.GetFromJsonAsync<IEnumerable<QuizMinimalDto>>($"{BasePath}/for-new-host/{hostId}")
               ?? Enumerable.Empty<QuizMinimalDto>();

        public async Task<OrganizationMinimalDto?> GetOwnerOrganization()
        {
            var response = await _http.GetAsync($"{BasePath}/from-owner");

            if (response.IsSuccessStatusCode)
            {
                if (response.Content.Headers.ContentLength == 0)
                    return null;

                return await response.Content.ReadFromJsonAsync<OrganizationMinimalDto>();
            }

            return null;
        }

        public async Task<IEnumerable<QuizInvitationDto>> GetOrganizationPendingQuizInvitations() =>
            await _http.GetFromJsonAsync<IEnumerable<QuizInvitationDto>>($"{BasePath}/invitation/pending")
               ?? Enumerable.Empty<QuizInvitationDto>();

        public async Task<IEnumerable<HostDto>> GetHostsByQuiz(int quizId) =>
            await _http.GetFromJsonAsync<IEnumerable<HostDto>>($"{BasePath}/hosts-by-quiz/{quizId}")
               ?? Enumerable.Empty<HostDto>();

        public async Task<string?> UpdateProfileImage(IBrowserFile image)
        {
            if (image == null)
                return null;

            using var content = new MultipartFormDataContent();

            var streamContent = new StreamContent(image.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024));
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType);

            content.Add(streamContent, "image", image.Name);

            var response = await _http.PostAsync($"{BasePath}/profile-image", content);

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
