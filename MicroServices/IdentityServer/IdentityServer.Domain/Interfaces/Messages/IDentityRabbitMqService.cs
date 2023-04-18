
using Microsoft.AspNetCore.Identity;


namespace IdentityServer.Domain.Interfaces.Messages
{
    public interface IDentityRabbitMqService
    {

        void PublishIdentityUserMessage<T>(T message);
        void ConsumeUserNameMessage();

    }
}