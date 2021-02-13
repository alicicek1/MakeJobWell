using MakeJobWell.Core.Utilities.Result;
using MakeJobWell.Models.Entities;
using System.Collections.Generic;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface ISubCategoryBLL : IBaseBLL<SubCategory>
    {
        IDataResult<ICollection<SubCategory>> GetSubCategoriesByCatID(int id);
        IDataResult<ICollection<SubCategory>> GetAllWithCats();
    }
}
