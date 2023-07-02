using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Rat.Domain.Responses;

namespace Rat.Framework.Exceptions
{
    public abstract class BaseErrorMiddleware
    {
        protected virtual async Task SendResponseIfNotStarted(HttpContext context, ResponseState responseState)
        {
            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = responseState.HttpStatusCode;
                var response = new BaseResponse(responseState.Code, responseState.Message);
                var json = JsonConvert.SerializeObject(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
