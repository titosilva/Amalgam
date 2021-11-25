using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Payments.Configuration
{
    public class PayPalConfiguration
    {
        public string CancelUrlEndpoint { get; set; }
        public string RedirectUrlEndpoint { get; set; }

        public Dictionary<string, string> GetAPIContextConfig()
            => new Dictionary<string, string>()
            {
                ["mode"] = "sandbox",
            };
    }
}
