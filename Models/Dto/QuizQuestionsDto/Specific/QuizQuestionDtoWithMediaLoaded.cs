using PubQuizOrganizerFrontend.Models.Dto.QuizQuestionsDto.Basic;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizQuestionsDto.Specific
{
    public class QuizQuestionDtoWithMediaLoaded : QuizQuestionDto
    {
        public byte[]? Media { get; set; }
    }
}
