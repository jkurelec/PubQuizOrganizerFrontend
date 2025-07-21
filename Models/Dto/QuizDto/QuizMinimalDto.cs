namespace PubQuizOrganizerFrontend.Models.Dto.QuizDto
{
    public class QuizMinimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Rating { get; set; }
        public int EditionsHosted { get; set; }
        public string? ProfileImage { get; set; }
    }
}
