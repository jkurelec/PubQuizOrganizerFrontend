namespace PubQuizOrganizerFrontend.Authentication.Interfaces
{
    public interface ITokenStorageService
    {
        void SetAccessToken(string? token);
        string? GetAccessToken();
        void ClearAccessToken();
    }
}
