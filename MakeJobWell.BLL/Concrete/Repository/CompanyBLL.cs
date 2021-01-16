using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void Add(Company entity)
        {
            Check(entity);
            companyDAL.Add(entity);
        }
        public void Update(Company entity)
        {
            Check(entity);
            companyDAL.Update(entity);
        }

        public void Delete(Company entity)
        {
            entity.IsActive = false;
            companyDAL.Update(entity);
        }

        public void Delete(int id)
        {
            Company company = Get(id);
            company.IsActive = false;
            companyDAL.Update(company);
        }

        public Company Get(int id)
        {
            return companyDAL.Get(a => a.ID == id);
        }

        public ICollection<Company> GetAll()
        {
            return companyDAL.GetAll();
        }
        #endregion

        public ICollection<Company> GetTopSix()
        {
            return companyDAL.GetTopSix();
        }

        public ICollection<Company> GetCompaniesByFLetter(string fLetter)
        {
            //char letter = fLetter[0];
            //if (char.IsDigit(letter))
            //{
            //    char[] number = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            //    List<Company> companies = new List<Company>();
            //    foreach (char item in number)
            //    {
            //        companies.AddRange(companyDAL.GetAll(a => a.CompanyName.StartsWith(item)));
            //    }
            //    return companies;

            //}


            fLetter = fLetter.ToString().ToUpper();
            return companyDAL.GetAll(a => a.CompanyName.StartsWith(fLetter));
        }

        public ICollection<Company> GetCompaniesBySubCatID(int id)
        {
            return companyDAL.GetAll(a => a.SubCategoryID == id);
        }

    }
}
