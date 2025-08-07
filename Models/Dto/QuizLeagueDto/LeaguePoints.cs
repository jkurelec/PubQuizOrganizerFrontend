namespace PubQuizOrganizerFrontend.Models.Dto.QuizLeagueDto
{
    public class LeaguePoints
    {
        public int Position { get; set; }
        public int Points { get; set; }

        public override string? ToString()
        {
            return $"{Position} - {Points} pts";
        }
    }
}
