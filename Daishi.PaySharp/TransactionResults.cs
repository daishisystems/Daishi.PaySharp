namespace Daishi.PaySharp {
    /// <summary>
    ///     Represents metadata returned by PayPal as a result of successfully
    ///     invoking <b>DoExpressCheckoutPayment</b>.
    /// </summary>
    public class TransactionResults {
        /// <summary>Gets or sets the token.</summary>
        /// <value>The token.</value>
        public string Token { get; set; }
        /// <summary>Gets or sets the success page redirect requested.</summary>
        /// <value>The success page redirect requested.</value>
        public string SuccessPageRedirectRequested { get; set; }
        /// <summary>Gets or sets the time-stamp.</summary>
        /// <value>The time-stamp.</value>
        public string Timestamp { get; set; }
        /// <summary>Gets or sets the correlation identifier.</summary>
        /// <value>The correlation identifier.</value>
        public string CorrelationID { get; set; }
        /// <summary>Gets or sets the acknowledgment.</summary>
        /// <value>The acknowledgment.</value>
        public string Ack { get; set; }
        /// <summary>Gets or sets the version.</summary>
        /// <value>The version.</value>
        public string Version { get; set; }
        /// <summary>Gets or sets the build.</summary>
        /// <value>The build.</value>
        public string Build { get; set; }
        /// <summary>Gets or sets the insurance option selected.</summary>
        /// <value>The insurance option selected.</value>
        public string InsuranceOptionSelected { get; set; }
        /// <summary>Gets or sets the shipping option is default.</summary>
        /// <value>The shipping option is default.</value>
        public string ShippingOptionIsDefault { get; set; }
        /// <summary>Gets or sets the payment information transaction identifier.</summary>
        /// <value>The payment information transaction identifier.</value>
        public string PaymentInfoTransactionID { get; set; }
        /// <summary>Gets or sets the type of the payment information transaction.</summary>
        /// <value>The type of the payment information transaction.</value>
        public string PaymentInfoTransactionType { get; set; }
        /// <summary>Gets or sets the type of the payment information payment.</summary>
        /// <value>The type of the payment information payment.</value>
        public string PaymentInfoPaymentType { get; set; }
        /// <summary>Gets or sets the payment information order time.</summary>
        /// <value>The payment information order time.</value>
        public string PaymentInfoOrderTime { get; set; }
        /// <summary>Gets or sets the payment information amt.</summary>
        /// <value>The payment information amt.</value>
        public string PaymentInfoAmt { get; set; }
        /// <summary>Gets or sets the payment information fee amt.</summary>
        /// <value>The payment information fee amt.</value>
        public string PaymentInfoFeeAmt { get; set; }
        /// <summary>Gets or sets the payment information tax amt.</summary>
        /// <value>The payment information tax amt.</value>
        public string PaymentInfoTaxAmt { get; set; }
        /// <summary>Gets or sets the payment information currency code.</summary>
        /// <value>The payment information currency code.</value>
        public string PaymentInfoCurrencyCode { get; set; }
        /// <summary>Gets or sets the payment information payment status.</summary>
        /// <value>The payment information payment status.</value>
        public string PaymentInfoPaymentStatus { get; set; }
        /// <summary>Gets or sets the payment information pending reason.</summary>
        /// <value>The payment information pending reason.</value>
        public string PaymentInfoPendingReason { get; set; }
        /// <summary>Gets or sets the payment information reason code.</summary>
        /// <value>The payment information reason code.</value>
        public string PaymentInfoReasonCode { get; set; }
        /// <summary>Gets or sets the payment information protection eligibility.</summary>
        /// <value>The payment information protection eligibility.</value>
        public string PaymentInfoProtectionEligibility { get; set; }
        /// <summary>
        ///     Gets or sets the type of the payment information protection
        ///     eligibility.
        /// </summary>
        /// <value>The type of the payment information protection eligibility.</value>
        public string PaymentInfoProtectionEligibilityType { get; set; }
        /// <summary>
        ///     Gets or sets the payment information secure merchant account
        ///     identifier.
        /// </summary>
        /// <value>The payment information secure merchant account identifier.</value>
        public string PaymentInfoSecureMerchantAccountID { get; set; }
        /// <summary>Gets or sets the payment information error code.</summary>
        /// <value>The payment information error code.</value>
        public string PaymentInfoErrorCode { get; set; }
        /// <summary>Gets or sets the payment information acknowledgment.</summary>
        /// <value>The payment information acknowledgment.</value>
        public string PaymentInfoAck { get; set; }
    }
}