namespace PubQuizOrganizerFrontend.Models.Dto.QuizAnswerDto
{
    public class NewQuizSegmentResultDto
    {
        public int SegmentId { get; set; }
        public decimal BonusPoints { get; set; }
        public virtual IEnumerable<NewQuizAnswerDto> QuizAnswers { get; set; } = new List<NewQuizAnswerDto>();
    }
}
