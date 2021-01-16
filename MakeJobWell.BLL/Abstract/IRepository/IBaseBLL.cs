using MakeJobWell.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface IBaseBLL<TEntity>
        where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        TEntity Get(int id);
        ICollection<TEntity> GetAll();
    }
}
