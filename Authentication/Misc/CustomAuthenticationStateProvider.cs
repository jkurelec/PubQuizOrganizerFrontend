using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using PubQuizBackend.Util;
using PubQuizOrganizerFrontend.Authentication.Interfaces;
using PubQuizOrganizerFrontend.Models.Auth;
using System.Net.Http.Json;
using System.Security.Claims;

namespace PubQuizOrganizerFrontend.Authentication.Misc
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ITokenStorageService _tokenStorage;
        private readonly UserInfoService _userInfoService;

        public CustomAuthenticationStateProvider(ITokenStorageService tokenStorage, UserInfoService userInfoService)
        {
            _tokenStorage = tokenStorage;
            _userInfoService = userInfoService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userInfo = await _userInfoService.GetUserInfo();

            if (userInfo == null)
                return new AuthenticationState(new ClaimsPrincipal());

            var token = _tokenStorage.GetAccessToken();

            if (string.IsNullOrWhiteSpace(token))
            {
                var tokenSet = await TryRefreshTokenAsync();

                if (tokenSet)
                    token = _tokenStorage.GetAccessToken();
            }

            var identity = !string.IsNullOrWhiteSpace(token)
                ? new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt")
                : new ClaimsIdentity();

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public async Task NotifyUserAuthentication(string token)
        {
            var claims = JwtParser.ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);
            var role = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var intRole = CustomConverter.GetIntRole(role!);

            if (!int.TryParse(user.FindFirst("sub")?.Value, out int id))
                throw new InvalidOperationException("User ID claim is missing or invalid.");

            var teamIdClaim = user.FindFirst("teamId")?.Value;
            int? teamId = int.TryParse(teamIdClaim, out var tid) ? tid : null;

            await _userInfoService.SetUserInfo(
                new()
                {
                    Id = id,
                    Username = user.FindFirst(c => c.Type == ClaimTypes.Name)?.Value!,
                    Role = intRole
                }
            );

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task NotifyUserLogout()
        {
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());

            await _userInfoService.ClearUserInfo();

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }

        public async Task<bool> TryRefreshTokenAsync()
        {
            try
            {
                var refreshRequest = new HttpRequestMessage(HttpMethod.Post, "auth/refresh");
                refreshRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
                refreshRequest.Headers.Add("AppName", "Attendee");

                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7062/"),
                };

                var response = await httpClient.SendAsync(refreshRequest);

                if (!response.IsSuccessStatusCode)
                {
                    await NotifyUserLogout();

                    return false;
                }
                    

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
    }
}
