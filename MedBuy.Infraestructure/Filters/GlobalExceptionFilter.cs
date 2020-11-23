using MedBuy.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MedBuy.Infraestructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext excontext)
        {
            var eType = excontext.Exception.GetType();
            if (eType == typeof(BusinessException))
            {
                var exception = (BusinessException)excontext.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = exception.Message
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                excontext.Result = new BadRequestObjectResult(json);
                excontext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                excontext.ExceptionHandled = true;
            }
        }
    }
}
