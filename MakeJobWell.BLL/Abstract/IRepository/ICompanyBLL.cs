using MakeJobWell.Core.Utilities.Result;
using MakeJobWell.Models.Entities;
using System.Collections.Generic;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface ICompanyBLL : IBaseBLL<Company>
    {
        IDataResult<ICollection<Company>> GetTopSix();
        IDataResult<ICollection<Company>> GetCompaniesBySubCatID(int id);
        IDataResult<ICollection<Company>> GetCompaniesByFLetter(string fLetter);

    }
}
