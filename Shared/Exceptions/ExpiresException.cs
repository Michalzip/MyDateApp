
using Shared.Abstraction.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace Shared.Abstraction.Exceptions
{
    public class ExpiresException : ExceptionBase
    {
        public ExpiresException(string message) : base(message)
        {
        }
        public override string Code => Constants.ErrorCodes.DataExpires;
        public override int StatusCode => StatusCodes.Status410Gone;
    }
}

