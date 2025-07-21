namespace PubQuizOrganizerFrontend.Models.Dto.OrganizationDto
{
    public class OrganizationMinimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ProfileImage { get; set; }
    }
}
