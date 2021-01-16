using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.BLL.Concrete.Repositories;
using MakeJobWell.BLL.Concrete.Repository;
using MakeJobWell.DAL.Concrete.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Concrete.DependencyInjection
{
    public static class EFContextBLL
    {
        public static void AddScopedBLL(this IServiceCollection services)
        {
            services.AddScopedDAL();
            services.AddScoped<ICategoryBLL, CategoryBLL>();
            services.AddScoped<ICommentBLL, CommentBLL>();
            services.AddScoped<ICompanyBLL, CompanyBLL>();
            services.AddScoped<IComplaintBLL, ComplaintBLL>();
            services.AddScoped<ISubCategoryBLL, SubCategoryBLL>();
            services.AddScoped<ISupportBLL, SupportBLL>();
            services.AddScoped<IUserBLL, UserBLL>();
        }
    }
}
