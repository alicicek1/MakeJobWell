using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MakeJobWell.BLL.Concrete.Repository
{
    class CategoryBLL : ICategoryBLL
    {
        ICategoryDAL categoryDAL;
        public CategoryBLL(ICategoryDAL category)
        {
            categoryDAL = category;
        }

        #region DataCheck
        void Check(Category entity)
        {
            CheckCategoryName(entity.CategoryName);
            CheckDescription(entity.Description);
        }

        private void CheckCategoryName(string categoryName)
        {
            if (categoryName.Length < 2)
            {
                throw new Exception("Category name needs to be at least 2 character");
            }
        }

        private void CheckDescription(string description)
        {
            if (description.Length < 10 && description.Length > 250)
            {
                throw new Exception("Category description needs to be between 10 and 250 character.");
            }
        }
        #endregion

        #region BaseCRUD
        public void Add(Category entity)
        {
            Check(entity);
            categoryDAL.Add(entity);
        }
        public void Update(Category entity)
        {
            Check(entity);
            categoryDAL.Update(entity);
        }

        public void Delete(Category entity)
        {
            entity.IsActive = false;
            categoryDAL.Update(entity);
        }

        public void Delete(int id)
        {
            Category category = Get(id);
            category.IsActive = false;
            categoryDAL.Update(category);
        }

        public Category Get(int id)
        {
            return categoryDAL.Get(a => a.ID == id);
        }

        public ICollection<Category> GetAll()
        {
            return categoryDAL.GetAll(a => a.IsActive == true);
        }
        #endregion

        public ICollection<Category> GetLatestSix()
        {
            return categoryDAL.GetAll().OrderByDescending(a => a.CreatedDate).Take(6).ToList();
        }

        public ICollection<Category> GetCatWSubCats()
        {
            return categoryDAL.GetAll(a => a.IsActive, a => a.SubCategories).ToList();
        }

        

    }
}
