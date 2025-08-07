using PubQuizOrganizerFrontend.Models.Dto.QuizLeagueDto;

namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface IQuizLeagueService
    {
        Task<QuizLeagueDetailedDto?> Add(NewQuizLeagueDto league);
        Task<bool> Delete(int id);
        Task<QuizLeagueBriefDto?> GetBriefById(int id);
        Task<QuizLeagueDetailedDto?> GetDetailedById(int id);
        Task<IEnumerable<QuizLeagueBriefDto>> GetByQuizId(int quizId);
        Task<QuizLeagueDetailedDto?> Update(NewQuizLeagueDto league);
        Task<QuizLeagueDetailedDto?> FinishLeagueAsync(int leagueId);
    }
}
