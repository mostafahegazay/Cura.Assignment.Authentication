using Cura.Assignment.Authentication.Application.Contracts.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cura.Assignment.Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScopeTestController : ControllerBase
    {
        [Authorize(policy: PolicyConsts.Admin)]
        [HttpGet]
        [Route("AdminAccessTest")]
        public IActionResult AdminAccessTest()
        {
            return Ok("Admin access has been permitted");
        }

        [Authorize(policy: PolicyConsts.Player, Policy = PolicyConsts.Admin)]
        [HttpGet]
        [Route("PlayerAccessTest")]
        public IActionResult PlayerAccessTest()
        {
            return Ok("Player access has been permitted");
        }

        [Authorize]
        [HttpGet]
        [Route("BoardGameAccessTest")]
        public IActionResult BoardGameAccessTest()
        {
            return Ok("Board Game access has been permitted");
        }

        [Authorize(policy: PolicyConsts.VIPCharacter)]
        [HttpGet]
        [Route("VIPCharacterAccessTest")]
        public IActionResult VIPCharacterAccessTest()
        {
            return Ok("VIP Character access has been permitted");
        }
    }
}
