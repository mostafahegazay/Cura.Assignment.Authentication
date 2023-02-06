using Cura.Assignment.Authentication.Application.Contracts.Authentication;
using Cura.Assignment.Authentication.Application.Contracts.Handlers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cura.Assignment.Authentication.Application.Handlers
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;
        private readonly JwtOptions jwtOptions;
        private readonly SecurityKey issuerSigningKey;
        private readonly SigningCredentials signingCredentials;
        private readonly JwtHeader jwtHeader;
        public JwtHandler(IOptions<JwtOptions> jwtOptions)
        {
            this.jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            this.jwtOptions = jwtOptions.Value;
            this.issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.jwtOptions.SecretKey));
            this.signingCredentials = new SigningCredentials(this.issuerSigningKey, SecurityAlgorithms.HmacSha256);
            this.jwtHeader = new JwtHeader(this.signingCredentials);
        }
        public TokenResult Generate(Guid userId, List<Claim> claims)
        {
            var nowTimeInUtc = DateTime.UtcNow;
            var tokenExpireyDate = nowTimeInUtc.AddMinutes(this.jwtOptions.ExpiryMinutes);
            var tokenCenturyBegin = new DateTime(1970, 1, 1).ToUniversalTime();
            var tokenExpiry = (long)(new TimeSpan(tokenExpireyDate.Ticks - tokenCenturyBegin.Ticks).TotalSeconds);
            var tokenNow = (long)(new TimeSpan(nowTimeInUtc.Ticks - tokenCenturyBegin.Ticks).TotalSeconds);
            var payload = new JwtPayload
            {
                {"sub", userId },
                {"iss", this.jwtOptions.Issuer },
                {"iat", tokenNow },
                {"exp", tokenExpiry },
                {"uniqe_name", userId }
            };

            foreach (var claim in claims)
            {
                payload.Add(claim.Type, claim.Value);
            }

            var jwtSecurityToken = new JwtSecurityToken(jwtHeader, payload);
            var resolvedToken = this.jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return new TokenResult()
            {
                Token = resolvedToken,
                Expires = tokenExpiry
            };
        }
    }
}
