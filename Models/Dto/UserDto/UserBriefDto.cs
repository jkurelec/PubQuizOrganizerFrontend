namespace PubQuizOrganizerFrontend.Models.Dto.UserDto
{
    public class UserBriefDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Rating { get; set; }
        public string? ProfileImage { get; set; }
    }
}
