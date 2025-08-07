using PubQuizOrganizerFrontend.Models.Dto.PrizesDto;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizLeagueDto
{
    public class NewQuizLeagueDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int QuizId { get; set; }
        public string Points { get; set; } = null!;
        public IEnumerable<PrizeDto> Prizes { get; set; } = new List<PrizeDto>();
    }
}
