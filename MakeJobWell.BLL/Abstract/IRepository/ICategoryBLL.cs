using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface ICategoryBLL : IBaseBLL<Category>
    {
        ICollection<Category> GetLatestSix();
        ICollection<Category> GetCatWSubCats();
    }
}
