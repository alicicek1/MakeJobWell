using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Areas.AdminsArea.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        IUserBLL userBLL;
        public AdminController(IUserBLL bLL)
        {
            userBLL = bLL;
        }
        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            User user = userBLL.Get(id);
            UserVM userVM = new UserVM()
            {
                FirstName=user.FirstName,
                LastName=user.LastName,
                Email=user.Email
            };
            return View(userVM);
        }
    }
}
