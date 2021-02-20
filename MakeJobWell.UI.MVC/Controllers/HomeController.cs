using MakeJobWell.Core.Exceptions;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        //[CustomHandlerExceptionFilterAttribute(ErrorPage = "~/Views/Error/CustomError.cshtml")]

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }
        public IActionResult Index()
        {
            this._logger.LogInformation("Index page has been entered...");
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
