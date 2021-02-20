using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.UI.MVC.Helper;
using MakeJobWell.UI.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Controllers
{
    public class CommentController : Controller
    {
        ICommentBLL commentBLL;
        ILogger _logger;
        public CommentController(ICommentBLL bLL, ILogger<CommentController> logger)
        {
            commentBLL = bLL;
            this._logger = logger;
        }
        public IActionResult SetComplaints([FromBody] List<CommentVM> comments)
        {
            return PartialView("_commentsSet", comments);
        }

        [HttpPost]
        public IActionResult WriteComment([FromBody] CommentInsertVM commentInsert)
        {
            User currenUser = HttpContext.Session.Get<User>("currentUser");
            if (currenUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Comment comment = new Comment()
            {
                CommentText = commentInsert.CommentText,
                ComplaintID = commentInsert.ComplaintID,
                UserID = currenUser.ID
            };

            if (comment != null)
            {
                try
                {
                    commentBLL.Add(comment);
                    this._logger.LogInformation($"New comment inserted by {currenUser.FirstName}.");
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return View();
        }
    }
}
