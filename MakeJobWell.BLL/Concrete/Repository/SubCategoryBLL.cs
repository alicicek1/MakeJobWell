using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Concrete.Repositories
{
    class SubCategoryBLL : ISubCategoryBLL
    {
        ISubCategoryDAL subCategoryDAL;
        public SubCategoryBLL(ISubCategoryDAL subCategory)
        {
            subCategoryDAL = subCategory;
        }

        #region DataCheck
        void Check(SubCategory entity)
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
        public void Add(SubCategory entity)
        {
            Check(entity);
            subCategoryDAL.Add(entity);
        }
        public void Update(SubCategory entity)
        {
            Check(entity);
            subCategoryDAL.Update(entity);
        }

        public void Delete(SubCategory entity)
        {
            entity.IsActive = false;
            subCategoryDAL.Update(entity);
        }

        public void Delete(int id)
        {
            SubCategory subCategory = Get(id);
            subCategory.IsActive = false;
            subCategoryDAL.Update(subCategory);
        }

        public SubCategory Get(int id)
        {
            return subCategoryDAL.Get(a => a.ID == id);
        }

        public ICollection<SubCategory> GetAll()
        {
            return subCategoryDAL.GetAll(a => a.IsActive == true);
        }
        #endregion

        public ICollection<SubCategory> GetSubCategoriesByCatID(int id)
        {
            return subCategoryDAL.GetAll(a => a.CategoryID == id, a => a.Category);
        }

        public ICollection<SubCategory> GetAllWithCats()
        {
            return subCategoryDAL.GetAll(a => a.IsActive == true, x => x.Category);
        }

    }
}
