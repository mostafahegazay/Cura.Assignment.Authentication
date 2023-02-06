using Cura.Assignment.Authentication.API.Common;
using Cura.Assignment.Authentication.Application.Contracts.Authentication;
using Cura.Assignment.Authentication.Application.Contracts.Consts;
using Cura.Assignment.Authentication.Application.Contracts.Handlers;
using Cura.Assignment.Authentication.Application.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Cura.Assignment.Authentication.Application.Contracts.Extensions
{
    public static class JwtExtension
    {
        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            //Bind Options Data
            var options = new JwtOptions();
            var section = configuration.GetSection("jwt");
            section.Bind(options);
            services.Configure<JwtOptions>(section);

            //Register JWT hanler to IOC 
            services.AddSingleton<IJwtHandler, JwtHandler>();

            //Normalize Claims
            services.AddTransient<IClaimsTransformation, ClaimsTransformer>();

            // Configure Authentication
            services.AddAuthentication(authOpt =>
            {
                authOpt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOpt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
            
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidIssuer = options.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey))
                };
            });

            //Configure Policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyConsts.Admin, policy => policy.RequireClaim(ClaimTypes.Role, PolicyConsts.Admin));
                options.AddPolicy(PolicyConsts.Player, policy => policy.RequireClaim(ClaimTypes.Role, PolicyConsts.Player));
                options.AddPolicy(PolicyConsts.BoardGame, policy => policy.RequireClaim("scope", PolicyConsts.BoardGame));
                options.AddPolicy(PolicyConsts.VIPCharacter, policy => policy.RequireClaim("scope", PolicyConsts.VIPCharacter));
            });

        }
    }
}
