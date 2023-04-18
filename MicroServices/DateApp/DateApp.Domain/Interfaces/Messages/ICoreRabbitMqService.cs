using Shared.Models;

namespace DateApp.Domain.Interfaces.Messages
{
    public interface ICoreRabbitMqService
    {
        void PublishUserNameMessage<T>(T message);
        void ConsumeIdentityUserMessage(string firstName, string lastName, string photoUrl);
        void ConsumeSignInUserNameMessage();
    }
}