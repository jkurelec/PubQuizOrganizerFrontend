using PubQuizOrganizerFrontend.Models.Dto.LocationDto;

namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface ILocationService
    {
        Task<LocationDetailedDto?> CheckIfExists(string? locationName = null, string? address = null, string? city = null, string? country = null);
        Task<List<LocationDetailedDto>> FindNew(string? locationName = null, string? address = null, string? city = null, string? country = null, int limit = 1);
        Task<LocationDetailedDto?> GetById(int id);
        Task<LocationDetailedDto?> Add(LocationDetailedDto location);
        Task<LocationDetailedDto?> Update(LocationUpdateDto updatedLocation);
        Task<List<LocationDetailedDto>> Search(string search, int limit = 10);
        Task Delete(int id);
    }
}
