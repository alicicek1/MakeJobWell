using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface ISubCategoryBLL : IBaseBLL<SubCategory>
    {
        ICollection<SubCategory> GetSubCategoriesByCatID(int id);
        ICollection<SubCategory> GetAllWithCats();
    }
}
