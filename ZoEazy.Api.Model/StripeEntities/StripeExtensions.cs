using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stripe.Checkout;

namespace ZoEazy.Api.Model.StripeEntities
{
    /// <summary>
    /// Helpful extension methods for classes in Stripe.Net
    /// </summary>
    public static class StripeExtensions
    {
        /// <summary>
        /// Gets the default card associated with this customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Stripe.Card GetDefaultSource(this Stripe.Customer customer)
        {
            if (customer.DefaultSource != null)
                return customer.GetDefaultSource();

            if (string.IsNullOrEmpty(customer.DefaultSourceId))
                return null;

            if (customer.Sources == null || customer.Sources.Data == null)
                return null;

            // this routine changed between  v19 and v27
            // this don't work, the card doesn't come from sources anymore... 
            //foreach(var source in customer.Sources)
            //foreach (var source in customer.Sources)
            //{
            //    if (source.Card.Id == customer.DefaultSourceId)
            //        return source.Card;
            //}


            return null;
        }
    }
}
