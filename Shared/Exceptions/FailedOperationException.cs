
using Shared.Abstraction.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace Shared.Abstraction.Exceptions
{
    public class FailedOperationException : ExceptionBase
    {
        public FailedOperationException(string message) : base(message)
        {
        }

        public override string Code => Constants.ErrorCodes.OperationFailed;
        public override int StatusCode => StatusCodes.Status500InternalServerError;
    }
}

