namespace Daishi.PaySharp
{
    /// <summary>Metadata necessary to facilitate a successful PayPal
    ///     <b>SetExpressCheckout</b> call.</summary>
    public class SetExpressCheckoutPayload : ExpressCheckoutPayload
    {
        /// <summary>Gets or sets the action.</summary>
        /// <value>The action.</value>
        public string Action
        {
            get { return "Sale"; }
        }
        /// <summary>Gets or sets the amount.</summary>
        /// <value>The amount.</value>
        public string Amount { get; set; }
        /// <summary>Gets or sets the currency code.</summary>
        /// <value>The currency code.</value>
        public string CurrencyCode { get; set; }
        /// <summary>Gets or sets the cancel URL.</summary>
        /// <value>The cancel URL.</value>
        public string CancelUrl { get; set; }
        /// <summary>Gets or sets the return URL.</summary>
        /// <value>The return URL.</value>
        public string ReturnUrl { get; set; }
        /// <summary>Gets or sets the locale code.</summary>
        /// <value>The locale code.</value>
        public string LocaleCode { get; set; }
        /// <summary>Gets or sets the require billing address.</summary>
        /// <value>The require billing address.</value>
        public string RequireBillingAddress { get; set; }
        /// <summary>Gets or sets the no shipping.</summary>
        /// <value>The no shipping.</value>
        public string NoShipping
        {
            get { return "1"; }
        }
        /// <summary>Gets or sets the name of the payment request.</summary>
        /// <value>The name of the payment request.</value>
        public string PaymentRequestName { get; set; }
        /// <summary>Gets or sets the payment request description.</summary>
        /// <value>The payment request description.</value>
        public string PaymentRequestDescription { get; set; }
        /// <summary>Gets or sets the payment request quantity.</summary>
        /// <value>The payment request quantity.</value>
        public string PaymentRequestQuantity
        {
            get { return "1"; }
        }
        /// <summary>Gets or sets the method.</summary>
        /// <value>The method.</value>
        public override string Method
        {
            get { return "SetExpressCheckout"; }
        }
    }
}