using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using MakeJobWell.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void Add(User entity)
        {
            Check(entity);
            entity.ActivationCode = Guid.NewGuid();
            entity.UserRole = UserRole.Standart;
            userDAL.Add(entity);
        }
        public void AddAdmin(User entity)
        {
            Check(entity);
            entity.ActivationCode = Guid.NewGuid();
            entity.UserRole = UserRole.Admin;
            userDAL.Add(entity);
        }
        public void Update(User entity)
        {
            Check(entity);
            userDAL.Update(entity);
        }

        public void Delete(User entity)
        {
            entity.IsActive = false;
            userDAL.Update(entity);
        }

        public void Delete(int id)
        {
            User user = Get(id);
            user.IsActive = false;
            userDAL.Update(user);
        }

        public User Get(int id)
        {
            return userDAL.Get(a => a.ID == id);
        }

        public ICollection<User> GetAll()
        {
            return userDAL.GetAll();
        }
        #endregion

        public User GetUserByActivationCode(Guid guid)
        {
            User newUser = userDAL.Get(a => a.ActivationCode == guid);
            return newUser;
        }

        public User GetUserByEmailandPassword(string email, string password)
        {
            User loginUser = userDAL.Get(a => a.Email == email && a.Password == password && a.IsActive);
            return loginUser;
        }

    }
}
