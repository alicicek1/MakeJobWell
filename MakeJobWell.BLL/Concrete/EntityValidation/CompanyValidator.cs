using FluentValidation;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Concrete.EntityValidation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(a => a.CompanyName).NotEmpty().Length(3, 50).WithMessage("Company name cannot be null and needs to be between 3 and 50 character.");
            RuleFor(a => a.Overview).NotEmpty().Length(5, 200).WithMessage("Company overview cannot be null and needs to be between 5 and 200 character.");
            RuleFor(a => a.Adress).NotEmpty().Length(5, 100).WithMessage("Company address cannot be null and needs to be between 5 and 100 character.");
            RuleFor(a => a.WebSite).Custom((webbSite, context) =>
            {
                if (!webbSite.EndsWith(".com"))
                {
                    context.AddFailure("Companies's websites has to end with '.com'.");
                }
            });
        }
    }
}
