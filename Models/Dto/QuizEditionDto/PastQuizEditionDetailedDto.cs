using PubQuizOrganizerFrontend.Models.Dto.QuizAnswerDto;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto
{
    public class PastQuizEditionDetailedDto : QuizEditionDetailedDto
    {
        public QuizEditionRoundsDto Rounds { get; set; } = new();
        public IEnumerable<QuizEditionResultDetailedDto> Results { get; set; } = new List<QuizEditionResultDetailedDto>();
    }
}
