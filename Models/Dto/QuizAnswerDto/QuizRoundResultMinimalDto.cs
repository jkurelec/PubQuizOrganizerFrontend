namespace PubQuizOrganizerFrontend.Models.Dto.QuizAnswerDto
{
    public class QuizRoundResultMinimalDto
    {
        public int Id { get; set; }
        public int RoundId { get; set; }
        public int EditionResultId { get; set; }
        public decimal Points { get; set; }
    }
}
