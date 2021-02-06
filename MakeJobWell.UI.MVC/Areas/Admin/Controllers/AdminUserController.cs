using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.Models.Enum;
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
            return View("Index");
        }

        public IActionResult UpdateUser(int id)
        {
            User user = userBLL.Get(id);
            UserVM userVM = new UserVM
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Gender = user.Gender
            };
            return View(userVM);
        }
        [HttpPost]
        public IActionResult UpdateUser(UserVM userVM, int id)
        {
            User user = userBLL.Get(id);
            try
            {
                if (ModelState.IsValid)
                {
                    user.FirstName = userVM.FirstName;
                    user.LastName = userVM.LastName;
                    user.Email = userVM.Email;
                    user.UserName = userVM.UserName;
                    user.Password = userVM.Password;
                    user.PhoneNumber = userVM.PhoneNumber;
                    user.Address = userVM.Address;
                    user.Gender = userVM.Gender;
                    if (user != null)
                    {
                        userBLL.Update(user);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return View("Index");
        }

        public IActionResult MakeAdminUser(int id)
        {
            User user = userBLL.Get(id);
            if (user != null)
            {
                user.UserRole = UserRole.Admin;
                userBLL.Update(user);
            }
            return View("Index");
        }
    }
}
