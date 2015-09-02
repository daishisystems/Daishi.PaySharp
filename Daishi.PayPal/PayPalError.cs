namespace Daishi.PayPal {
    public abstract class PayPalError {
        public string Timestamp { get; set; }
        public string CorrelationID { get; set; }
        public string Ack { get; set; }
        public string ErrorCode { get; set; }
        public string ShortMessage { get; set; }
        public string LongMessage { get; set; }
    }
}