namespace PubQuizOrganizerFrontend.Models.Dto.ApplicationDto
{
    public class AcceptedQuizEditionApplicationDto
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; } = null!;
        public int TeamMembers{ get; set; }
    }
}
