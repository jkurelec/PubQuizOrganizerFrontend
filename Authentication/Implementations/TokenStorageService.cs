using PubQuizOrganizerFrontend.Authentication.Interfaces;

namespace PubQuizOrganizerFrontend.Authentication.Implementations
{
    public class TokenStorageService : ITokenStorageService
    {
        private string? _accessToken;

        public void SetAccessToken(string? token) => _accessToken = token;
        public string? GetAccessToken() => _accessToken;
        public void ClearAccessToken() => _accessToken = null;
    }
}
