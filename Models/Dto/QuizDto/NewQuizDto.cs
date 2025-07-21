namespace PubQuizOrganizerFrontend.Models.Dto.QuizDto
{
    public class NewQuizDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OrganizationId { get; set; }
        public List<int> Categories { get; set; } = new();
        public List<int> Locations { get; set; } = new();
    }
}
