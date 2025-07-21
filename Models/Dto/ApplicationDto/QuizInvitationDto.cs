using PubQuizOrganizerFrontend.Models.Dto.QuizDto;
using PubQuizOrganizerFrontend.Models.Dto.UserDto;

namespace PubQuizOrganizerFrontend.Models.Dto.ApplicationDto
{
    public class QuizInvitationDto
    {
        public int InvitationId { get; set; }
        public UserBriefDto User { get; set; } = null!;
        public QuizMinimalDto Quiz { get; set; } = null!;
    }
}
