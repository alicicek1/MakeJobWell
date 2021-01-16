using MakeJobWell.Core.DataAccess.Concrete.EntityFramework;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.DAL.Concrete.Repository
{
    class SubCategoryDAL : EFRepositoryBase<SubCategory, MakeJobWellDbContext>, ISubCategoryDAL
    {
    }
}
