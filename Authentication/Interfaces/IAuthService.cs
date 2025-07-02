using PubQuizOrganizerFrontend.Models.Auth;

namespace PubQuizOrganizerFrontend.Authentication.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginUserDto loginDto);
        Task<bool> LogoutAsync();
        Task<bool> TryRefreshTokenAsync();
        Task<bool> RegisterAsync(RegisterUserDto registerDto);
    }
}
