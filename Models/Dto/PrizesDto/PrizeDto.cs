namespace PubQuizOrganizerFrontend.Models.Dto.PrizesDto
{
    public class PrizeDto
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; } = null!;

        public int? Position { get; set; }
    }
}
