using PubQuizOrganizerFrontend.Models.Dto.UserDto;

namespace PubQuizOrganizerFrontend.Models.Dto.OrganizationDto
{
    public class HostDto
    {
        public bool IsOwner { get; set; } = false;
        public required UserBriefDto UserBrief { get; set; }
        public required HostPermissionsDto HostPermissions { get; set; }
    }
}
