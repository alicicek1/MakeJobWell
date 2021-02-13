using MakeJobWell.Core.Utilities.Result;
using MakeJobWell.Models.Entities;
using System.Collections.Generic;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface ICategoryBLL : IBaseBLL<Category>
    {
        IDataResult<ICollection<Category>> GetLatestSix();
        IDataResult<ICollection<Category>> GetCatWSubCats();
    }
}
