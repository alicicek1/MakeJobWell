using MakeJobWell.BLL.Abstract.IRepositorories;
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
    public class CommentController : Controller
    {
        ICommentBLL commentBLL;
        public CommentController(ICommentBLL bLL)
        {
            commentBLL = bLL;
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
                return RedirectToAction("Index","Home");
            }
            Comment comment = new Comment()
            {
                CommentText = commentInsert.CommentText,
                ComplaintID = commentInsert.ComplaintID,
                UserID = currenUser.ID
            };

            if (comment != null)
            {
                commentBLL.Add(comment);
            }

            return View();
        }
    }
}
