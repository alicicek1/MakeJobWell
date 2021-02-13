using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.BLL.Constant;
using MakeJobWell.Core.Utilities.Result;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IResult Add(Complaint entity)
        {
            Check(entity);
            complaintDAL.Add(entity);
            return new SuccessResult(ResultMessage<Complaint>.Add(entity));
        }
        public IResult Update(Complaint entity)
        {
            Check(entity);
            complaintDAL.Update(entity);
            return new SuccessResult(ResultMessage<Complaint>.Update(entity));
        }

        public IResult Delete(Complaint entity)
        {
            entity.IsActive = false;
            complaintDAL.Update(entity);
            return new SuccessResult(ResultMessage<Complaint>.Delete(entity));
        }

        public IResult
            Delete(int id)
        {
            Complaint complaint = Get(id).Data;
            complaint.IsActive = false;
            complaintDAL.Update(complaint);
            return new SuccessResult(ResultMessage<Complaint>.Delete(complaint));
        }

        public IDataResult<Complaint> Get(int id)
        {
            return new SuccessDataResult<Complaint>(complaintDAL.Get(a => a.ID == id && a.IsActive == true));
        }

        public IDataResult<ICollection<Complaint>> GetAll()
        {
            return new SuccessDataResult<ICollection<Complaint>>(complaintDAL.GetAll(a => a.IsActive == true));
        }


        #endregion

        public IDataResult<ICollection<Complaint>> GetTopSix()
        {
            return new SuccessDataResult<ICollection<Complaint>>(complaintDAL.GetTopSix().ToList());
        }

        public IDataResult<Complaint> GetComplaintCompany(int id)
        {
            return new SuccessDataResult<Complaint>(complaintDAL.Get(a => a.ID == id && a.IsActive == true, a => a.Company));
        }
        public IDataResult<ICollection<Complaint>> GetComplaintsWCompanies()
        {
            return new SuccessDataResult<ICollection<Complaint>>(complaintDAL.GetAll(null, a => a.Company));
        }

        public IDataResult<ICollection<Complaint>> GetComplaintsViaCompanyID(int id)
        {
            return new SuccessDataResult<ICollection<Complaint>>(complaintDAL.GetAll(a => a.CompanyID == id && a.IsActive == true));
        }

        public IDataResult<ICollection<Complaint>> GetComplaintsByUserID(int id)
        {
            return new SuccessDataResult<ICollection<Complaint>>(complaintDAL.GetAll(a => a.UserID == id && a.IsActive == true));
        }
    }
}
