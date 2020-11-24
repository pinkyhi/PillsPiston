using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using PillsPiston.API.Responses;
using PillsPiston.Core.Enums;
using PillsPiston.Core.Exceptions;
using System;

namespace PillsPiston.Filters
{
    public class ExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private readonly ILogger<ExceptionFilterAttribute> logger;

        public ExceptionFilterAttribute(ILogger<ExceptionFilterAttribute> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType().IsSubclassOf(typeof(PillsPistonException)))
            {
                var exception = context.Exception;
                ObjectResult result = new ObjectResult(new ErrorResponse
                {
                    Message = exception.Message,
                    SubCode = (exception as PillsPistonException).Code
                })
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };

                context.Result = result;
            }
            else
            {
                this.logger.LogError(context.Exception.Message, context.Exception.StackTrace);

                context.Result = new ObjectResult(new ErrorResponse
                {
                    Message = context.Exception.Message,
                    SubCode = (int)ErrorCodesEnums.Global.Unknown
                })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            context.ExceptionHandled = true;
        }
    }
}
