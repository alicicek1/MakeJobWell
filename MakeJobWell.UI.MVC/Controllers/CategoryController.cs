using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetAllCategories([FromBody] List<CategoryVM> categories)
        {
            if (categories == null)
            {
                ViewBag.Message = "Categories not found!";
            }
            return PartialView("_setCategories", categories);
        }

        public IActionResult CategoryDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetSubCategories([FromBody] List<SubCategoryVM> subCategories)
        {
            if (subCategories == null)
            {
                ViewBag.Message = "SubCategories not found!";
            }
            return PartialView("_setSubCategories", subCategories);

        }

        [HttpPost]
        public IActionResult SetCategoriestoList([FromBody] List<CategoryVM> categories) 
        {
            if (categories == null)
            {
                ViewBag.Message = "CategoriestoList not found!";
            }
            return PartialView("_setCategoriestoList", categories);
        }
    }
}
