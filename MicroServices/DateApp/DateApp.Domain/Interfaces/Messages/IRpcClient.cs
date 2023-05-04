
namespace DateApp.Domain.Interfaces.Messages
{
    public interface IRpcClient
    {
        public Task<bool> CreateVipPublisher(string userName, CancellationToken cancellationToken = default);

        public Task<bool> VipStatusPublisher(string userName, CancellationToken cancellationToken = default);
    }
}