using MakeJobWell.BLL.Abstract.IRepositorories;
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
        public void Add(Support entity)
        {
            supportDAL.Add(entity);
        }
        public void Update(Support entity)
        {
            supportDAL.Update(entity);
        }

        public void Delete(Support entity)
        {
            entity.IsActive = false;
            supportDAL.Update(entity);
        }

        public void Delete(int id)
        {
            Support support = Get(id);
            support.IsActive = false;
            supportDAL.Update(support);
        }

        public Support Get(int id)
        {
            return supportDAL.Get(a => a.ID == id);
        }

        public ICollection<Support> GetAll()
        {
            return supportDAL.GetAll();
        }
        #endregion

    }
}
