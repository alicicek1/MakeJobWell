using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Core.Utilities.Security.JWT
{
    class TokenOptions
    {
        public string Auidence { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
