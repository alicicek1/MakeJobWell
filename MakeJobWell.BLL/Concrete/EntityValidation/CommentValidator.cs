using FluentValidation;
using MakeJobWell.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.BLL.Concrete.EntityValidation
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(a => a.CommentText).Length(2, 200).WithMessage("Comment needs to be between 2 and 200 character.");
        }
    }
}
