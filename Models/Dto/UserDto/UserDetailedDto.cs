using PubQuizOrganizerFrontend.Models.Dto.QuizAnswerDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto;
using PubQuizOrganizerFrontend.Models.Dto.TeamDto;

namespace PubQuizOrganizerFrontend.Models.Dto.UserDto
{
    public class UserDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public int Rating { get; set; }
        public int Role { get; set; }
        public string ProfileImage { get; set; } = string.Empty;
        public IEnumerable<QuizMinimalDto> HostingQuizzes { get; set; } = new List<QuizMinimalDto>();
        public IEnumerable<QuizEditionMinimalDto> EditionsHosted { get; set; } = new List<QuizEditionMinimalDto>();
        public IEnumerable<TeamBreifDto> CurrentTeams { get; set; } = new List<TeamBreifDto>();
        public IEnumerable<QuizEditionResultForUserDto> AttendedEditions { get; set; } = new List<QuizEditionResultForUserDto>();
    }
}