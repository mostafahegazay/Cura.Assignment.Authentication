using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Application.Contracts.Authentication
{
    public class TokenResult
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
