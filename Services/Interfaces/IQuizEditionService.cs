using Microsoft.AspNetCore.Components.Forms;
using PubQuizOrganizerFrontend.Enums;
using PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto;

namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface IQuizEditionService
    {
        Task<IEnumerable<QuizEditionBriefDto>> GetAll();
        Task<IEnumerable<QuizEditionBriefDto>> GetByQuizId(int quizId);
        Task<QuizEditionDetailedDto?> GetById(int id);
        Task<IEnumerable<QuizEditionMinimalDto>> GetUpcomingPaged(int page, int pageSize, EditionFilter filter);
        Task<IEnumerable<QuizEditionMinimalDto>> GetCompletedPaged(int page, int pageSize, EditionFilter filter);
        Task<IEnumerable<QuizEditionMinimalDto>> GetAllPaged(int page, int pageSize, EditionFilter filter);
        Task<QuizEditionDetailedDto?> Add(NewQuizEditionDto dto);
        Task<QuizEditionDetailedDto?> Update(NewQuizEditionDto dto);
        Task<bool> Delete(int id);
        Task<IEnumerable<QuizEditionBriefDto>> GetByLocationId(int locationId);
        Task<string?> UpdateProfileImage(IBrowserFile image, int editionId);
        Task<bool?> HasDetailedQuestions(int editionId);
        Task<bool> SetDetailedQuestions(int editionId, bool detailed);
        Task<IEnumerable<QuizEditionMinimalDto>> GetByTeamId(int teamId);
    }
}
