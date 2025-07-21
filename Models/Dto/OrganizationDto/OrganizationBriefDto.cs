using PubQuizOrganizerFrontend.Models.Dto.QuizDto;
using PubQuizOrganizerFrontend.Models.Dto.UserDto;

namespace PubQuizOrganizerFrontend.Models.Dto.OrganizationDto
{
    public class OrganizationBriefDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int EditionsHosted { get; set; }
        public UserBriefDto Owner { get; set; } = null!;
        public List<QuizMinimalDto> Quizzes { get; set; } = null!;
        public string? ProfileImage { get; set; }
    }
}
