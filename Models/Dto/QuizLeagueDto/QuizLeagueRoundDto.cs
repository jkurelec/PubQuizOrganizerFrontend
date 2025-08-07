namespace PubQuizOrganizerFrontend.Models.Dto.QuizLeagueDto
{
    public class QuizLeagueRoundDto
    {
        public int Id { get; set; }
        public int Round { get; set; }
        public IEnumerable<QuizLeagueRoundEntryDto> QuizLeagueRoundEntries { get; set; } = new List<QuizLeagueRoundEntryDto>();
    }
}
