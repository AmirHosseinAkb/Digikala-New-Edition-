using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application.ZarinPal
{
    public class ZarinpalFactory:IZarinpalFactory
    {
        public PaymentResponse CreatePaymentRequest(long transactionId, int amount, string description)
        {
            var payment = new ZarinpalSandbox.Payment(amount);
            var response = payment.PaymentRequest(description,
                "https://localhost:7169/UserPanel/Wallet/OnlinePayment/" + transactionId);
            return new PaymentResponse()
            {
                Authority = response.Result.Authority,
                Status = response.Result.Status
            };
        }
    }
}
