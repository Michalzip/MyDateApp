using Shared.Abstraction.Exceptions;
using Domain;


namespace Domain.Exceptions
{
    public class UserAlreadyExistsException : ExceptionBase
    {
        public UserAlreadyExistsException(string email) : base($"User with email {email} already exists")
        {
        }

        public override string Code => Constants.ErrorCodes.UserAlreadyExists;
        public override int StatusCode => StatusCodes.Status409Conflict;

    }
}