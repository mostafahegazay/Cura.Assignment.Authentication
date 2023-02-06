using Cura.Assignment.Authentication.Application.Contracts.Authentication;
using Cura.Assignment.Authentication.Application.Contracts.Dtos;
using Cura.Assignment.Authentication.Application.Contracts.Handlers;
using Cura.Assignment.Authentication.Application.Contracts.Services;
using Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate;
using Cura.Assignment.Authentication.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository userRepository;
        private readonly IHashingService hashingService;
        private readonly IJwtHandler jwtHandler;
        public IdentityService(IUserRepository userRepository, IHashingService hashingService, IJwtHandler jwtHandler)
        {
            this.userRepository = userRepository;
            this.hashingService = hashingService;
            this.jwtHandler = jwtHandler;
        }
        public async Task<TokenResult> LoginAsync(LoginDto input)
        {
            if (string.IsNullOrWhiteSpace(input.Email)) throw new ArgumentNullException("email");
            if (string.IsNullOrWhiteSpace(input.Password)) throw new ArgumentNullException("password");

            var user = await userRepository.FindAsync(input.Email, true);

            if (user == null) throw new Exception("User email not found");

            if(!user.IsValidPassword(input.Password, hashingService)) throw new Exception("User password invalid");

            var userClaims = new List<Claim>();
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Name, user.Name));
            userClaims.Add(new Claim("role", user.Role.Name));

            string permissionInJson = JsonSerializer.Serialize(user.Permissions.Select(perm => perm.Permission.Name).ToList());

            userClaims.Add(new Claim("scope", permissionInJson, JsonClaimValueTypes.JsonArray));

            return this.jwtHandler.Generate(user.Id, userClaims);

        }
    }
}
