using Cura.Assignment.Authentication.Application.Contracts.Dtos;
using Cura.Assignment.Authentication.Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cura.Assignment.Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectController : ControllerBase
    {
        private readonly IIdentityService identityService;
        public ConnectController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }
        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Token([FromBody] LoginDto loginDto)
        {
            var token = await identityService.LoginAsync(loginDto);
            return Ok(token);
        }
    }
}
