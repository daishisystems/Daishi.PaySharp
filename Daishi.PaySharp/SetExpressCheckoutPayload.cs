namespace Daishi.PaySharp {
    public class SetExpressCheckoutPayload : ExpressCheckoutPayload {
        public string Action { get; set; }
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string CancelUrl { get; set; }
        public string ReturnUrl { get; set; }
    }
}