using FluentValidation;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Concrete.EntityValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(a => a.CategoryName).NotEmpty().Length(2, 50).WithMessage("{PropertyName} needs to be between {MinLenght} and {MaxLenght} character.");
            RuleFor(a => a.Description).NotEmpty().Length(10, 250).WithMessage("Category description needs to be between 10 and 250 character.");
        }
    }
}
