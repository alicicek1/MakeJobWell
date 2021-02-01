using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        ICategoryBLL categoryBLL;
        public AdminCategoryController(ICategoryBLL bLL)
        {
            categoryBLL = bLL;
        }
        public IActionResult Index()
        {
            return View();
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
            Category category = new Category
            {
                CategoryName = categoryVM.CategoryName,
                Description = categoryVM.Overview
            };
            if (category != null)
            {
                categoryBLL.Add(category);
            }
            else
            {
                ViewBag.Message = "Check your datas.";
            }
            return View("Index");
        }


    }
}
