﻿using MakeJobWell.Core.DataAccess.Abstract;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.DAL.Abstract
{
    public interface IUserDAL : IRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
