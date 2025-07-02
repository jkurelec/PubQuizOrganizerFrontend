using PubQuizOrganizerFrontend.Models.Dto.ApplicationDto;
using PubQuizOrganizerFrontend.Models.Dto.TeamDto;

namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDetailedDto>> GetUserTeams();
        Task ApplyToTeam(TeamMemberDto teamMember);
        Task InviteUser(TeamMemberDto teamMember);
        Task AnswerApplication(ApplicationResponseDto dto);
        Task AnswerInvitation(ApplicationResponseDto dto);
        Task<IEnumerable<TeamApplicationInvitationDto>> GetApplications();
        Task<IEnumerable<TeamApplicationInvitationDto>> GetInvitations();
        Task ChangeOwner(int newOwnerId);
        Task DeleteTeam();
        Task EditMember(TeamMemberDto dto);
        Task RemoveMember(int userId);
        Task<IEnumerable<TeamBreifDto>> GetAllTeams();
        Task<TeamDetailedDto?> GetTeamById(int id);
        Task<TeamDetailedDto?> GetTeamByOwnerId(int id);
        Task<TeamDetailedDto?> UpdateTeam(UpdateTeamDto dto);
        Task<TeamDetailedDto?> CreateTeam(string name);
        Task LeaveTeam(int teamId);
        Task<IEnumerable<TeamRegisterDto>> GetTeamsForRegistration(int editionId);
    }
}
