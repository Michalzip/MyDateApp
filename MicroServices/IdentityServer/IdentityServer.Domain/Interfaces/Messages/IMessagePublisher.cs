

namespace IdentityServer.Domain.Interfaces.Messages
{
    public interface IMessagePublisher
    {
        public void LoggedInUserPublisher(string id, string userName);

        public void LogoutUserPublisher();
    }
}