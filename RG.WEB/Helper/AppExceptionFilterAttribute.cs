
using RG.Application.Common.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using RG.Application.Constants;

namespace RG.WEB.Helper
{
    //http://www.binaryintellect.net/articles/5df6e275-1148-45a1-a8b3-0ba2c7c9cea1.aspx
    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
    {

        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        private readonly IWebHostEnvironment _env;
        public AppExceptionFilterAttribute(IWebHostEnvironment env)
        {
            _env = env;
            IsDevelopment = _env.IsDevelopment();
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
                { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
                { typeof(ForbiddenAccessException), HandleForbiddenAccessException },
            };
        }
        private bool IsDevelopment { get; }
        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            var details = new ValidationProblemDetails(exception.Errors)
            {
                Type = "Validation Error.",
                Status = 460
            };

 
            context.Result = new BadRequestObjectResult(details);
            context.HttpContext.Response.StatusCode = 460;
            context.ExceptionHandled = true;
            
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {


            var details = new ValidationProblemDetails(context.ModelState)
            {
                Type = "Validation Problem Details",
                Status = 461
            };
            
            context.Result = new BadRequestObjectResult(details);
            context.HttpContext.Response.StatusCode = 461;
            context.ExceptionHandled = true;
            
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            var details = new ProblemDetails();
            if (IsDevelopment)
            {
                string functionInfo = $"Method Type : {context.HttpContext.Request.Method}, Function: {context.HttpContext.Request.Path}:";
                details.Instance = functionInfo;
                details.Status = StatusCodes.Status401Unauthorized;
                details.Title = $"The specified resource was not found : {exception.Message}";
                details.Detail = context.Exception.StackTrace.ToString();
                
            }
            else
            {
                details.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4";
                details.Title = "The specified resource was not found.";
                details.Detail = exception.Message;
            }
            
            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleUnauthorizedAccessException(ExceptionContext context)
        {
            var details = new ProblemDetails();
            if (IsDevelopment)
            {
                string functionInfo = $"Method Type : {context.HttpContext.Request.Method}, Function: {context.HttpContext.Request.Path}";
                details.Instance = functionInfo;
                details.Status = StatusCodes.Status401Unauthorized;
                details.Title = $"Unauthorized : {context.Exception.Message}";
                details.Detail = context.Exception.StackTrace.ToString();


            }
            else
            {
                details.Status = StatusCodes.Status401Unauthorized;
                details.Title = "Unauthorized";
                details.Type = "https://tools.ietf.org/html/rfc7235#section-3.1";
            }
            var cookieEmp = context.HttpContext.Request.Cookies[SessionKey.User_EMPLOYEE_Code];
            if (cookieEmp == null)
            {
                context.HttpContext.Request.Path = "/Identity/Account/Login";
            }
            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };

            context.ExceptionHandled = true;
        }

        private void HandleForbiddenAccessException(ExceptionContext context)
        {
            var details = new ProblemDetails();
            if (IsDevelopment)
            {
                string functionInfo = $"Method Type : {context.HttpContext.Request.Method}, Function: {context.HttpContext.Request.Path}";
                details.Instance = functionInfo;
                details.Status = StatusCodes.Status403Forbidden;
                details.Title = $"Forbidden : {context.Exception.Message}";
                details.Detail = context.Exception.StackTrace.ToString(); 
            }
            else
            {
                details.Status = StatusCodes.Status403Forbidden;
                details.Title = "Forbidden";
                details.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3";
            }

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status403Forbidden
            };

            context.ExceptionHandled = true;
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails();
            if (IsDevelopment)
            {
                string functionInfo = $"Method Type : {context.HttpContext.Request.Method}, Function: {context.HttpContext.Request.Path}";
                details.Instance = functionInfo;
                details.Status = StatusCodes.Status500InternalServerError;
                details.Title = context.Exception.Message;
                details.Detail = context.Exception.StackTrace.ToString(); 
            }
            else
            {
                details.Status = StatusCodes.Status500InternalServerError;
                details.Title = "An error occurred while processing your request.";
                details.Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1";

            }
            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
