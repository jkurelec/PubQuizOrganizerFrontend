using PubQuizOrganizerFrontend.Models.Dto.QuizCategoryDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizDto;
using PubQuizOrganizerFrontend.Models.Dto.UserDto;

namespace PubQuizOrganizerFrontend.Models.Dto.ApplicationDto
{
    public class QuizEditionApplicationDto
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; } = null!;
        public bool? Response { get; set; }
        public QCategoryDto TeamCategory { get; set; } = null!;
        public QuizMinimalDto TeamQuiz { get; set; } = null!;
        public IEnumerable<UserBriefDto> TeamMembers { get; set; } = new List<UserBriefDto>();
    }
}
