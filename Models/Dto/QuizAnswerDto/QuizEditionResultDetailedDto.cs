namespace PubQuizOrganizerFrontend.Models.Dto.QuizAnswerDto
{
    public class QuizEditionResultDetailedDto : QuizEditionResultBriefDto
    {
        public new IEnumerable<QuizRoundResultDetailedDto> Rounds { get; set; } = new List<QuizRoundResultDetailedDto>();
    }
}
