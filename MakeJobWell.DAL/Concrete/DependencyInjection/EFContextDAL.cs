using MakeJobWell.DAL.Abstract;
using MakeJobWell.DAL.Concrete.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.DAL.Concrete.DependencyInjection
{
    public static class EFContextDAL
    {
        public static void AddScopedDAL(this IServiceCollection services)
        {
            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<ICommentDAL, CommentDAL>();
            services.AddScoped<ICompanyDAL, CompanyDAL>();
            services.AddScoped<IComplaintDAL, ComplaintDAL>();
            services.AddScoped<ISubCategoryDAL, SubCategoryDAL>();
            services.AddScoped<ISupportDAL, SupportDAL>();
            services.AddScoped<IUserDAL, UserDAL>();
        }
    }
}
