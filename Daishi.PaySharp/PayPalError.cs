namespace Daishi.PaySharp {
    /// <summary>PayPal error metadata returned from <c>SetExpressCheckout</c> or
    ///     <c>GetExpressCheckoutDetails</c>.</summary>
    public class PayPalError {
        /// <summary>Gets or sets the time-stamp.</summary>
        /// <value>The time-stamp.</value>
        public string Timestamp { get; set; }
        /// <summary>Gets or sets the correlation identifier.</summary>
        /// <value>The correlation identifier.</value>
        public string CorrelationID { get; set; }
        /// <summary>Gets or sets the ack.</summary>
        /// <value>The ack.</value>
        public string Ack { get; set; }
        /// <summary>Gets or sets the error code.</summary>
        /// <value>The error code.</value>
        public string ErrorCode { get; set; }
        /// <summary>Gets or sets the short message.</summary>
        /// <value>The short message.</value>
        public string ShortMessage { get; set; }
        /// <summary>Gets or sets the long message.</summary>
        /// <value>The long message.</value>
        public string LongMessage { get; set; }
        /// <summary>Gets or sets the build.</summary>
        /// <value>The build.</value>
        public string Build { get; set; }
        /// <summary>Gets or sets the version.</summary>
        /// <value>The version.</value>
        public string Version { get; set; }
        /// <summary>Gets or sets the severity code.</summary>
        /// <value>The severity code.</value>
        public string SeverityCode { get; set; }
    }
}