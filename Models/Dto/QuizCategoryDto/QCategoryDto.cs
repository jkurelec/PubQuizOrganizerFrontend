namespace PubQuizOrganizerFrontend.Models.Dto.QuizCategoryDto
{
    public class QCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? SuperCategoryId { get; set; }
    }
}
