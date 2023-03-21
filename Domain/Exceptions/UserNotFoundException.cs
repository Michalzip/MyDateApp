using Shared.Abstraction.Exceptions;
using Domain;

namespace Domain.Exceptions
{
    public class UserNotFoundException : ExceptionBase
    {
        public UserNotFoundException(string id) : base($"User with ID {id} not found")
        {
            ExtraData = new
            {
                id
            };
        }
        public override string Code => Constants.ErrorCodes.UserNotFound;
        public override int StatusCode => StatusCodes.Status404NotFound;
    }
}