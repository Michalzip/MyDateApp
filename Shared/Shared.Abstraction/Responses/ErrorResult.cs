
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstraction.Exceptions;

namespace Shared.Abstraction.Responses
{
    public class ErrorResult : JsonResult
    {

        public ErrorResult(ExceptionBase exception) : base(new
        { code = exception.Code, message = exception.Message, extraData = exception.ExtraData, ok = false })
        {
            Ok = false;
            Code = exception.Code;
            Message = exception.Message;
            ExtraData = exception.ExtraData;
        }


        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("extraData")]
        public object ExtraData { get; set; }
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public new int? StatusCode { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public new string ContentType { get; set; }
    }
}


