using Shared.Abstraction.Exceptions;
using Domain;


namespace Domain.Exceptions
{
    public class UserAlreadyExistsVipException : ExceptionBase
    {
        public UserAlreadyExistsVipException(string email) : base($"User with email {email} already vip exists")
        {
        }
        public override string Code => Constants.ErrorCodes.UserVipExists;
        public override int StatusCode => StatusCodes.Status409Conflict;
    }
}  