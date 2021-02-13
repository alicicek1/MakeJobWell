using MakeJobWell.Core.Utilities.Result;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface IUserBLL : IBaseBLL<User>
    {
        IDataResult<User> GetUserByActivationCode(Guid guid);
        IDataResult<User> GetUserByEmailandPassword(string email, string password);
        IDataResult<User> GetByUserName(string username);
        IResult AddAdmin(User entity);
        IResult DeleteByUserName(string username);
    }
}
