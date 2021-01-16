using FluentValidation;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Concrete.EntityValidation
{
    public class ComplaintValidator : AbstractValidator<Complaint>
    {
        public ComplaintValidator()
        {
            RuleFor(a => a.ComplaintTitle).NotEmpty().MinimumLength(10).WithMessage("Complaints titles cannot be null and shorter than 10 characters.");
            RuleFor(a => a.ComplaintDetail).NotEmpty().WithMessage("Complaints details cannt be null.");
        }
    }
}
