using FluentValidation;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Concrete.EntityValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().MaximumLength(2).WithMessage("First name cannot be null and at least 2 character.");
            RuleFor(a => a.LastName).NotEmpty().MaximumLength(2).WithMessage("Last name cannot be null and at least 2 character.");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Password cannot be null.");
            RuleFor(a => a.UserName).NotEmpty().WithMessage("Username cannot be null.");
            RuleFor(a => a.Email).EmailAddress().NotEmpty();
        }
    }
}
