

namespace MakeJobWell.BLL.Constant
{
    public static class ResultMessage<TEntity>
        where TEntity : class
    {
        public static string Add(TEntity entity) { return $"{entity} added."; }
        public static string Delete(TEntity entity) { return $"{entity} deleted."; }
        public static string Update(TEntity entity) { return $"{entity} updated."; }

    }
}
