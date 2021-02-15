using Castle.DynamicProxy;
using FluentValidation;
using MakeJobWell.Core.CrossCuttingConcerns.Validation.FluentVal;
using MakeJobWell.Core.Utilities.Intercepters;
using MakeJobWell.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakeJobWell.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(a => a.GetType() == entityType);
            foreach (var entity in entities)
            {
                FluentValidationTool.Validate(validator, entity);
            }
        }
    }
}
