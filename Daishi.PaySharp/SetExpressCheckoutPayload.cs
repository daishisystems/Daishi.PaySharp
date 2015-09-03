namespace Daishi.PaySharp {
    public class SetExpressCheckoutPayload : ExpressCheckoutPayload {
        private string _action;

        public string Action
        {
            get { return string.IsNullOrEmpty(_action) ? "SALE" : _action; }
            set { _action = value; }
        }
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string CancelUrl { get; set; }
        public string ReturnUrl { get; set; }
    }
}