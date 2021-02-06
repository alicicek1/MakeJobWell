using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Concrete.Repositories
{
    class CommentBLL : ICommentBLL
    {
        ICommentDAL commentDAL;
        public CommentBLL(ICommentDAL comment)
        {
            commentDAL = comment;
        }

        #region CheckData
        void Check(Comment entity)
        {
            CheckText(entity.CommentText);
        }

        private void CheckText(string commentText)
        {
            if (commentText.Length < 2 && commentText.Length > 200)
            {
                throw new Exception("Comment needs to be between 2 and 200 character.");
            }
        } 
        #endregion

        #region BaseCRUD
        public void Add(Comment entity)
        {
            Check(entity);
            commentDAL.Add(entity);
        }
        public void Update(Comment entity)
        {
            Check(entity);
            commentDAL.Update(entity);
        }

        public void Delete(Comment entity)
        {
            entity.IsActive = false;
            commentDAL.Update(entity);
        }

        public void Delete(int id)
        {
            Comment comment = Get(id);
            comment.IsActive = false;
            commentDAL.Update(comment);
        }

        public Comment Get(int id)
        {
            return commentDAL.Get(a => a.ID == id);
        }

        public ICollection<Comment> GetAll()
        {
            return commentDAL.GetAll(a => a.IsActive == true);
        }
        #endregion

        public ICollection<Comment> GetCommentsWUsersByComplaintID(int id)
        {
            return commentDAL.GetAll(a => a.ComplaintID == id, a => a.User);
        }
    }
}
