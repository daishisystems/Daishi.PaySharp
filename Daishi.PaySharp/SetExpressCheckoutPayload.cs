namespace Daishi.PaySharp {
    /// <summary>Metadata necessary to facilitate a successful PayPal
    ///     <c>SetExpressCheckout</c> call.</summary>
    public class SetExpressCheckoutPayload : ExpressCheckoutPayload {

        public string Action => "Sale";
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string CancelUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string LocaleCode { get; set; }
        public string RequireBillingAddress => "1";
        public string NoShipping => "1";
        public string PaymentRequestName { get; set; }
        public string PaymentRequestDescription { get; set; }
        public string PaymentRequestQuantity => "1";
        public override string Method => "SetExpressCheckout";
    }
}