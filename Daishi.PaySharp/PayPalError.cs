﻿namespace Daishi.PaySharp {
    public class PayPalError {
        public string Timestamp { get; set; }
        public string CorrelationID { get; set; }
        public string Ack { get; set; }
        public string ErrorCode { get; set; }
        public string ShortMessage { get; set; }
        public string LongMessage { get; set; }
        public string Build { get; set; }
        public string Version { get; set; }
        public string SeverityCode { get; set; }
    }
}