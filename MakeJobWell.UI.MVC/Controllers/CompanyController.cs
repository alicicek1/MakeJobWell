using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Controllers
{
    public class CompanyController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetCompanies([FromBody] List<CompanyVM> companies)
        {
            if (companies == null)
            {
                ViewBag.Message = "Categories not found!";
            }
            return PartialView("_setCompanies", companies);
        }

        public IActionResult CompanyDetail()
        {
            return View();
        }

        public IActionResult SetComplaints([FromBody] List<ComplaintVM> complaints)
        {
            if (complaints.Count == 0)
            {
                ViewBag.Message = "No Complaints Yet!";
            }
            return PartialView("_setComplaints", complaints);
        }

        public IActionResult CompaniesByFirstLetter([FromBody] List<CompanyVM> companies)
        {
            if (companies == null)
            {
                ViewBag.Message = "Categories not found!";
            }
            return PartialView("_setCompanies", companies);
        }
    }
}
