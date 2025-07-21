using PubQuizOrganizerFrontend.Models.Dto.UserDto;

namespace PubQuizOrganizerFrontend.Models.Dto.OrganizationDto
{
    public class HostQuizzesDto
    {
        public bool IsOwner { get; set; } = false;
        public required UserBriefDto UserBrief { get; set; }
        public required List<QuizPermissionDto> QuizPermissions { get; set; }
    }

    public class QuizPermissionDto
    {
        public int QuizId { get; set; }
        public string QuizName { get; set; } = string.Empty;
        public HostPermissionsDto Permissions { get; set; } = new();
    }
}
