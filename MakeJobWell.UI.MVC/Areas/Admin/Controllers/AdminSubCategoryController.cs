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
    public class AdminSubCategoryController : Controller
    {
        ICategoryBLL categoryBLL;
        ISubCategoryBLL subCategoryBLL;
        private readonly ILogger _logger;
        public AdminSubCategoryController(ICategoryBLL bLL, ISubCategoryBLL sub, ILogger<AdminSubCategoryController> logger)
        {
            categoryBLL = bLL;
            subCategoryBLL = sub;
            this._logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetSubCategories([FromBody] List<SubCategoryVM> categories)
        {
            if (categories == null)
            {
                ViewBag.Message = "SubCategories not found";
            }
            return PartialView("_setSubCategories", categories);
        }

        SubCategoryVM GetSubCategoryVM(SubCategory subCategory = null)
        {
            SubCategoryVM subCategoryVM = new SubCategoryVM();
            foreach (Category item in categoryBLL.GetAll().Data)
            {
                subCategoryVM.Categories.Add(new SelectListItem
                {
                    Text = item.CategoryName,
                    Value = item.ID.ToString()
                });
            }
            if (subCategory != null)
            {
                subCategoryVM.SubCategoryName = subCategory.CategoryName;
                subCategoryVM.Overview = subCategory.Description;
                subCategoryVM.CatID = subCategory.CategoryID;
            }
            return subCategoryVM;
        }

        public IActionResult InsertSubCategory()
        {
            return View(GetSubCategoryVM());
        }

        [HttpPost]
        public IActionResult InsertSubCategory(SubCategoryVM subCategoryVM)
        {
            User currentAdmin = GetCurrentAdmin();
            SubCategory subCategory = new SubCategory();
            if (ModelState.IsValid)
            {
                subCategory.CategoryName = subCategoryVM.SubCategoryName;
                subCategory.Description = subCategoryVM.Overview;
                subCategory.CategoryID = subCategoryVM.CatID;
                if (subCategory != null)
                {
                    try
                    {
                        subCategoryBLL.Add(subCategory);
                        this._logger.LogInformation($"AdminID : {currentAdmin.ID} is inserted the SubCategoryID : {subCategory.ID}.");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return View("Index");
        }

        private User GetCurrentAdmin()
        {
            return HttpContext.Session.Get<User>("currentUser");
        }

        public IActionResult UpdateSubCategory(int id)
        {
            SubCategory subCategory = subCategoryBLL.Get(id).Data;
            return View(GetSubCategoryVM(subCategory));
        }

        [HttpPost]
        public IActionResult UpdateSubCategory(SubCategoryVM subCategoryVM, int id)
        {
            User currentAdmin = GetCurrentAdmin();
            SubCategory subCategory = subCategoryBLL.Get(id).Data;
            try
            {
                if (ModelState.IsValid)
                {
                    subCategory.CategoryName = subCategoryVM.SubCategoryName;
                    subCategory.Description = subCategoryVM.Overview;
                    subCategory.CategoryID = subCategoryVM.CatID;
                    if (subCategory != null)
                    {
                        try
                        {
                            subCategoryBLL.Update(subCategory);
                            this._logger.LogInformation($"AdminID : {currentAdmin.ID} is updated  SubCategoryID : {subCategory.ID}.");
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
                return View("Index");
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
