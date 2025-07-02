using PubQuizOrganizerFrontend.Models.Dto.ApplicationDto;

namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface IQuizEditionApplicationService
    {
        Task<IEnumerable<AcceptedQuizEditionApplicationDto>> GetAcceptedApplicationsByEdition(int id);
        Task<bool> CheckIfUserApplied(int editionId);
        Task ApplyForQuiz(QuizEditionApplicationRequestDto applicationRequestDto);
    }
}
