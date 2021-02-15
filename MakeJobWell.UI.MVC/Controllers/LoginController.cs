using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.BLL.Abstract.IRepository;
using MakeJobWell.Models.Entities;
using MakeJobWell.Models.Enum;
using MakeJobWell.UI.MVC.Helper;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MakeJobWell.UI.MVC.Controllers
{
    public class LoginController : Controller
    {
        IUserBLL userBLL;
        IEmailSender emailSender;
        public LoginController(IUserBLL bll, IEmailSender sender)
        {
            userBLL = bll;
            emailSender = sender;
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAccount(UserVM userVM)
        {
            try
            {
                if (userVM.Password == userVM.PasswordRepaet)
                {
                    User user = new User();
                    user.FirstName = userVM.FirstName;
                    user.LastName = userVM.LastName;
                    user.Email = userVM.Email;
                    user.UserName = userVM.UserName;
                    user.Password = userVM.Password;

                    if (user != null)
                    {
                        userBLL.Add(user);
                    }

                    bool result = MailHelper.SendActivationCode(user.FirstName, user.Email, user.ActivationCode);
                    emailSender.Sender(user.FirstName, user.Email, user.ActivationCode);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Actication mail couldn't send, please check your infos";
                    }

                }
                else
                {
                    ViewBag.Password = "Passwords do not match."; 
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Mesaage = ($"Something went wrong. /{0}", ex);
                return View();
            }

            return View();
        }

        public IActionResult ActiveUser(Guid id)
        {
            User newUser = userBLL.GetUserByActivationCode(id).Data;
            if (newUser != null)
            {
                newUser.IsActive = true;
                userBLL.Update(newUser);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "There is no such as user for being activated";
                return View();
            }
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserVM userVM)
        {
            User loginUser = userBLL.GetUserByEmailandPassword(userVM.Email, userVM.Password).Data;
            if (loginUser != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email,loginUser.Email),
                    new Claim(ClaimTypes.Role,loginUser.UserRole.ToString())
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                HttpContext.Session.Set<User>("currentUser", loginUser);


                if (loginUser.UserRole == UserRole.Standart)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Admin", loginUser.ID);
                }
            }
            else
            {
                ViewBag.Message = "Check your infos";
                return View();
            }
        }

        public IActionResult CheckUserExisting()
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
            return PartialView("_userCheckCard", user);

        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("currentUser");
            return RedirectToAction("Index", "Home");
        }
    }
}
