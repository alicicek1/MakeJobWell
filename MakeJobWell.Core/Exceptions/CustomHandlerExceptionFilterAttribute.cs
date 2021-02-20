using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Core.Exceptions
{
    public class CustomHandlerExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public string ErrorPage { get; set; }
        public override void OnException(ExceptionContext context)
        {
            Exception exception = context.Exception;
            context.ExceptionHandled = true;


            var result = new ViewResult() { ViewName = ErrorPage };

            result.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState);

            result.ViewData.Add("Exception", context.Exception);

            result.ViewData.Add("Url", context.HttpContext.Request.Path.Value);

            context.Result = result;
        }
    }
}
