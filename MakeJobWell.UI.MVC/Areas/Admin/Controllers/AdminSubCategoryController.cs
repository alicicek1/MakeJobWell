using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MakeJobWell.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSubCategoryController : Controller
    {
        ICategoryBLL categoryBLL;
        ISubCategoryBLL subCategoryBLL;
        public AdminSubCategoryController(ICategoryBLL bLL, ISubCategoryBLL sub)
        {
            categoryBLL = bLL;
            subCategoryBLL = sub;
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
            SubCategory subCategory = new SubCategory();
            if (ModelState.IsValid)
            {
                subCategory.CategoryName = subCategoryVM.SubCategoryName;
                subCategory.Description = subCategoryVM.Overview;
                subCategory.CategoryID = subCategoryVM.CatID;
                if (subCategory != null)
                {
                    subCategoryBLL.Add(subCategory);
                }
            }
            return View("Index");
        }

        public IActionResult UpdateSubCategory(int id)
        {
            SubCategory subCategory = subCategoryBLL.Get(id).Data;
            return View(GetSubCategoryVM(subCategory));
        }

        [HttpPost]
        public IActionResult UpdateSubCategory(SubCategoryVM subCategoryVM, int id)
        {
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
                        subCategoryBLL.Update(subCategory);
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
