using PayPal.Api;

namespace Domain.Interfaces.ExternalServices
{
    public interface IPaypalService
    {
        public String GetPaymentLink(Payment payment);
        public Payment ConfirmPayment(string? PayerID, string? guid);
        public Payment CreatePayment();
    }
}


