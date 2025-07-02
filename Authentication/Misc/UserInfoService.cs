using Microsoft.JSInterop;
using PubQuizOrganizerFrontend.Models.Auth;
using System.Text.Json;

namespace PubQuizOrganizerFrontend.Authentication.Misc
{
    public class UserInfoService
    {
        private readonly IJSRuntime _js;
        private UserInfo? _userInfoCache;

        public event Action<UserInfo?>? UserInfoChanged;

        public UserInfoService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<UserInfo?> GetUserInfoAsync()
        {
            if (_userInfoCache != null)
                return _userInfoCache;

            var json = await _js.InvokeAsync<string>("localStorage.getItem", "userInfo");

            if (string.IsNullOrWhiteSpace(json))
                return null;

            _userInfoCache = JsonSerializer.Deserialize<UserInfo>(json);

            return _userInfoCache;
        }

        public async Task SetUserInfoAsync(UserInfo userInfo)
        {
            _userInfoCache = userInfo;
            var json = JsonSerializer.Serialize(userInfo);
            await _js.InvokeVoidAsync("localStorage.setItem", "userInfo", json);
            UserInfoChanged?.Invoke(_userInfoCache);
        }

        public async Task ClearUserInfoAsync()
        {
            _userInfoCache = null;
            await _js.InvokeVoidAsync("localStorage.removeItem", "userInfo");
            UserInfoChanged?.Invoke(null);
        }
    }
}
