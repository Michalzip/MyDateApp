
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstraction.Exceptions.Base;
namespace Shared.Abstraction.Responses
{
    public class ErrorResult : JsonResult
    {
        public ErrorResult(ExceptionBase exception) : base(new
        { code = exception.Code, statusCode = exception.StatusCode, message = exception.Message })
        {
            StatusCode = exception.StatusCode;
            Code = exception.Code;
            Message = exception.Message;
        }

        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}


