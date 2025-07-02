using PubQuizOrganizerFrontend.Models.Dto.LocationDto;
using PubQuizOrganizerFrontend.Models.Dto.OrganizationDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizCategoryDto;
using PubQuizOrganizerFrontend.Models.Dto.QuizEditionDto;
using PubQuizOrganizerFrontend.Models.Dto.TeamDto;

namespace PubQuizOrganizerFrontend.Models.Dto.QuizDto
{
    public class QuizDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public OrganizationMinimalDto Organization { get; set; } = new();
        public int Rating { get; set; }
        public int EditionsHosted { get; set; }
        public IEnumerable<LocationBriefDto> Locations { get; set; } = new List<LocationBriefDto>();
        public IEnumerable<QCategoryDto> Categories { get; set; } = new List<QCategoryDto>();
        public IEnumerable<QuizEditionMinimalDto> QuizEditions { get; set; } = null!;
        public IEnumerable<TeamBreifDto> Teams { get; set; } = null!;
    }
}
