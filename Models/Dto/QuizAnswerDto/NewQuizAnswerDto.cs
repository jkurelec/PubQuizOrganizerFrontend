namespace PubQuizOrganizerFrontend.Models.Dto.QuizAnswerDto
{
    public class NewQuizAnswerDto
    {
        public string Answer { get; set; } = null!;
        public decimal Points { get; set; }
        public int QuestionId { get; set; }
        public int Result { get; set; }
    }
}
