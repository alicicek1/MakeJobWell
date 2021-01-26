using FluentValidation;
using MakeJobWell.BLL.Concrete.EntityValidation;
using MakeJobWell.Models.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Concrete.DependencyInjection
{
    public static class FVContextBLL
    {
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Category>, CategoryValidator>();
            services.AddScoped<IValidator<Comment>, CommentValidator>();
            services.AddScoped<IValidator<Company>, CompanyValidator>();
            services.AddScoped<IValidator<Complaint>, ComplaintValidator>();
            services.AddScoped<IValidator<SubCategory>, SubCategoryValidator>();
            services.AddScoped<IValidator<User>, UserValidator>();
        }
    }
}
