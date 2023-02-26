using PayPal.Api;

namespace Infrastructure.Services.Interfaces
{
    public interface IPaypalService
    {

        public String GetPaymentLink(Payment payment);
        public Payment ConfirmPayment(string? PayerID, string? guid);
        public Payment CreateVipPayment();
    }
}