using FluentValidation;
using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.UI.MVC.Helper;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
namespace MakeJobWell.UI.MVC.Controllers
{
    public class ComplaintController : Controller
    {
        IComplaintBLL complaintBLL;
        ICompanyBLL companyBLL;
        private readonly ILogger _logger;
        private readonly IValidator<Complaint> _compValidator;

        public ComplaintController(IComplaintBLL bLL, ICompanyBLL bLL1, IValidator<Complaint> validator, ILogger<ComplaintController> logger)
        {
            complaintBLL = bLL;
            companyBLL = bLL1;
            _compValidator = validator;
            this._logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetComplaints([FromBody] List<ComplaintVM> complaints)
        {
            if (complaints == null)
            {
                ViewBag.Message = "Complaints cannot found!";
            }
            return PartialView("_setComplaints", complaints);
        }


        ComplaintInsertVM GetComplaintInsertVM(Complaint complaint = null)
        {
            ComplaintInsertVM complaintInsert = new ComplaintInsertVM();
            foreach (Company item in companyBLL.GetAll().Data)
            {
                complaintInsert.Companies.Add(new SelectListItem
                {
                    Text = item.CompanyName,
                    Value = item.ID.ToString()
                });
            }
            if (complaint != null)
            {
                complaintInsert.Title = complaint.ComplaintTitle;
                complaintInsert.Detail = complaint.ComplaintDetail;
                complaintInsert.UserID = complaint.UserID;
                complaintInsert.ComplaintProofFile = complaint.ComplaintProofUrl;
                complaintInsert.IncoiceProofFile = complaint.ComplaintInvoiceUrl;
                complaintInsert.CompanyID = complaint.CompanyID;
            }
            return complaintInsert;
        }


        public IActionResult WriteComplaint(int? id)
        {
            if (id != null)
            {
                ComplaintInsertVM complaintInsert = new ComplaintInsertVM();
                foreach (Company item in companyBLL.GetCompaniesBySubCatID(id.Value).Data)
                {
                    complaintInsert.Companies.Add(new SelectListItem
                    {
                        Text = item.CompanyName,
                        Value = item.ID.ToString()
                    });
                }
                return View(complaintInsert);
            }
            return View(GetComplaintInsertVM());
        }


        [HttpPost]
        public IActionResult WriteComplaint(ComplaintInsertVM complaintInsert)
        {
            if (ModelState.IsValid)
            {
                User currentUser = HttpContext.Session.Get<User>("currentUser");
                if (currentUser == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                //HttpContext.Session.Set<User>("currentUser", currentUser);
                //complaintInsert.UserID = currentUser.ID;
                Complaint complaint = new Complaint()
                {
                    ComplaintTitle = complaintInsert.Title,
                    ComplaintDetail = complaintInsert.Detail,
                    UserID = currentUser.ID,
                    CompanyID = complaintInsert.CompanyID
                };
                if (complaint != null)
                {
                    try
                    {
                        complaintBLL.Add(complaint);
                        this._logger.LogInformation($"New complaint inserted by {currentUser.Email} and complaint id = {complaint.ID}.");
                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception)
                    {
                        throw new Exception();
                    }

                }
            }
            return View();
        }

        public IActionResult ComplaintDetail()
        {
            return View();
        }


        public IActionResult DeleteComplaint(int id)
        {
            try
            {
                complaintBLL.Delete(complaintBLL.Get(id).Data);
                this._logger.LogWarning($"Complaint is deleted. ID = {id} ");
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("ProfilePage", "Profile");
        }

    }
}
