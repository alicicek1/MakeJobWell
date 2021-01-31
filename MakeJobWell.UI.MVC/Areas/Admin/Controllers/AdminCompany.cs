using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Areas.Admin.Controllers
{
    public class AdminCompany : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
