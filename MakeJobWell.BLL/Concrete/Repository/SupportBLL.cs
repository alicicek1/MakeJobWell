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
    class SupportBLL : ISupportBLL
    {
        ISupportDAL supportDAL;
        public SupportBLL(ISupportDAL support)
        {
            supportDAL = support;
        }

        #region BaseCRUD
        public IResult Add(Support entity)
        {
            supportDAL.Add(entity);
            return new SuccessResult(ResultMessage<Support>.Add(entity));
        }
        public IResult Update(Support entity)
        {
            supportDAL.Update(entity);
            return new SuccessResult(ResultMessage<Support>.Update(entity));
        }

        public IResult Delete(Support entity)
        {
            entity.IsActive = false;
            supportDAL.Update(entity);
            return new SuccessResult(ResultMessage<Support>.Delete(entity));
        }

        public IResult Delete(int id)
        {
            Support support = Get(id).Data;
            support.IsActive = false;
            supportDAL.Update(support);
            return new SuccessResult(ResultMessage<Support>.Delete(support));
        }

        public IDataResult<Support> Get(int id)
        {
            return new SuccessDataResult<Support>(supportDAL.Get(a => a.ID == id));
        }

        public IDataResult<ICollection<Support>> GetAll()
        {
            return new SuccessDataResult<ICollection<Support>>(supportDAL.GetAll());
        }
        #endregion

    }
}
