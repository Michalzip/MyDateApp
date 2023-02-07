using DateApp.Entities;
using PayPal.Api;

namespace DateApp.Repositories.Interfaces
{
    public interface IPaypalRepository
    {


        public String GetPaymentLink(Payment payment);
        public Payment ConfirmPayment(string? PayerID, string? guid);
        public Payment CreateVipPayment();
      

    }
}