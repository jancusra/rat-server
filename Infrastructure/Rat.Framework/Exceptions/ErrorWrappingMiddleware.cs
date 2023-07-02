using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Rat.Domain.Exceptions;
using Rat.Domain.Responses;

namespace Rat.Framework.Exceptions
{
    public partial class ErrorWrappingMiddleware : BaseErrorMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorWrappingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context/*, ILogger<ErrorWrappingMiddleware> logger*/)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BaseResponseException baseResponseException)
            {
                //logger.LogWarning(baseResponseException.ResponseState.Code, baseResponseException.Message);
                await SendResponseIfNotStarted(context, baseResponseException.ResponseState);
            }
            catch /*(Exception ex)*/
            {
                //logger.LogError(ResponseCodes.GlobalException.Code, ex, ex.ToString());
                await SendResponseIfNotStarted(context, new ResponseState { Code = 10000, HttpStatusCode = 500, Message = "Non expected error" });
            }
        }
    }
}
