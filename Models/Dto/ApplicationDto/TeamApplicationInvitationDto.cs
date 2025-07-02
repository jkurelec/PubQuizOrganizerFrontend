namespace PubQuizOrganizerFrontend.Models.Dto.ApplicationDto
{
    public class TeamApplicationInvitationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public bool? Response { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
