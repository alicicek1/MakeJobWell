using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.UI.MVC.Helper;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MakeJobWell.UI.MVC.Areas.AdminsArea.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        IUserBLL userBLL;
        public AdminController(IUserBLL bLL)
        {
            userBLL = bLL;
        }

        public IActionResult Index()
        {
            User currentUser = HttpContext.Session.Get<User>("currentUser");
            if (currentUser == null)
            {
                return PartialView("_userCheckCard");
            }
            UserVM user = new UserVM()
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email,
                ID = currentUser.ID
            };
            return View(user);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("currentUser");
            return RedirectToAction("Index", "Home");
        }
    }
}
