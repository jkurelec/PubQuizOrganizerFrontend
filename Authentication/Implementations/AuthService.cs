using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using PubQuizOrganizerFrontend.Authentication.Interfaces;
using PubQuizOrganizerFrontend.Authentication.Misc;
using PubQuizOrganizerFrontend.Models.Auth;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Authentication.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenStorageService _tokenStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(HttpClient httpClient, ITokenStorageService tokenStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _tokenStorage = tokenStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> LoginAsync(LoginUserDto loginDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "auth/login");
            request.Headers.Add("AppName", "Attendee");
            request.Content = JsonContent.Create(loginDto);
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return false;

            var result = await response.Content.ReadFromJsonAsync<AccessTokenResponse>();

            if (result == null || string.IsNullOrWhiteSpace(result.AccessToken))
                return false;

            _tokenStorage.SetAccessToken(result.AccessToken);

            if (_authenticationStateProvider is CustomAuthenticationStateProvider customAuthProvider)
            {
                await customAuthProvider.NotifyUserAuthentication(result.AccessToken);
            }

            return true;
        }


        public async Task<bool> LogoutAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "auth/logout");
            request.Headers.Add("AppName", "Attendee");
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                _tokenStorage.SetAccessToken(null);

                if (_authenticationStateProvider is CustomAuthenticationStateProvider customAuthProvider)
                    await customAuthProvider.NotifyUserLogout();

                return true;
            }

            return false;
        }

        public async Task<bool> TryRefreshTokenAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "auth/refresh");
                request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
                request.Headers.Add("AppName", "Attendee");

                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                    return false;

                var result = await response.Content.ReadFromJsonAsync<AccessTokenResponse>();

                if (result == null || string.IsNullOrWhiteSpace(result.AccessToken))
                    return false;

                _tokenStorage.SetAccessToken(result.AccessToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RegisterAsync(RegisterUserDto registerDto)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "api/auth/register");
                request.Headers.Add("AppName", "Attendee");
                request.Content = JsonContent.Create(registerDto);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
