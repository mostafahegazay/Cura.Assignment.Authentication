using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cura.Assignment.Authentication.API.Common
{
    public class InternalServerErrorObjectResult : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status500InternalServerError;

        public InternalServerErrorObjectResult(object value)
            : base(value)
        {
            StatusCode = DefaultStatusCode;
        }
    }
}
