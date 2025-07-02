using PubQuizOrganizerFrontend.Models.Dto.TeamDto;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizAnswerDto
{
    public class QuizEditionResultBriefDto
    {
        public int Id { get; set; }
        public TeamBreifDto Team { get; set; } = null!;
        public IEnumerable<QuizRoundResultMinimalDto> Rounds { get; set; } = new List<QuizRoundResultMinimalDto>();
        public decimal TotalPoints { get; set; }
        public int Rank { get; set; }
    }
}
