using MakeJobWell.UI.MVC.Models.ViewModels;
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
        public IActionResult SetAllCategories([FromBody] List<CategoryVM> categories)
        {
            if (categories == null)
            {
                ViewBag.Message = "Categories not found!";
            }
            return PartialView("_setCategories", categories);
        }

        [HttpPost]
        public IActionResult SetAllSubCategories([FromBody] List<SubCategoryVM> subCategories)
        {
            if (subCategories == null)
            {
                ViewBag.Message = "SubCategories not found!";
            }
            return PartialView("_setSubCategories", subCategories);

        }
    }
}
