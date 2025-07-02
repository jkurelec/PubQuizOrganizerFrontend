namespace PubQuizOrganizerFrontend.Models.Dto.QuizAnswerDto
{
    public class QuizRoundResultDetailedDto : NewQuizRoundResultDto
    {
        public int Id { get; set; }
        public new IEnumerable<QuizSegmentResultDetailedDto> QuizSegmentResults { get; set; } = new List<QuizSegmentResultDetailedDto>();
    }
}
