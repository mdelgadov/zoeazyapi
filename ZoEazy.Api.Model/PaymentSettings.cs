using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ZoEazy.Api.Model
{
    public class PaymentSettings
    {
        public string StripePublicKey { get; set; }
        public string StripePrivateKey { get; set; }
    }
}