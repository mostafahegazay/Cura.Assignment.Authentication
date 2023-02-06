using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Json;

namespace Cura.Assignment.Authentication.API.Common
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var existingClaimsIdentity = (ClaimsIdentity)principal?.Identity;
            var claims = new List<Claim>();
            if (existingClaimsIdentity != null)
            {
                claims.AddRange(existingClaimsIdentity.Claims);
                var scopeClaim = existingClaimsIdentity.Claims.Where(cl => cl.Type == "scope").FirstOrDefault();
                if (scopeClaim != null)
                {
                    var scopes = JsonSerializer.Deserialize<string[]>(scopeClaim.Value);
                    if (scopes != null)
                    {
                        foreach (var scope in scopes)
                        {
                            claims.Add(new Claim("scope", scope));
                        }
                    }
                }
            }
            var newClaimsIdentity = new ClaimsIdentity(claims, existingClaimsIdentity?.AuthenticationType);
            return new ClaimsPrincipal(newClaimsIdentity);
        }
    }
}
