

namespace MakeJobWell.BLL.Constant
{
    public static class ResultMessage<TEntity>
        where TEntity : class
    {
        public static string Add(string msg) { return $"{msg} added."; }
        public static string Delete(string msg) { return $"{msg} deleted."; }
        public static string Update(string msg) { return $"{msg} updated."; }

    }
}
