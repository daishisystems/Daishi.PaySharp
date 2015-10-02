using System.Runtime.Remoting.Messaging;

namespace Daishi.PaySharp
{
    /// <summary>
    ///     <summary>Metadata necessary to facilitate successful PayPal
    ///         <b>DoExpressCheckoutPayment</b> calls.</summary>
    /// </summary>
    public class DoExpressCheckoutPaymentPayload : ExpressCheckoutPayload
    {
        /// <summary>Gets the method.</summary>
        /// <value>The method.</value>
        public override string Method
        {
            get { return "DoExpressCheckoutPayment"; }
        }
        /// <summary>Gets or sets the access token.</summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }
        /// <summary>Gets or sets the payer identifier.</summary>
        /// <value>The payer identifier.</value>
        public string PayerID { get; set; }
        /// <summary>Gets or sets the payment request payment action.</summary>
        /// <value>The payment request payment action.</value>
        public string PaymentRequestPaymentAction
        {
            get { return "SALE"; }
        }
        /// <summary>Gets or sets the payment request amt.</summary>
        /// <value>The payment request amt.</value>
        public string PaymentRequestAmt { get; set; }
        /// <summary>Gets or sets the payment request currency code.</summary>
        /// <value>The payment request currency code.</value>
        public string PaymentRequestCurrencyCode { get; set; }
        /// <summary>Gets or sets the payment request notify url.</summary>
        /// <value>The payment request notify url.</value>
        public string PaymentRequestNotifyUrl { get; set; }
    }
}