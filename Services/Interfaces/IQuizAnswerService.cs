using PubQuizOrganizerFrontend.Models.Dto.QuizAnswerDto;

namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface IQuizAnswerService
    {
        Task<IEnumerable<QuizRoundResultDetailedDto>> GetTeamAnswers(int editionResultId);
        Task<IEnumerable<QuizEditionResultBriefDto>> GetEditionResults(int editionId);
        Task<IEnumerable<QuizEditionResultDetailedDto>> GetEditionResultsDetailed(int editionId);
        Task<IEnumerable<QuizEditionResultBriefDto>> RankTeamsOnEdition(int editionId);
        Task<IEnumerable<QuizEditionResultBriefDto>> BreakTie(int promotedId, int editionId);
        Task<QuizRoundResultDetailedDto?> GradeTeamAnswers(NewQuizRoundResultDto roundDto);
        Task<QuizRoundResultMinimalDto?> AddTeamRoundPoints(NewQuizRoundResultDto roundDto);
        Task<QuizRoundResultDetailedDto?> AddTeamRoundPointsDetailed(NewQuizRoundResultDto roundDto);
        Task<QuizRoundResultMinimalDto?> UpdateTeamRoundPoints(NewQuizRoundResultDto roundDto);
        Task<QuizAnswerDetailedDto?> UpdateAnswerPoints(QuizAnswerDetailedDto answerDto);
        Task<QuizRoundResultDetailedDto?> UpdateTeamRoundPointsDetailed(QuizRoundResultDetailedDto roundResultDto);
        Task DeleteRoundResultSegments(int roundResultId);
        Task<bool> IsDetailedResult(int roundResultId);
    }
}
