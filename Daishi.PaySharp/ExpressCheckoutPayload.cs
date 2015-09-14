namespace Daishi.PaySharp {
    /// <summary>Metadata necessary to facilitate successful PayPal
    ///     <c>ExpressCheckout</c> calls.</summary>
    public abstract class ExpressCheckoutPayload {
        public string User { get; set; }
        public string Password { get; set; }
        public string Signature { get; set; }
        public abstract string Method { get; }
        public string Version { get; set; }
        public string Subject { get; set; }
    }
}