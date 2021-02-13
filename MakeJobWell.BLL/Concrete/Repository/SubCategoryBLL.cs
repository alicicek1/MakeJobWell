using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.BLL.Constant;
using MakeJobWell.Core.Utilities.Result;
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
        public IResult Add(SubCategory entity)
        {
            Check(entity);
            subCategoryDAL.Add(entity);
            return new SuccessResult(ResultMessage<SubCategory>.Add(entity));
        }
        public IResult Update(SubCategory entity)
        {
            Check(entity);
            subCategoryDAL.Update(entity);
            return new SuccessResult(ResultMessage<SubCategory>.Update(entity));
        }

        public IResult Delete(SubCategory entity)
        {
            entity.IsActive = false;
            subCategoryDAL.Update(entity);
            return new SuccessResult(ResultMessage<SubCategory>.Delete(entity));
        }

        public IResult Delete(int id)
        {
            SubCategory subCategory = Get(id).Data;
            subCategory.IsActive = false;
            subCategoryDAL.Update(subCategory);
            return new SuccessResult(ResultMessage<SubCategory>.Delete(subCategory));
        }

        public IDataResult<SubCategory> Get(int id)
        {
            return new SuccessDataResult<SubCategory>(subCategoryDAL.Get(a => a.ID == id));
        }

        public IDataResult<ICollection<SubCategory>> GetAll()
        {
            return new SuccessDataResult<ICollection<SubCategory>>(subCategoryDAL.GetAll(a => a.IsActive == true));
        }
        #endregion

        public IDataResult<ICollection<SubCategory>> GetSubCategoriesByCatID(int id)
        {
            return new SuccessDataResult<ICollection<SubCategory>>(subCategoryDAL.GetAll(a => a.CategoryID == id, a => a.Category));
        }

        public IDataResult<ICollection<SubCategory>> GetAllWithCats()
        {
            return new SuccessDataResult<ICollection<SubCategory>>(subCategoryDAL.GetAll(a => a.IsActive == true, x => x.Category));
        }

    }
}
