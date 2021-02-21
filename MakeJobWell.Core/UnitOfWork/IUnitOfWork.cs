using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MakeJobWell.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        public int Commit();
        Task<int> CommitAsync();
    }
}
