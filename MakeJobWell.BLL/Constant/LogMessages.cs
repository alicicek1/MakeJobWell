using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Constant
{
    public static class LogMessages<TEntity>
    {
        public static string AdminInsert(int adminId, TEntity entity, int id) { return $"AdminID : {adminId} is created {entity}ID : {id}"; }
        public static string AdminUpdate(int adminId, TEntity entity, int id) { return $"AdminID : {adminId} is updated {entity}ID : {id}"; }
        public static string AdminDelete(int adminId, TEntity entity, int id) { return $"AdminID : {adminId} is deleted {entity}ID : {id}"; }

        public static string UserInsert(int userId, TEntity entity, int id) { return $"UserID : {userId} is created {entity}ID : {id}"; }
        public static string UserDelete(int userId, TEntity entity, int id) { return $"UserID : {userId} is deleted {entity}ID : {id}"; }
    }
}
