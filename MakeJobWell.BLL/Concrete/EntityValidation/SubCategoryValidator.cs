using FluentValidation;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Concrete.EntityValidation
{
    public class SubCategoryValidator : AbstractValidator<SubCategory>
    {
        public SubCategoryValidator()
        {
            RuleFor(a => a.CategoryName).NotEmpty().Length(2, 50).WithMessage("SubCategory name needs to be between 2 and 50 character.");
            RuleFor(a => a.Description).NotEmpty().Length(10, 250).WithMessage("SubCategory description needs to be between 10 and 250 character.");
        }
    }
}
