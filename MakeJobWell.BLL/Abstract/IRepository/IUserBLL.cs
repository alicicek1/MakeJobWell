using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface IUserBLL : IBaseBLL<User>
    {
        User GetUserByActivationCode(Guid guid);
        User GetUserByEmailandPassword(string email, string password);
        void AddAdmin(User entity);
    }
}
