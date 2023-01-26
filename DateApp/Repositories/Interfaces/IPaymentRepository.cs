using PayPal.Api;

namespace DateApp.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Dictionary<string, string> GetConfig();
        APIContext GetAPIContext();
        String BuyVip();
        bool ConfirmPayment(string? PayerID, string? guid);
    }
}