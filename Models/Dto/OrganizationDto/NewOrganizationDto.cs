namespace PubQuizOrganizerFrontend.Models.Dto.OrganizationDto
{
    public class NewOrganizationDto
    {
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
    }
}
