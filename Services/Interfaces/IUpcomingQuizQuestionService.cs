using Microsoft.AspNetCore.Components.Forms;
using PubQuizOrganizerFrontend.Models.Dto.QuizQuestionsDto.Basic;
using PubQuizOrganizerFrontend.Models.Dto.QuizQuestionsDto.Specific;

namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface IUpcomingQuizQuestionService
    {
        Task<QuizQuestionDto?> AddQuestion(QuizQuestionDto dto, IBrowserFile? file);
        Task<QuizSegmentDto?> AddSegment(QuizSegmentDto dto);
        Task<QuizRoundDto?> AddRound(QuizRoundDto dto);
        Task<bool> DeleteQuestion(int id);
        Task<bool> DeleteSegment(int id);
        Task<bool> DeleteRound(int id);
        Task<bool> DoesEditionHaveQuestions(int editionId);
        Task<QuizQuestionDto?> EditQuestion(QuizQuestionDto dto, IBrowserFile? file);
        Task<QuizSegmentDto?> EditSegment(QuizSegmentDto dto);
        Task<QuizRoundBriefDto?> EditRound(QuizRoundBriefDto dto);
        Task<QuizQuestionDto?> GetQuestion(int id);
        Task<QuizSegmentDto?> GetSegment(int id);
        Task<QuizRoundDto?> GetRound(int id);
        Task<IEnumerable<QuizRoundDto>> GetRounds(int editionId);
        Task<IEnumerable<QuizRoundBriefDto>> GetRoundsBrief(int editionId);
        Task<QuizSegmentDto?> UpdateQuestionOrder(UpdateOrderDto dto);
        Task<QuizRoundDto?> UpdateSegmentOrder(UpdateOrderDto dto);
        Task<List<QuizRoundDto>> UpdateRoundOrder(UpdateOrderDto dto);
    }
}
