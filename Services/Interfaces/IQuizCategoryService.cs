using PubQuizOrganizerFrontend.Models.Dto.QuizCategoryDto;

namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface IQuizCategoryService
    {
        Task<QCategoryDto> GetById(int id);
        Task<IEnumerable<QCategoryDto>> GetByName(string name);
        Task<IEnumerable<QCategoryDto>> GetBySuperCategoryId(int? superCategoryId);
        Task<IEnumerable<QCategoryDto>> GetAll();
        Task<QCategoryDto> Add(QCategoryDto quizCategory);
    }
}
