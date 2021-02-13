using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.Service.WebAPI.Models.RelatedEntities;
using MakeJobWell.Service.WebAPI.Models.SelfEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.Service.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentBLL commentBLL;
        public CommentController(ICommentBLL comment)
        {
            commentBLL = comment;
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentsByComplaitID(int id)
        {
            List<CommentDTO> commentDTOs = new List<CommentDTO>();
            try
            {
                foreach (Comment item in commentBLL.GetCommentsWUsersByComplaintID(id).Data)
                {
                    commentDTOs.Add(new CommentDTO
                    {
                        UserName = item.User.UserName,
                        CommentText = item.CommentText
                    });
                }
                return Ok(commentDTOs);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpPost]
        public IActionResult WriteComplaint(int id)
        {
            Comment comment = new Comment();
            //comment.CommentText = text;
            comment.ComplaintID = id;
            comment.UserID =2;
            if (comment != null)
            {
                commentBLL.Add(comment);
            }
            return Ok();
        }
    }
}
