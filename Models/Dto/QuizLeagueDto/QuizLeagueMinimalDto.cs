namespace PubQuizOrganizerFrontend.Models.Dto.QuizLeagueDto
{
    public class QuizLeagueMinimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Finished { get; set; }
    }
}
