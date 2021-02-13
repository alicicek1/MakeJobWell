using MakeJobWell.Core.DataAccess.Concrete.EntityFramework;
using MakeJobWell.DAL.Abstract;
using MakeJobWell.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MakeJobWell.DAL.Concrete.Repository
{
    class UserDAL : EFRepositoryBase<User, MakeJobWellDbContext>, IUserDAL
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new MakeJobWellDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserID == user.ID
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();

            }
        }
    }
}
