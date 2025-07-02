using PubQuizOrganizerFrontend.Enums;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizQuestionsDto.Basic
{
    public class QuizSegmentDto
    {
        public int Id { get; set; }
        public int RoundId { get; set; }
        public decimal BonusPoints { get; set; } = 0;
        public int Number { get; set; }
        public SegmentType Type { get; set; } = SegmentType.REGULAR;
        public IEnumerable<QuizQuestionDto> Questions { get; set; } = new List<QuizQuestionDto>();
    }
}
