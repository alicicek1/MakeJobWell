using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.BLL.Concrete.EntityValidation;
using MakeJobWell.BLL.Constant;
using MakeJobWell.Core.CrossCuttingConcerns.Validation.FluentVal;
using MakeJobWell.Core.Utilities.Result;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;

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
        public IResult Add(Comment entity)
        {
            //Check(entity);
            FluentValidationTool.Validate(new CommentValidator(), entity);

            commentDAL.Add(entity);
            return new SuccessResult(ResultMessage<Comment>.Add(entity.ToString()));
        }
        public IResult Update(Comment entity)
        {
            //Check(entity);
            FluentValidationTool.Validate(new CommentValidator(), entity);

            commentDAL.Update(entity);
            return new SuccessResult(ResultMessage<Comment>.Update(entity.CommentText));
        }

        public IResult Delete(Comment entity)
        {
            entity.IsActive = false;
            commentDAL.Update(entity);
            return new SuccessResult(ResultMessage<Comment>.Delete(entity.CommentText));
        }

        public IResult Delete(int id)
        {
            Comment comment = Get(id).Data;
            comment.IsActive = false;
            commentDAL.Update(comment);
            return new SuccessResult(ResultMessage<Comment>.Delete(comment.CommentText));
        }

        public IDataResult<Comment> Get(int id)
        {
            return new SuccessDataResult<Comment>(commentDAL.Get(a => a.ID == id));
        }

        public IDataResult<ICollection<Comment>> GetAll()
        {
            return new SuccessDataResult<ICollection<Comment>>(commentDAL.GetAll(a => a.IsActive == true));
        }
        #endregion

        public IDataResult<ICollection<Comment>> GetCommentsWUsersByComplaintID(int id)
        {
            return new SuccessDataResult<ICollection<Comment>>(commentDAL.GetAll(a => a.ComplaintID == id, a => a.User));
        }
    }
}
