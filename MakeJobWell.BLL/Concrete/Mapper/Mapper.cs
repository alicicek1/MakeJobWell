using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MakeJobWell.BLL.Concrete.Mapper
{
    public static class Mapper
    {
        public static TResult Map<T, TResult>(T model) where TResult : class, new()
        {
            TResult result = new TResult();
            typeof(T).GetProperties().ToList().ForEach(p =>
            {
                PropertyInfo property= typeof(TResult).GetProperty(p.Name);
                property.SetValue(result,p.GetValue(model));
            });
            return result;
        }
    }
}
