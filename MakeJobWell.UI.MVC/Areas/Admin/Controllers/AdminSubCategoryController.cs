using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSubCategoryController : Controller
    {
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
    }
}
