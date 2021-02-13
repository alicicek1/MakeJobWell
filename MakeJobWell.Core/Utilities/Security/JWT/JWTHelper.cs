using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace MakeJobWell.Core.Utilities.Security.JWT
{
    public class JWTHelper<TUser, TClaim> : ITokenHelper<TUser, TClaim>
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        public JWTHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //_tokenOptions = Configuration.GetSection(key: "TokenOptions");
        }
        public AccessToken CreateToken(TUser entity, ICollection<TClaim> claims)
        {
            throw new NotImplementedException();
        }
    }
}
