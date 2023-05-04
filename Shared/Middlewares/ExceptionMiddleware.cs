using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shared.Abstraction.Exceptions.Base;
using Shared.Abstraction.Responses;

namespace Shared.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ExceptionBase e)
            {
                var result = new ErrorResult(e);

                // Serialize the response object into JSON
                var responseJson = JsonConvert.SerializeObject(result.Value, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                // Set the response content type and status code
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = e.StatusCode;

                await context.Response.WriteAsync(responseJson);
            }
        }
    }
}


