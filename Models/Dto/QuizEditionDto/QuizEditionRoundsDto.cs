using PubQuizOrganizerFrontend.Models.Dto.QuizQuestionsDto.Basic;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto
{
    public class QuizEditionRoundsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<QuizRoundDto> Rounds { get; set; } = null!;
    }
}
