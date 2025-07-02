namespace PubQuizOrganizerFrontend.Models.Dto.UserDto
{
    public class UserTeamDto : UserBriefDto
    {
        public UserTeamDto() { }

        public bool RegisterTeam { get; set; } = false;
    }
}
