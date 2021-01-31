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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetCategories([FromBody] List<CategoryVM> categories)
        {
            if (categories==null)
            {
                ViewBag.Message = "Categories not found";
            }
            return PartialView("_setCategories", categories);

        }

        public IActionResult InsertCategory()
        {
            return View();
        }
    }
}
