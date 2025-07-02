namespace PubQuizOrganizerFrontend.Models.Dto.QuizAnswerDto
{
    public class QuizAnswerDetailedDto : NewQuizAnswerDto
    {
        public int Id { get; set; }
        public int SegmentResultId { get; set; }
    }
}
