using PubQuizOrganizerFrontend.Models.Dto.UserDto;

namespace PubQuizOrganizerFrontend.Models.Dto.TeamDto
{
    public class TeamRegisterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<UserBriefDto> Memebers { get; set; } = new List<UserBriefDto>();
    }
}
