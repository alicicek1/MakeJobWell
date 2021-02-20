using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.Models.Enum;
using MakeJobWell.UI.MVC.Helper;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MakeJobWell.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        IUserBLL userBLL;
        private readonly ILogger _logger;
        public AdminUserController(IUserBLL bll, ILogger<AdminCategoryController> logger)
        {
            userBLL = bll;
            this._logger = logger;
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
            User currentAdmin = HttpContext.Session.Get<User>("currentUser");
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
                        try
                        {
                            userBLL.AddAdmin(user);
                            this._logger.LogInformation($"Current admin {currentAdmin.ID}, made ID = {user.ID} admin.");
                        }
                        catch (Exception)
                        {

                            throw;
                        }
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
            User user = userBLL.Get(id).Data;
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
            User currentAdmin = HttpContext.Session.Get<User>("currentUser");
            User user = userBLL.Get(id).Data;
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
                        try
                        {
                            userBLL.Update(user);
                            this._logger.LogInformation($"AdminID : {currentAdmin.ID} is updated UserID : {user.ID}.");
                        }
                        catch (Exception)
                        {

                            throw;
                        }
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
            User currentAdmin = HttpContext.Session.Get<User>("currentUser");
            User user = userBLL.Get(id).Data;
            if (user != null)
            {
                user.UserRole = UserRole.Admin;
                try
                {
                    userBLL.Update(user);
                    this._logger.LogInformation($"Current admin {currentAdmin.ID}, made ID = {user.ID} admin.");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View("Index");
        }
    }
}
