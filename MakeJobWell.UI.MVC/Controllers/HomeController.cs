using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Controllers
{
    public class HomeController : Controller
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
        public IActionResult SetTopSixCategories([FromBody] List<CategoryVM> categories)
        {
            if (categories == null)
            {
                ViewBag.Message = "Categories not found!";
            }
            return PartialView("_setCategories", categories);
        }
        [HttpPost]
        public IActionResult SetTopSixCompany([FromBody] List<CompanyVM> companies)
        {
            if (companies == null)
            {
                ViewBag.Message = "Companies not found!";
            }
            return PartialView("_setCompanies", companies);
        }
        [HttpPost]
        public IActionResult SetTopSixComplaint([FromBody] List<ComplaintVM> complaints)
        {
            if (complaints == null)
            {
                ViewBag.Message = "Companies not found!";
            }
            return PartialView("_setComplaints", complaints);
        }
    }
}
