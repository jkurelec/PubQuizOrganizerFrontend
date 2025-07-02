using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using PubQuizOrganizerFrontend.Authentication.Interfaces;
using PubQuizOrganizerFrontend.Models.Auth;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PubQuizOrganizerFrontend.Authentication.Misc
{
    public class RetryingTokenHandler : DelegatingHandler
    {
        private readonly ITokenStorageService _tokenStorage;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;

        public RetryingTokenHandler(ITokenStorageService tokenStorage, IHttpClientFactory httpClientFactory, AuthenticationStateProvider authStateProvider)
        {
            _tokenStorage = tokenStorage;
            _httpClient = httpClientFactory.CreateClient("RefreshClient");
            _authStateProvider = authStateProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _tokenStorage.GetAccessToken();

            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var refreshRequest = new HttpRequestMessage(HttpMethod.Post, "auth/refresh");
                refreshRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
                refreshRequest.Headers.Add("AppName", "Attendee");

                var refreshResponse = await _httpClient.SendAsync(refreshRequest, cancellationToken);

                if (refreshResponse.IsSuccessStatusCode)
                {
                    var result = await refreshResponse.Content.ReadFromJsonAsync<AccessTokenResponse>(cancellationToken: cancellationToken);

                    if (!string.IsNullOrWhiteSpace(result?.AccessToken))
                    {
                        _tokenStorage.SetAccessToken(result.AccessToken);

                        if (_authStateProvider is CustomAuthenticationStateProvider customAuthProvider)
                            await customAuthProvider.NotifyUserAuthentication(result.AccessToken);

                        var cloned = await CloneHttpRequestMessageAsync(request);
                        cloned.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

                        return await base.SendAsync(cloned, cancellationToken);
                    }
                }

                _tokenStorage.ClearAccessToken();

                if (_authStateProvider is CustomAuthenticationStateProvider customAuthProviderr)
                    await customAuthProviderr.NotifyUserLogout();
            }

            return response;
        }

        private static async Task<HttpRequestMessage> CloneHttpRequestMessageAsync(HttpRequestMessage request)
        {
            var clone = new HttpRequestMessage(request.Method, request.RequestUri);

            if (request.Content != null)
            {
                var ms = new MemoryStream();
                await request.Content.CopyToAsync(ms);
                ms.Position = 0;
                clone.Content = new StreamContent(ms);

                foreach (var header in request.Content.Headers)
                {
                    clone.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            foreach (var header in request.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            clone.Version = request.Version;
            return clone;
        }
    }
}
