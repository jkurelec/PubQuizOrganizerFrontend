using PubQuizOrganizerFrontend.Models.Dto.PrizesDto;
using System.ComponentModel.DataAnnotations;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto
{
    public class NewQuizEditionDto
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = null!;
        public int QuizId { get; set; }
        public int HostId { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public int Rating { get; set; }
        [Range(1, 3, ErrorMessage = "FeeType: 1 => Per Team, 2 => Per Member, 3 => Free")]
        public int? FeeType { get; set; }
        public int? Fee { get; set; }
        public int? Duration { get; set; }
        [Range(1, 6, ErrorMessage ="Team size should be between 1 and 6")]
        public int? MaxTeamSize { get; set; }
        public string? Description { get; set; }
        public int? LeagueId { get; set; }
        public IEnumerable<PrizeDto> Prizes { get; set; } = new List<PrizeDto>();
        public DateTime Time { get; set; }
        public DateTime RegistrationStart { get; set; }
        public DateTime RegistrationEnd { get; set; }
        public int Visibility { get; set; } = 0;
        public int MaxTeams { get; set; }
    }
}
