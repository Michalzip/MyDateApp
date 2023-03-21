using System;
using Microsoft.AspNetCore.Http;

namespace Shared.Abstraction.Exceptions
{
    public class UnhandledException : ExceptionBase
    {
        public UnhandledException(string message) : base(message)
        {
        }
        public override string Code => "UNHANDLED_EXCEPTION";
        public override int StatusCode => StatusCodes.Status500InternalServerError;
    }
}

