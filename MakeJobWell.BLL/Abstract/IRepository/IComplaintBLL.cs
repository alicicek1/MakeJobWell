using MakeJobWell.Core.Utilities.Result;
using MakeJobWell.Models.Entities;
using System.Collections.Generic;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface IComplaintBLL : IBaseBLL<Complaint>
    {
        IDataResult<ICollection<Complaint>> GetTopSix();
        IDataResult<Complaint> GetComplaintCompany(int id);
        IDataResult<ICollection<Complaint>> GetComplaintsWCompanies();
        IDataResult<ICollection<Complaint>> GetComplaintsViaCompanyID(int id);
        IDataResult<ICollection<Complaint>> GetComplaintsByUserID(int id);
    }
}
