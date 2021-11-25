using Amalgam.Core.Contracts.Services;
using Amalgam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPal.Api;
using Amalgam.Payments.Classes;

namespace Amalgam.Payments.Services
{
    using Payment = Core.Entities.Payment;
    using PayPalPayment = PayPal.Api.Payment;
    using PayPalItem = PayPal.Api.Item;
    using PayPalItemList = PayPal.Api.ItemList;
    using PayPalAmount = PayPal.Api.Amount;
    using PayPalDetails = PayPal.Api.Details;
    using PayPalTransaction = PayPal.Api.Transaction;
    using PayPalRedirectUrls = PayPal.Api.RedirectUrls;
    using PayPalPayer = PayPal.Api.Payer;
    using PayPalAPIContext = PayPal.Api.APIContext;

    public class PayPalPaymentService : IPaymentService
    {
        public void Pay(Payment payment)
        {
            var itemList = generateItemList(payment, out var totalValue);
            var payer = new PayPalPayer() { payment_method = Constants.PayPal.PaymentMethods.PayPal };
            var details = new PayPalDetails()
            {
                tax = "0",
                shipping = "0",
                subtotal = totalValue,
            };

            var amount = new PayPalAmount()
            {
                total = totalValue,
                details = details,
                currency = Constants.CurrencyCodes.BrazilReal,
            };

            var transactions = new List<PayPalTransaction>();

            transactions.Add(new PayPalTransaction()
            {
                description = payment.TargetName,
                invoice_number = payment.Id.ToString(),
                amount = amount,
                item_list = itemList,
            });

            var payPalPayment = new PayPalPayment()
            {
                intent = Constants.PayPal.Intents.Sale,
                payer = payer,
                transactions = transactions,
            };

            var apiContext = new PayPalAPIContext()
            {

            };
            
        }

        #region Utils
        private PayPalItemList generateItemList(Payment payment, out string totalValue)
            => new PayPalItemList()
            {
                items = new List<PayPalItem>()
                {
                    new PayPalItem()
                    {
                        name = payment.TargetName,
                        currency = Constants.CurrencyCodes.BrazilReal,
                        price = totalValue = ((double)payment.Amount / 100).ToString("0.##"),
                        quantity = "1",
                    }
                },
            };
        #endregion
    }
}
