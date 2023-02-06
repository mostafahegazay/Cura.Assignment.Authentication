using Cura.Assignment.Authentication.Application.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Application.Contracts.Handlers
{
    public interface IJwtHandler
    {
        TokenResult Generate(Guid userId, List<Claim> claims);
    }
}
