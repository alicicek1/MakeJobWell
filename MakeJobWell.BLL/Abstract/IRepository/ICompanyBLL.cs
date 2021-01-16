using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface ICompanyBLL : IBaseBLL<Company>
    {
        ICollection<Company> GetTopSix();
        ICollection<Company> GetCompaniesBySubCatID(int id);
        ICollection<Company> GetCompaniesByFLetter(string fLetter);

    }
}
