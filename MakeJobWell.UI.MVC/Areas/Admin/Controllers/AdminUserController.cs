using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.UI.MVC.Helper;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        IUserBLL userBLL;
        public AdminUserController(IUserBLL bll)
        {
            userBLL = bll;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetUsers([FromBody] List<UserVM> users)
        {
            if (users == null)
            {
                ViewBag.Message = "Users not found";
            }
            return PartialView("_setUsers", users);
        }

        public IActionResult InsertUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertUser(UserVM userVM)
        {
            try
            {
                if (userVM.Password == userVM.PasswordRepaet)
                {
                    User user = new User
                    {
                        FirstName = userVM.FirstName,
                        LastName = userVM.LastName,
                        Email = userVM.Email,
                        UserName = userVM.UserName,
                        Password = userVM.Password,
                        PhoneNumber = userVM.PhoneNumber,
                        Address = userVM.Address
                    };
                    if (user != null)
                    {
                        userBLL.AddAdmin(user);
                        bool result = MailHelper.SendActivationCode(user.FirstName, user.Email, user.ActivationCode);
                        if (result)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.MessageMail = "Actication mail couldn't send, please check your infos";
                        }
                    }
                }
                else
                {
                    ViewBag.Password = "Passwords do not match.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }
    }
}
