namespace PubQuizOrganizerFrontend.Models.Dto.ApplicationDto
{
    public class ApplicationResponseDto
    {
        public ApplicationResponseDto(int applicationId, bool response)
        {
            ApplicationId = applicationId;
            Response = response;
        }

        public int ApplicationId { get; set; }
        public bool Response { get; set; }
    }
}
