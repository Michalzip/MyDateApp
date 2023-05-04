
using Shared.Abstraction.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace Shared.Abstraction.Exceptions
{
    public class AlreadyExistsException : ExceptionBase
    {
        public AlreadyExistsException(string message) : base(message)
        {
        }

        public override string Code => Constants.ErrorCodes.AlreadyExists;
        public override int StatusCode => StatusCodes.Status409Conflict;
    }
}

