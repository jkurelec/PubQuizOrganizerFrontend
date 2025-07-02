using PubQuizOrganizerFrontend.Models.Dto.QuizDto;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizLeagueDto
{
    public class QuizLeagueBriefDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public QuizMinimalDto Quiz { get; set; } = null!;
    }
}
