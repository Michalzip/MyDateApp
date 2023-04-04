
using Shared.Abstraction.Extensions;
using PayPal.Api;
using Domain.Entities;
using Domain.Interfaces.ExternalApiServices;

namespace Infrastructure.Services
{
    public class PayPalService : IPaypalService
    {
        private readonly ContextAccessorExtension _contextAccessor;

        public PayPalService(ContextAccessorExtension contextAccessor)
        {

            _contextAccessor = contextAccessor;

        }

        private Dictionary<string, string> GetConfig()
        {
            return ConfigManager.Instance.GetProperties();
        }

        private string GetAccessToken()
        {

            string accessToken = new OAuthTokenCredential(GetConfig()).GetAccessToken();

            return accessToken;
        }

        private APIContext GetAPIContext()
        {
            APIContext apiContext = new APIContext(GetAccessToken());

            apiContext.Config = GetConfig();

            return apiContext;
        }


        public Payment CreatePayment()
        {


            APIContext apiContext = GetAPIContext();

            var guidStringNumber = Convert.ToString((new Random()).Next(100000));

            string? paypalUri = "https://localhost:7189/ConfirmPayment?";

            string redirectUrl = paypalUri + "guid=" + guidStringNumber;

            var itemList = new ItemList() { items = new List<Item>() };

            itemList.items.Add(new Item()
            {
                name = "Vip",
                currency = "USD",
                price = "50",
                quantity = "1",
                sku = "sku"
            });

            var payer = new Payer() { payment_method = "paypal" };

            var details = new Details()
            {
                tax = "10",
                shipping = "0",
                subtotal = "50"
            };


            var amount = new Amount()
            {
                currency = "USD",
                total = "60.00",
                details = details
            };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };


            var transactionList = new List<Transaction>();

            transactionList.Add(new Transaction()
            {
                description = "Vip Transaction.",
                invoice_number = new Random().Next(999999).ToString(),
                amount = amount,
                item_list = itemList
            });

            var payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };




            var paymentData = payment.Create(apiContext);

            _contextAccessor.SetSession(guidStringNumber, paymentData.id);

            var transactionStatus = new UserTransaction { TransactionId = paymentData.id, Currency = amount.currency, Amount = transactionList[0].item_list.items[0].quantity, PendingConfirm = true };

            return paymentData;
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };

            var payment = new Payment() { id = paymentId };

            return payment.Execute(apiContext, paymentExecution);
        }



        public String GetPaymentLink(Payment payment)
        {

            APIContext apiContext = GetAPIContext();

            string? paymentLink = null;


            var links = payment.links.GetEnumerator();


            while (links.MoveNext())
            {
                if (links.Current.rel.ToLower().Trim().Equals("approval_url")) paymentLink = links.Current.href;

            }

            return paymentLink;

        }


        public Payment ConfirmPayment(string? PayerID, string? guid)
        {

            APIContext apiContext = GetAPIContext();

            string paymentId = _contextAccessor.GetSession(guid);

            if (paymentId == null) return null;

            return ExecutePayment(apiContext, PayerID, paymentId);

        }


    }
}