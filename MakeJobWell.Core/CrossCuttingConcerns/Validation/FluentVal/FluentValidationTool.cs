using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Core.CrossCuttingConcerns.Validation.FluentVal
{
    public static class FluentValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                string error = "";
                foreach (var item in result.Errors)
                {
                    error += item;
                    error += "/";
                }
                throw new Exception(error);
            }
        }
    }
}
