using PubQuizOrganizerFrontend.Enums;
using System.ComponentModel.DataAnnotations;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizQuestionsDto.Basic
{
    public class QuizQuestionDto
    {
        public int Id { get; set; }
        public int SegmentId { get; set; }
        public QuestionType Type { get; set; } = QuestionType.REGULAR;
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
        [Range(0.5, 100, ErrorMessage = "TotalPoints must be at least 0.5")]
        public decimal Points { get; set; }
        public decimal BonusPoints { get; set; } = 0;
        public string? MediaUrl { get; set; }
        public int Number { get; set; }
        public int Rating { get; set; }
    }
}
