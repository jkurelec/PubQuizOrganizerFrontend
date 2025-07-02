using System.Security.Claims;
using System.Text.Json;

namespace PubQuizOrganizerFrontend.Authentication.Misc
{
    public static class JwtParser
    {
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();

            if (string.IsNullOrWhiteSpace(jwt))
                return claims;

            var parts = jwt.Split('.');
            if (parts.Length != 3)
                return claims;

            var payload = parts[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            if (keyValuePairs == null)
                return claims;

            foreach (var kvp in keyValuePairs)
            {
                if (kvp.Value is JsonElement element)
                {
                    if (element.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var arrayElement in element.EnumerateArray())
                        {
                            claims.Add(new Claim(kvp.Key, arrayElement.ToString() ?? ""));
                        }
                    }
                    else
                    {
                        claims.Add(new Claim(kvp.Key, element.ToString() ?? ""));
                    }
                }
                else
                {
                    claims.Add(new Claim(kvp.Key, kvp.Value?.ToString() ?? ""));
                }
            }

            return claims;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            return Convert.FromBase64String(base64);
        }
    }
}
