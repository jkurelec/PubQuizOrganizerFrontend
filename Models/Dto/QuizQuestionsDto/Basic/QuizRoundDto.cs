namespace PubQuizOrganizerFrontend.Models.Dto.QuizQuestionsDto.Basic
{
    public class QuizRoundDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int EditionId { get; set; }
        public decimal Points { get; set; }
        public IEnumerable<QuizSegmentDto> QuizSegments { get; set; } = new List<QuizSegmentDto>();
    }
}
