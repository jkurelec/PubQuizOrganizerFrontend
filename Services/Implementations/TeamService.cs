using Newtonsoft.Json;
using PubQuizOrganizerFrontend.Authentication.Misc;
using PubQuizOrganizerFrontend.Models.Dto.ApplicationDto;
using PubQuizOrganizerFrontend.Models.Dto.TeamDto;
using PubQuizOrganizerFrontend.Services.Interfaces;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Services.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly HttpClient _httpClient;
        private readonly UserInfoService _userInfoService;
        private const string BasePath = "team/";

        public TeamService(HttpClient httpClient, UserInfoService userInfoService)
        {
            _httpClient = httpClient;
            _userInfoService = userInfoService;
        }

        public async Task<IEnumerable<TeamDetailedDto>> GetUserTeams()
        {
            var userInfo = await _userInfoService.GetUserInfoAsync();

            if (userInfo == null)
                return new List<TeamDetailedDto>();

            var response = await _httpClient.GetAsync($"{BasePath}user/{userInfo.Id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var teams = JsonConvert.DeserializeObject<List<TeamDetailedDto>>(json);

                return teams ?? new List<TeamDetailedDto>();
            }

            return new List<TeamDetailedDto>();
        }

        public async Task ApplyToTeam(TeamMemberDto dto)
        {
            await _httpClient.PostAsJsonAsync($"{BasePath}apply", dto);
        }

        public async Task InviteUser(TeamMemberDto dto)
        {
            await _httpClient.PostAsJsonAsync($"{BasePath}invite", dto);
        }

        public async Task AnswerApplication(ApplicationResponseDto dto)
        {
            await _httpClient.PostAsJsonAsync($"{BasePath}reply/application", dto);
        }

        public async Task AnswerInvitation(ApplicationResponseDto dto)
        {
            await _httpClient.PostAsJsonAsync($"{BasePath}reply/invitation", dto);
        }

        public async Task<IEnumerable<TeamApplicationInvitationDto>> GetApplications()
        {
            var response = await _httpClient.GetAsync($"{BasePath}applications");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<TeamApplicationInvitationDto>>(json);
                return data ?? new List<TeamApplicationInvitationDto>();
            }

            return new List<TeamApplicationInvitationDto>();
        }

        public async Task<IEnumerable<TeamApplicationInvitationDto>> GetInvitations()
        {
            var response = await _httpClient.GetAsync($"{BasePath}invitations");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<TeamApplicationInvitationDto>>(json);
                return data ?? new List<TeamApplicationInvitationDto>();
            }

            return new List<TeamApplicationInvitationDto>();
        }

        public async Task ChangeOwner(int newOwnerId)
        {
            await _httpClient.PutAsync($"{BasePath}owner/{newOwnerId}", null);
        }

        public async Task DeleteTeam()
        {
            await _httpClient.DeleteAsync($"{BasePath}");
        }

        public async Task EditMember(TeamMemberDto dto)
        {
            await _httpClient.PutAsJsonAsync($"{BasePath}member/{dto.UserId}", dto);
        }

        public async Task RemoveMember(int userId)
        {
            await _httpClient.DeleteAsync($"{BasePath}member/{userId}");
        }

        public async Task<IEnumerable<TeamBreifDto>> GetAllTeams()
        {
            var response = await _httpClient.GetAsync(BasePath);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<TeamBreifDto>>(json);
                return data ?? new List<TeamBreifDto>();
            }

            return new List<TeamBreifDto>();
        }

        public async Task<TeamDetailedDto?> GetTeamById(int id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TeamDetailedDto>(json);
            }

            return null;
        }

        public async Task<TeamDetailedDto?> GetTeamByOwnerId(int id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}owner/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TeamDetailedDto>(json);
            }

            return null;
        }

        public async Task<TeamDetailedDto?> UpdateTeam(UpdateTeamDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BasePath}{dto.Name}", dto);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TeamDetailedDto>(json);
            }

            return null;
        }

        public async Task<TeamDetailedDto?> CreateTeam(string name)
        {
            var dto = new NewTeamDto { Name = name };
            var response = await _httpClient.PostAsJsonAsync(BasePath, dto);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TeamDetailedDto>(json);
            }

            return null;
        }

        public async Task LeaveTeam(int teamId)
        {
            await _httpClient.DeleteAsync($"{BasePath}leave/{teamId}");
        }

        public async Task<IEnumerable<TeamRegisterDto>> GetTeamsForRegistration(int editionId)
        {
            var response = await _httpClient.GetAsync($"{BasePath}registerRights/{editionId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<TeamRegisterDto>>(json);

                return data ?? new List<TeamRegisterDto>();
            }

            return new List<TeamRegisterDto>();
        }
    }
}
