using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Concrete.Repositories
{
    class ComplaintBLL : IComplaintBLL
    {
        IComplaintDAL complaintDAL;
        public ComplaintBLL(IComplaintDAL complaint)
        {
            complaintDAL = complaint;
        }

        #region DataCheck
        void Check(Complaint entity)
        {
            CheckComplaintTitle(entity.ComplaintTitle);
            CheckComplaitDetail(entity.ComplaintDetail);
        }

        private void CheckComplaitDetail(string complaintDetail)
        {
            if (complaintDetail == null)
            {
                throw new Exception("Complaints details cannt be null.");
            }
        }

        private void CheckComplaintTitle(string complaintTitle)
        {
            if (complaintTitle == null)
            {
                if (complaintTitle.Length < 10)
                {
                    throw new Exception("Complaints titles cannot be null and shorter than 10 characters.");
                }
            }
        }
        #endregion

        #region BaseCRUD
        public void Add(Complaint entity)
        {
            Check(entity);
            complaintDAL.Add(entity);
        }
        public void Update(Complaint entity)
        {
            Check(entity);
            complaintDAL.Update(entity);
        }

        public void Delete(Complaint entity)
        {
            entity.IsActive = false;
            complaintDAL.Update(entity);
        }

        public void Delete(int id)
        {
            Complaint complaint = Get(id);
            complaint.IsActive = false;
            complaintDAL.Update(complaint);
        }

        public Complaint Get(int id)
        {
            return complaintDAL.Get(a => a.ID == id && a.IsActive == true);
        }

        public ICollection<Complaint> GetAll()
        {
            return complaintDAL.GetAll(a => a.IsActive == true);
        }


        #endregion

        public ICollection<Complaint> GetTopSix()
        {
            return complaintDAL.GetTopSix();
        }

        public Complaint GetComplaintCompany(int id)
        {
            return complaintDAL.Get(a => a.ID == id && a.IsActive == true, a => a.Company);
        }
        public ICollection<Complaint> GetComplaintsWCompanies()
        {
            return complaintDAL.GetAll(null, a => a.Company);
        }

        public ICollection<Complaint> GetComplaintsViaCompanyID(int id)
        {
            return complaintDAL.GetAll(a => a.CompanyID == id && a.IsActive == true);
        }

        public ICollection<Complaint> GetComplaintsByUserID(int id)
        {
            return complaintDAL.GetAll(a => a.UserID == id && a.IsActive == true);
        }
    }
}
