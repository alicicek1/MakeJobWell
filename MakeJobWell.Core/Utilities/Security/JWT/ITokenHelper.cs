using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Core.Utilities.Security.JWT
{
    public interface ITokenHelper<TUser,TClaim>
    {
        AccessToken CreateToken(TUser entity,ICollection<TClaim> claims);
    }
}
