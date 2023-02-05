using Cura.Assignment.Authentication.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Application.Contracts.Services
{
    public interface IIdentityService
    {
        Task<TokenResultDto> LoginAsync(string username, string password);
    }
}
