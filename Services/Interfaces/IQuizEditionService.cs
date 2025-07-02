using PubQuizOrganizerFrontend.Enums;
using PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto;

namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface IQuizEditionService
    {
        Task<(IEnumerable<QuizEditionMinimalDto> Items, int TotalCount)> GetAllPage(int page, int pageSize, EditionFilter filter);

        Task<(IEnumerable<QuizEditionMinimalDto> Items, int TotalCount)> GetUpcomingPage(int page, int pageSize, EditionFilter filter);

        Task<(IEnumerable<QuizEditionMinimalDto> Items, int TotalCount)> GetCompletedPage(int page, int pageSize, EditionFilter filter);
        Task<QuizEditionDetailedDto> GetById(int id);
    }
}
