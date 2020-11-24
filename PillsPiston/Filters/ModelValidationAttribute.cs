using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PillsPiston.API.Responses;
using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;
using System;
using System.Linq;

namespace PillsPiston.Filters
{
    public class ModelValidationAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new ErrorResponse
                {
                    Message = ErrorMessages.BadModelData,
                    Errors = context.ModelState.Values.SelectMany(e => e.Errors),
                    SubCode = (int)ErrorCodesEnums.Global.ModelError
                });
            }
        }
    }
}
