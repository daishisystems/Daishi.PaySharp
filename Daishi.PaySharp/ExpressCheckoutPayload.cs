namespace Daishi.PaySharp {
    public abstract class ExpressCheckoutPayload {
        public string User { get; set; }
        public string Password { get; set; }
        public string Signature { get; set; }
        public string Method { get; set; }
        public string Version { get; set; }
    }
}