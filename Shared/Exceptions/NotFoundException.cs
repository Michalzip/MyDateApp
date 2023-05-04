using Shared.Abstraction.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace Shared.Abstraction.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public NotFoundException(string message) : base(message)
        {
        }
        public override string Code => Constants.ErrorCodes.NotFound;
        public override int StatusCode => StatusCodes.Status404NotFound;
    }
}

