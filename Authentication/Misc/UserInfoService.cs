using Microsoft.JSInterop;
using PubQuizOrganizerFrontend.Models.Auth;
using PubQuizOrganizerFrontend.Models.Dto.OrganizationDto;
using System.Text.Json;

namespace PubQuizOrganizerFrontend.Authentication.Misc
{
    public class UserInfoService
    {
        private readonly IJSRuntime _js;
        private UserInfo _userInfoCache = null!;
        private OrganizationMinimalDto? _organizationCache = null;

        public event Action<UserInfo>? UserInfoChanged;
        public event Action<OrganizationMinimalDto>? UserOrgChanged;

        public UserInfoService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<UserInfo> GetUserInfo()
        {
            if (_userInfoCache != null)
                return _userInfoCache;

            var json = await _js.InvokeAsync<string>("localStorage.getItem", "userInfo");

            if (json != null)
                _userInfoCache = JsonSerializer.Deserialize<UserInfo>(json)!;

            return _userInfoCache!;
        }

        public async Task SetUserInfo(UserInfo userInfo)
        {
            _userInfoCache = userInfo;
            var json = JsonSerializer.Serialize(userInfo);
            await _js.InvokeVoidAsync("localStorage.setItem", "userInfo", json);
            UserInfoChanged?.Invoke(_userInfoCache);
        }

        public async Task ClearUserInfo()
        {
            _userInfoCache = null!;
            await _js.InvokeVoidAsync("localStorage.removeItem", "userInfo");
            await ClearUserOrganization();
            UserInfoChanged?.Invoke(null!);
        }

        public async Task<OrganizationMinimalDto?> GetUserOrganization()
        {
            if (_organizationCache != null)
                return _organizationCache.Id != 0
                    ? _organizationCache
                    : null;

            var json = await _js.InvokeAsync<string>("localStorage.getItem", "organization");

            if (json != null)
                _organizationCache = JsonSerializer.Deserialize<OrganizationMinimalDto>(json)!;

            return _organizationCache != null
                ? _organizationCache.Id != 0
                    ? _organizationCache
                    : null
                : null;
        }

        public async Task<bool> UserOrganizationSet()
        {
            if (_organizationCache != null)
                return true;

            var json = await _js.InvokeAsync<string>("localStorage.getItem", "organization");

            if (json != null)
                _organizationCache = JsonSerializer.Deserialize<OrganizationMinimalDto>(json)!;

            return _organizationCache != null;
        }

        public async Task SetUserOrganization(OrganizationMinimalDto? organization)
        {
            _organizationCache = organization ?? new() { Id = 0, Name = "No organization!"};

            var json = JsonSerializer.Serialize(_organizationCache);

            await _js.InvokeVoidAsync("localStorage.setItem", "organization", json);


            UserOrgChanged?.Invoke(_organizationCache);
        }

        public async Task ClearUserOrganization()
        {
            _organizationCache = null!;

            await _js.InvokeVoidAsync("localStorage.removeItem", "organization");

            UserOrgChanged?.Invoke(null!);
        }
    }
}
