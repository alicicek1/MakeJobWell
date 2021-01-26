using MakeJobWell.Models.Entities;
using MakeJobWell.UI.MVC.Helper;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult ProfilePage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProfilePage([FromBody] UserVM user)
        {
            if (user == null)
            {
                ViewBag.Message = "User cannot found!";
            }
            return PartialView("_profileCard", user);
        }

        public IActionResult SetComplaintsForUser([FromBody] List<ComplaintVM> complaints)
        {
            if (complaints == null)
            {
                ViewBag.Message = "Complaints cannot found!";
            }
            return PartialView("_setComplaints", complaints);
        }

        public IActionResult UpdateProfile()
        {
            return View();
        }
    }
}
