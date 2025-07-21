using PubQuizOrganizerFrontend.Enums;
using PubQuizOrganizerFrontend.Models.Dto.RatingHistory;
using PubQuizOrganizerFrontend.Models.Dto.UserDto;

namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserBriefDto>> GetAll();
        Task<UserBriefDto?> GetById(int id);
        Task<UserBriefDto?> Update(UserDto user);
        Task Delete(int id);
        Task<IEnumerable<UserBriefDto>> Search(string? username = null, string? sortBy = null, bool descending = false, int limit = 50);
        Task<UserDetailedDto?> GetDetailedById(int id);
        Task<List<RatingHistoryDto>> GetRatingHistories(int id, TimePeriod timePeriod);
    }
}
