using PubQuizOrganizerFrontend.Models.Dto.QuizCategoryDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizDto;
using PubQuizOrganizerFrontend.Models.Dto.UserDto;

namespace PubQuizOrganizerFrontend.Models.Dto.TeamDto
{
    public class TeamDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
        public QCategoryDto Category { get; set; } = null!;
        public QuizMinimalDto Quiz { get; set; } = null!;
        public IEnumerable<UserTeamDto> TeamMembers { get; set; } = new List<UserTeamDto>();
        public string? ProfileImage { get; set; }
    }
}
