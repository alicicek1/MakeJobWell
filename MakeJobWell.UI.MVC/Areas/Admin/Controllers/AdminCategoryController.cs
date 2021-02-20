using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.UI.MVC.Helper;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MakeJobWell.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        ICategoryBLL categoryBLL;
        private readonly ILogger _logger;
        public AdminCategoryController(ICategoryBLL bLL, ILogger<AdminCategoryController> logger)
        {
            categoryBLL = bLL;
            this._logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        private User GetCurrentAdmin()
        {
            return HttpContext.Session.Get<User>("currentUser");
        }

        [HttpPost]
        public IActionResult SetCategories([FromBody] List<CategoryVM> categories)
        {
            if (categories == null)
            {
                ViewBag.Message = "Categories not found";
            }
            return PartialView("_setCategories", categories);

        }

        public IActionResult InsertCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertCategory(CategoryVM categoryVM)
        {
            User currentAdmin = GetCurrentAdmin();
            Category category = new Category
            {
                CategoryName = categoryVM.CategoryName,
                Description = categoryVM.Overview
            };
            if (category != null)
            {
                try
                {
                    categoryBLL.Add(category);
                    this._logger.LogInformation($"AdminID : {currentAdmin.ID} is created CategoryID : {category.ID}.");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                ViewBag.Message = "Check your datas.";
            }
            return View("Index");
        }


        public IActionResult UpdateCategory(int id)
        {
            Category category = categoryBLL.Get(id).Data;
            CategoryVM categoryVM = new CategoryVM
            {
                CategoryName = category.CategoryName,
                Overview = category.Description
            };
            return View(categoryVM);
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryVM categoryVM, int id)
        {
            User currentAdmin = GetCurrentAdmin();
            Category category = categoryBLL.Get(id).Data;
            try
            {
                if (ModelState.IsValid)
                {
                    category.CategoryName = categoryVM.CategoryName;
                    category.Description = categoryVM.Overview;

                    if (category != null)
                    {
                        try
                        {
                            categoryBLL.Update(category);
                            this._logger.LogInformation($"AdminID : {currentAdmin.ID} is updated CategoryID : {category.ID}");
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
    }
}
