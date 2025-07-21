using PubQuizOrganizerFrontend.Enums;
using PubQuizOrganizerFrontend.Models.Dto.LocationDto;
using PubQuizOrganizerFrontend.Models.Dto.PrizesDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizCategoryDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizLeagueDto;
using PubQuizOrganizerFrontend.Models.Dto.UserDto;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto
{
    public class QuizEditionDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public QuizMinimalDto Quiz { get; set; } = null!;
        public UserBriefDto Host { get; set; } = null!;
        public QCategoryDto Category { get; set; } = null!;
        public LocationBriefDto Location { get; set; } = null!;
        public DateTime Time { get; set; }
        public int Rating { get; set; }
        public decimal? AveragePoints { get; set; }
        public decimal? TotalPoints { get; set; }
        public int? FeeType { get; set; }
        public int? Fee { get; set; }
        public int? Duration { get; set; }
        public int? MaxTeamSize { get; set; }
        public string? Description { get; set; }
        public DateTime RegistrationStart { get; set; }
        public DateTime RegistrationEnd { get; set; }
        public QuizLeagueBriefDto? League { get; set; }
        public IEnumerable<PrizeDto> Prizes { get; set; } = new List<PrizeDto>();
        public Visibility Visibility { get; set; } = Visibility.INVISIBLE;
        public int MaxTeams { get; set; }
        public int AcceptedTeams { get; set; }
        public int PendingTeams { get; set; }
        public string? ProfileImage { get; set; }
    }
}
