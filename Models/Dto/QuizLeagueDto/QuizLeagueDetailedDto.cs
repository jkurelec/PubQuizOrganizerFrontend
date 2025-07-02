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
        public IEnumerable<QuizEditionMinimalDto> Editions { get; set; } = new List<QuizEditionMinimalDto>();
        // list trenutacnog stanja 
        //public IEnumerable<TeamMinimalDto> Rankings { get; set; } = new List<QuizEditionMinimalDto>();
    }
}
