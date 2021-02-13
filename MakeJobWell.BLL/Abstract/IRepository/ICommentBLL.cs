using MakeJobWell.Core.Utilities.Result;
using MakeJobWell.Models.Entities;
using System.Collections.Generic;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface ICommentBLL : IBaseBLL<Comment>
    {
        IDataResult<ICollection<Comment>> GetCommentsWUsersByComplaintID(int id);
    }
}
