using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.BLL.Concrete.EntityValidation;
using MakeJobWell.BLL.Constant;
using MakeJobWell.Core.Aspects.Autofac.Validation;
using MakeJobWell.Core.CrossCuttingConcerns.Validation.FluentVal;
using MakeJobWell.Core.Utilities.Result;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category entity)
        {
            //Check(entity);
            FluentValidationTool.Validate(new CategoryValidator(), entity);

            categoryDAL.Add(entity);
            return new SuccessResult(ResultMessage<Category>.Add(entity.CategoryName));
        }
        public IResult Update(Category entity)
        {
            //Check(entity);
            FluentValidationTool.Validate(new CategoryValidator(), entity);

            categoryDAL.Update(entity);
            return new SuccessResult(ResultMessage<Category>.Update(entity.CategoryName));
        }

        public IResult Delete(Category entity)
        {
            entity.IsActive = false;
            categoryDAL.Update(entity);
            return new SuccessResult(ResultMessage<Category>.Delete(entity.CategoryName));
        }

        public IResult Delete(int id)
        {
            Category category = Get(id).Data;
            category.IsActive = false;
            categoryDAL.Update(category);
            return new SuccessResult(ResultMessage<Category>.Delete(category.CategoryName));
        }

        public IDataResult<Category> Get(int id)
        {
            return new SuccessDataResult<Category>(categoryDAL.Get(a => a.ID == id));
        }

        public IDataResult<ICollection<Category>> GetAll()
        {
            return new SuccessDataResult<ICollection<Category>>(categoryDAL.GetAll(a => a.IsActive == true).ToList());
        }
        #endregion

        public IDataResult<ICollection<Category>> GetLatestSix()
        {
            return new SuccessDataResult<ICollection<Category>>(categoryDAL.GetAll().OrderByDescending(a => a.CreatedDate).Take(6).ToList());
        }

        public IDataResult<ICollection<Category>> GetCatWSubCats()
        {
            return new SuccessDataResult<ICollection<Category>>(categoryDAL.GetAll(a => a.IsActive, a => a.SubCategories).ToList());
        }



    }
}
