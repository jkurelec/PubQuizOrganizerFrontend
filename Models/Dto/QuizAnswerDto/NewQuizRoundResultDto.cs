namespace PubQuizOrganizerFrontend.Models.Dto.QuizAnswerDto
{
    public class NewQuizRoundResultDto
    {
        public int RoundId { get; set; }
        public int EditionResultId { get; set; }
        public decimal Points { get; set; }
        public virtual IEnumerable<NewQuizSegmentResultDto> QuizSegmentResults { get; set; } = new List<NewQuizSegmentResultDto>();
    }
}
