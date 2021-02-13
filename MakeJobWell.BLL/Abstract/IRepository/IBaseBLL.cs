using MakeJobWell.Core.Entity;
using MakeJobWell.Core.Utilities.Result;
using System.Collections.Generic;

namespace MakeJobWell.BLL.Abstract.IRepositorories
{
    public interface IBaseBLL<TEntity>
        where TEntity : BaseEntity
    {
        IResult Add(TEntity entity);
        IResult Update(TEntity entity);
        IResult Delete(TEntity entity);
        IResult Delete(int id);
        IDataResult<TEntity> Get(int id);
        IDataResult<ICollection<TEntity>> GetAll();
    }
}
