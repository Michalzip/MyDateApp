
using PayPal.Api;
using Api.Extensions;
using DateApp.Repositories.Interfaces;

namespace DateApp.Repositories
{


    public class PayPalRepository : IPaymentRepository
    {

        private readonly ContextAccessorExtension _contextAccessor;

        public PayPalRepository(ContextAccessorExtension contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }


        public Dictionary<string, string> GetConfig()
        {
            return ConfigManager.Instance.GetProperties();
        }

        private string GetAccessToken()
        {

            string accessToken = new OAuthTokenCredential(GetConfig()).GetAccessToken();

            return accessToken;
        }

        public APIContext GetAPIContext()
        {
            APIContext apiContext = new APIContext(GetAccessToken());

            apiContext.Config = GetConfig();

            return apiContext;
        }

        private Payment CreateVipPayment(APIContext apiContext, string redirectUrl)
        {


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

            return payment.Create(apiContext);
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };

            var payment = new Payment() { id = paymentId };

            return payment.Execute(apiContext, paymentExecution);


        }



        public String BuyVip()
        {

            APIContext apiContext = GetAPIContext();

            string? paymentLink = null;

            var guidStringNumber = Convert.ToString((new Random()).Next(100000));

            string paypalUri = "https://localhost:7189/ConfirmPayment?";

            var createdPayment = this.CreateVipPayment(apiContext, paypalUri + "guid=" + guidStringNumber);

            var links = createdPayment.links.GetEnumerator();



            while (links.MoveNext())
            {
                if (links.Current.rel.ToLower().Trim().Equals("approval_url")) paymentLink = links.Current.href;

            }


            _contextAccessor.SetSession(guidStringNumber, createdPayment.id);

            return paymentLink;



        }


        public bool ConfirmPayment(string? PayerID, string? guid)
        {

            APIContext apiContext = GetAPIContext();

            if (!string.IsNullOrEmpty(PayerID))
            {

                string paymentId = _contextAccessor.GetSession(guid);

                var executedPayment = ExecutePayment(apiContext, PayerID, paymentId);

                if (executedPayment.state.Equals("approved")) return true;

            }

            return false;
        }

    }
}