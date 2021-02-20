using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.UI.MVC.Helper;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MakeJobWell.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCompanyController : Controller
    {
        ISubCategoryBLL SubCategoryBLL;
        ICompanyBLL companyBLL;
        private readonly ILogger _logger;
        public AdminCompanyController(ISubCategoryBLL sub, ICompanyBLL bLL, ILogger<AdminCompanyController> logger)
        {
            SubCategoryBLL = sub;
            companyBLL = bLL;
            this._logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetCompanies([FromBody] List<CompanyVM> companies)
        {
            if (companies == null)
            {
                ViewBag.Message = "Companies not found";
            }
            return PartialView("_setCompanies", companies);
        }

        private User GetCurrentAdmin()
        {
            return HttpContext.Session.Get<User>("currentUser");
        }

        CompanyVM GetCompanyVM(Company company = null)
        {
            CompanyVM companyVM = new CompanyVM();
            foreach (SubCategory item in SubCategoryBLL.GetAll().Data)
            {
                companyVM.SubCategories.Add(new SelectListItem
                {
                    Text = item.CategoryName,
                    Value = item.ID.ToString()
                });
            }
            if (company != null)
            {
                companyVM.CompanyName = company.CompanyName;
                companyVM.Overview = company.Overview;
                companyVM.WebSite = company.WebSite;
                companyVM.Location = company.Location;
                companyVM.SubCatID = company.SubCategoryID;
            }
            return companyVM;
        }

        public IActionResult InsertCompany()
        {
            return View(GetCompanyVM());
        }
        [HttpPost]
        public IActionResult InsertCompany(CompanyVM companyVM)
        {
            User currentAdmin = GetCurrentAdmin();
            Company company = new Company();

            if (ModelState.IsValid)
            {
                company.CompanyName = companyVM.CompanyName;
                company.Overview = companyVM.Overview;
                company.WebSite = companyVM.WebSite;
                company.Location = companyVM.Location;
                company.SubCategoryID = companyVM.SubCatID;
                company.Adress = "defauladresdefauladresdefauladres";
                if (company != null)
                {
                    try
                    {
                        companyBLL.Add(company);
                        this._logger.LogInformation($"AdminID : {currentAdmin.ID} is created  CompanyID : {company.ID}.");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return View("Index");
        }

        public IActionResult UpdateCompany(int id)
        {
            Company company = companyBLL.Get(id).Data;
            return View(GetCompanyVM(company));
        }

        [HttpPost]
        public IActionResult UpdateCompany(CompanyVM companyVM, int id)
        {
            User currentAdmin = GetCurrentAdmin();
            Company company = companyBLL.Get(id).Data;
            try
            {
                if (ModelState.IsValid)
                {
                    company.CompanyName = companyVM.CompanyName;
                    company.Overview = companyVM.Overview;
                    company.Location = companyVM.Location;
                    company.WebSite = companyVM.WebSite;
                    company.SubCategoryID = companyVM.SubCatID;

                    if (company != null)
                    {
                        try
                        {
                            companyBLL.Update(company);
                            this._logger.LogInformation($"AdminID : {currentAdmin.ID} is updated  CompanyID : {company.ID}.");
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        ViewBag.IsSuccess = true;
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                ViewBag.IsSuccess = false;
            }
            return View("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            User currentAdmin = GetCurrentAdmin();
            try
            {
                companyBLL.Delete(id);
                this._logger.LogInformation($"AdminID : {currentAdmin.ID} is updated  CompanyID : {id}.");
            }
            catch (Exception)
            {

                throw;
            }
            return View("Index");
        }

    }
}
