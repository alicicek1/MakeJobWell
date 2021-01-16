﻿using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface ICommentBLL : IBaseBLL<Comment>
    {
        ICollection<Comment> GetCommentsWUsersByComplaintID(int id);
    }
}
