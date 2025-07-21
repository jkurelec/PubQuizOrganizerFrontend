namespace PubQuizOrganizerFrontend.Models.Auth
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Role { get; set; }
    }
}
