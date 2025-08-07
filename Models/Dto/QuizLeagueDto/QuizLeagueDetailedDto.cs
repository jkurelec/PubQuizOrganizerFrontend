using PubQuizOrganizerFrontend.Models.Dto.PrizesDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizLeagueDto
{
    public class QuizLeagueDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<LeaguePoints> Points { get; set; } = new List<LeaguePoints>();
        public IEnumerable<PrizeDto> Prizes { get; set; } = new List<PrizeDto>();
        public QuizMinimalDto Quiz { get; set; } = null!;
        public bool Finished { get; set; }
        public IEnumerable<QuizEditionMinimalDto> Editions { get; set; } = new List<QuizEditionMinimalDto>();
        public IEnumerable<QuizLeagueRoundDto> Rounds { get; set; } = new List<QuizLeagueRoundDto>();
    }
}
