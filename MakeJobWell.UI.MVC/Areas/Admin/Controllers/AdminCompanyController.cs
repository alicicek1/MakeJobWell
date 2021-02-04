using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCompanyController : Controller
    {
        ISubCategoryBLL SubCategoryBLL;
        ICompanyBLL companyBLL;
        public AdminCompanyController(ISubCategoryBLL sub, ICompanyBLL bLL)
        {
            SubCategoryBLL = sub;
            companyBLL = bLL;
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


        CompanyVM GetCompanyVM(Company company = null)
        {
            CompanyVM companyVM = new CompanyVM();
            foreach (SubCategory item in SubCategoryBLL.GetAll())
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
                    companyBLL.Add(company);
                }
            }
            return View("Index");
        }

        public IActionResult UpdateCompany(int id)
        {
            Company company = companyBLL.Get(id);
            return View(GetCompanyVM(company));
        }

        [HttpPost]
        public IActionResult UpdateCompany(CompanyVM companyVM, int id)
        {
            Company company = companyBLL.Get(id);
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
                        companyBLL.Update(company);
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
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            companyBLL.Delete(id);
            return View("Index");
        }

    }
}
