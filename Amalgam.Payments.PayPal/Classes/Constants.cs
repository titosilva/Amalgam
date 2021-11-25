using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Payments.Classes
{
    public static class Constants
    {
        public static class CurrencyCodes
        {
            public const string UnitedStatesDollar = "USD";
            public const string BrazilReal = "BRL";
        }

        public static class PayPal
        {
            public static class PaymentMethods
            {
                public const string PayPal = "paypal";
            }

            public static class Intents
            {
                public const string Sale = "sale";
            }
        }
    }
}
