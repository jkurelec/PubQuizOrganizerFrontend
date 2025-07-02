using PubQuizOrganizerFrontend.Models.Dto.QuizCategoryDto;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto
{
    public class QuizEditionMinimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public QCategoryDto Category { get; set; } = null!;
        public DateTime Time { get; set; }
        public int Rating { get; set; }
        public int MaxTeams { get; set; }
        public int AcceptedTeams { get; set; }
        public int PendingTeams { get; set; }
    }
}
