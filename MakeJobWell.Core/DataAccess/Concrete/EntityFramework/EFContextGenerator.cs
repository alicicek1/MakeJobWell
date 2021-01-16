using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Core.DataAccess.Concrete.EntityFramework
{
    public class EFContextGenerator<TContext>
        where TContext : DbContext
    {
        static IServiceCollection services;
        static EFContextGenerator()
        {
            services = new ServiceCollection();
            services.AddDbContext<TContext>();
        }
        public static TContext GetContextInstance()
        {
            ServiceProvider provider = services.BuildServiceProvider();
            return provider.GetService<TContext>();
        }
    }
}
