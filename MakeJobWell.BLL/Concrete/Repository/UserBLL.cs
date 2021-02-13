using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.BLL.Constant;
using MakeJobWell.Core.Utilities.Result;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using MakeJobWell.Models.Enum;
using System;
using System.Collections.Generic;

namespace MakeJobWell.BLL.Concrete.Repositories
{
    class UserBLL : IUserBLL
    {
        IUserDAL userDAL;
        public UserBLL(IUserDAL user)
        {
            userDAL = user;
        }

        #region CheckData
        void Check(User entity)
        {
            CheckFirstName(entity.FirstName);
            CheckLastName(entity.LastName);
            CheckPassword(entity.Password);
            CheckUserName(entity.UserName);
            CheckEmail(entity.Email);
        }

        private void CheckEmail(string email)
        {
            if (!email.Contains("@") && !email.EndsWith(".com"))
            {
                throw new Exception("Unordered E-mail format!");
            }
        }

        private void CheckUserName(string userName)
        {
            if (userName == null)
            {
                throw new Exception("UserName cannot be null.");
            }
        }

        private void CheckPassword(string password)
        {
            if (password == null)
            {
                throw new Exception("Password cannot be null.");
            }
        }

        private void CheckLastName(string lastName)
        {
            if (lastName.Length < 2)
            {
                throw new Exception("Last name has to be longer than 2 characters.");
            }
        }

        private void CheckFirstName(string firstName)
        {
            if (firstName.Length < 2)
            {
                throw new Exception("First name has to be longer than 2 characters.");
            }
        }
        #endregion

        #region BaseCRUD
        public IResult Add(User entity)
        {
            Check(entity);
            entity.ActivationCode = Guid.NewGuid();
            entity.UserRole = UserRole.Standart;
            userDAL.Add(entity);
            return new SuccessResult(ResultMessage<User>.Add(entity.ToString()));
        }
        public IResult AddAdmin(User entity)
        {
            Check(entity);
            entity.ActivationCode = Guid.NewGuid();
            entity.UserRole = UserRole.Admin;
            userDAL.Add(entity);
            return new SuccessResult(ResultMessage<User>.Add($"{entity.ToString()} (As an admin.)"));
        }
        public IResult Update(User entity)
        {
            Check(entity);
            userDAL.Update(entity);
            return new SuccessResult(ResultMessage<User>.Update(entity.FirstName));
        }

        public IResult Delete(User entity)
        {
            entity.IsActive = false;
            userDAL.Update(entity);
            return new SuccessResult(ResultMessage<User>.Delete(entity.FirstName));
        }

        public IResult Delete(int id)
        {
            User user = Get(id).Data;
            user.IsActive = false;
            userDAL.Update(user);
            return new SuccessResult(ResultMessage<User>.Delete(user.FirstName));
        }

        public IResult DeleteByUserName(string username)
        {
            User user = GetByUserName(username).Data;
            user.IsActive = false;
            userDAL.Update(user);
            return new SuccessResult(ResultMessage<User>.Delete(user.FirstName));
        }

        public IDataResult<User> GetByUserName(string username)
        {
            return new SuccessDataResult<User>(userDAL.Get(a => a.UserName == username));
        }

        public IDataResult<User> Get(int id)
        {
            return new SuccessDataResult<User>(userDAL.Get(a => a.ID == id));
        }

        public IDataResult<ICollection<User>> GetAll()
        {
            return new SuccessDataResult<ICollection<User>>(userDAL.GetAll(a => a.IsActive == true));
        }
        #endregion

        public IDataResult<User> GetUserByActivationCode(Guid guid)
        {
            return new SuccessDataResult<User>(userDAL.Get(a => a.ActivationCode == guid));
        }

        public IDataResult<User> GetUserByEmailandPassword(string email, string password)
        {
            return new SuccessDataResult<User>(userDAL.Get(a => a.Email == email && a.Password == password && a.IsActive));
        }

    }
}
