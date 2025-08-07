using PubQuizOrganizerFrontend.Models.Dto.ApplicationDto;

namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface IQuizEditionApplicationService
    {
        Task<bool> Apply(QuizEditionApplicationRequestDto application);
        Task<bool> WithdrawFromEdition(int editionId);
        Task<IEnumerable<QuizEditionApplicationDto>> GetApplications(int editionId, bool unanswered = true);
        Task<bool> RespondToApplication(ApplicationResponseDto response);
        Task<bool> RemoveTeamFromEdition(int editionId, int teamId);
        Task<IEnumerable<AcceptedQuizEditionApplicationDto>> GetAcceptedApplicationsByEdition(int editionId);
        Task<bool> CheckIfUserApplied(int editionId);
        Task<bool> CanUserWithdraw(int teamId, int editionId);
    }
}
