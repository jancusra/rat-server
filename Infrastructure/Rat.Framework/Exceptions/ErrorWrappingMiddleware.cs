using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Rat.Domain.Exceptions;
using Rat.Domain.Responses;
using Rat.Services;

namespace Rat.Framework.Exceptions
{
    public partial class ErrorWrappingMiddleware : BaseErrorMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorWrappingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILogService logger)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BaseResponseException baseResponseException)
            {
                await logger.WarningAsync(baseResponseException.Message, baseResponseException);
                await SendResponseIfNotStarted(context, baseResponseException.ResponseState);
            }
            catch (Exception ex)
            {
                await logger.ErrorAsync(ex.Message, ex);
                await SendResponseIfNotStarted(context, new ResponseState { Code = 10000, HttpStatusCode = 500, Message = "Non expected error" });
            }
        }
    }
}
