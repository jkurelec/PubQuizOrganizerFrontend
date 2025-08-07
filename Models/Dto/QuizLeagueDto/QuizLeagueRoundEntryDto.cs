using PubQuizOrganizerFrontend.Models.Dto.TeamDto;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizLeagueDto
{
    public class QuizLeagueRoundEntryDto
    {
        public int Id { get; set; }
        public double Points { get; set; }
        public TeamBreifDto Team { get; set; } = null!;
    }
}
