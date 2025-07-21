using PubQuizOrganizerFrontend.Models.Dto.LocationDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizCategoryDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizDto;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto
{
    public class QuizEditionBriefDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public QuizMinimalDto Quiz { get; set; } = null!;
        public QCategoryDto Category { get; set; } = null!;
        public LocationBriefDto Location { get; set; } = null!;
        public DateTime Time { get; set; }
        public int Rating { get; set; }
        public int MaxTeams { get; set; }
        public int AcceptedTeams { get; set; }
        public int PendingTeams { get; set; }
        public string? ProfileImage { get; set; }
    }
}
