using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface IComplaintBLL : IBaseBLL<Complaint>
    {
        ICollection<Complaint> GetTopSix();
        Complaint GetComplaintCompany(int id);
        ICollection<Complaint> GetComplaintsWCompanies();
        ICollection<Complaint> GetComplaintsViaCompanyID(int id);
        ICollection<Complaint> GetComplaintsByUserID(int id);
    }
}
