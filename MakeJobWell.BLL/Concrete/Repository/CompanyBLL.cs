using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.BLL.Concrete.EntityValidation;
using MakeJobWell.BLL.Constant;
using MakeJobWell.Core.CrossCuttingConcerns.Validation.FluentVal;
using MakeJobWell.Core.Utilities.Result;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;

namespace MakeJobWell.BLL.Concrete.Repositories
{
    class CompanyBLL : ICompanyBLL
    {
        ICompanyDAL companyDAL;
        public CompanyBLL(ICompanyDAL company)
        {
            companyDAL = company;

        }

        #region DataCheck
        void Check(Company entity)
        {
            CheckCompanyName(entity.CompanyName);
            CheckOverview(entity.Overview);
            CheckAddress(entity.Adress);
            CheckWeSite(entity.WebSite);
        }

        private void CheckCompanyName(string companyName)
        {
            if (companyName == null)
            {
                if (companyName.Length < 3 && companyName.Length > 50)
                {
                    throw new Exception("Company name cannot be null and needs to be between 3 and 50 character.");
                }
            }

        }

        private void CheckOverview(string overview)
        {
            if (overview == null)
            {
                if (overview.Length < 5 && overview.Length > 200)
                {
                    throw new Exception("Company overview cannot be null and needs to be between 5 and 200 character.");
                }
            }
        }

        private void CheckAddress(string adress)
        {
            if (adress == null)
            {
                if (adress.Length < 5 && adress.Length > 100)
                {
                    throw new Exception("Company address cannot be null and needs to be between 5 and 100 character.");
                }
            }
        }

        private void CheckWeSite(string webSite)
        {
            if (!webSite.EndsWith(".com"))
            {
                throw new Exception("Company web sites has to be finishes with .com extension.");
            }
        }
        #endregion

        #region BaseCRUD
        public IResult Add(Company entity)
        {
            //Check(entity);
            FluentValidationTool.Validate(new CompanyValidator(), entity);

            companyDAL.Add(entity);
            return new SuccessResult(ResultMessage<Company>.Add(entity.ToString()));
        }
        public IResult Update(Company entity)
        {
            //Check(entity);
            FluentValidationTool.Validate(new CompanyValidator(), entity);

            companyDAL.Update(entity);
            return new SuccessResult(ResultMessage<Company>.Update(entity.CompanyName));
        }

        public IResult Delete(Company entity)
        {
            entity.IsActive = false;
            companyDAL.Update(entity);
            return new SuccessResult(ResultMessage<Company>.Delete(entity.CompanyName));
        }

        public IResult Delete(int id)
        {
            Company company = Get(id).Data;
            company.IsActive = false;
            companyDAL.Update(company);
            return new SuccessResult(ResultMessage<Company>.Delete(company.CompanyName));
        }

        public IDataResult<Company> Get(int id)
        {
            return new SuccessDataResult<Company>(companyDAL.Get(a => a.ID == id));
        }

        public IDataResult<ICollection<Company>> GetAll()
        {
            return new SuccessDataResult<ICollection<Company>>((companyDAL.GetAll(a => a.IsActive == true)));
        }
        #endregion

        public IDataResult<ICollection<Company>> GetTopSix()
        {
            return new SuccessDataResult<ICollection<Company>>(companyDAL.GetTopSix());
        }

        public IDataResult<ICollection<Company>> GetCompaniesByFLetter(string fLetter)
        {
            char letter = fLetter[0];
            if (char.IsDigit(letter))
            {
                char[] number = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                List<Company> companies = new List<Company>();
                foreach (char item in number)
                {
                    companies.AddRange(companyDAL.GetAll(a => a.CompanyName.StartsWith(item.ToString())));
                }
                return new SuccessDataResult<ICollection<Company>>(companies);

            }


            fLetter = fLetter.ToString().ToUpper();
            return new SuccessDataResult<ICollection<Company>>(companyDAL.GetAll(a => a.CompanyName.StartsWith(fLetter)));
        }

        public IDataResult<ICollection<Company>> GetCompaniesBySubCatID(int id)
        {
            return new SuccessDataResult<ICollection<Company>>(companyDAL.GetAll(a => a.SubCategoryID == id));
        }

    }
}
