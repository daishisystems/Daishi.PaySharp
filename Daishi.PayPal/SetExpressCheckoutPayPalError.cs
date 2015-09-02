namespace Daishi.PayPal {
    public class SetExpressCheckoutPayPalError : PayPalError {
        public string Build { get; set; }
        public string Version { get; set; }
        public string SeverityCode { get; set; }
    }
}