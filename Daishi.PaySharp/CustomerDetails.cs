namespace Daishi.PaySharp {
    /// Represents metadata returned by PayPal as a result of successfully invoking
    /// <b>GetExpressCheckoutDetails</b>
    /// .
    public class CustomerDetails {
        /// <summary>Gets or sets the access token.</summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }
        /// <summary>Gets or sets the billing agreement accepted status.</summary>
        /// <value>The billing agreement accepted status.</value>
        public string BillingAgreementAcceptedStatus { get; set; }
        /// <summary>Gets or sets the checkout status.</summary>
        /// <value>The checkout status.</value>
        public string CheckoutStatus { get; set; }
        /// <summary>Gets or sets the time stamp.</summary>
        /// <value>The time stamp.</value>
        public string TimeStamp { get; set; }
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
        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }
        /// <summary>Gets or sets the payer identifier.</summary>
        /// <value>The payer identifier.</value>
        public string PayerID { get; set; }
        /// <summary>Gets or sets the payer status.</summary>
        /// <value>The payer status.</value>
        public string PayerStatus { get; set; }
        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }
        /// <summary>Gets or sets the last name.</summary>
        /// <value>the last name.</value>
        public string LastName { get; set; }
        /// <summary>Gets or sets the country code.</summary>
        /// <value>The country code.</value>
        public string CountryCode { get; set; }
        /// <summary>Gets or sets the name of the billing.</summary>
        /// <value>The name of the billing.</value>
        public string BillingName { get; set; }
        /// <summary>Gets or sets the street.</summary>
        /// <value>The street.</value>
        public string Street { get; set; }
        /// <summary>Gets or sets the street2.</summary>
        /// <value>The street2.</value>
        public string Street2 { get; set; }
        /// <summary>Gets or sets the city.</summary>
        /// <value>The city.</value>
        public string City { get; set; }
        /// <summary>Gets or sets the state.</summary>
        /// <value>The state.</value>
        public string State { get; set; }
        /// <summary>Gets or sets the zip.</summary>
        /// <value>The zip.</value>
        public string Zip { get; set; }
        /// <summary>Gets or sets the country.</summary>
        /// <value>The country.</value>
        public string Country { get; set; }
        /// <summary>Gets or sets the name of the country.</summary>
        /// <value>The name of the country.</value>
        public string CountryName { get; set; }
        /// <summary>Gets or sets the address identifier.</summary>
        /// <value>The address identifier.</value>
        public string AddressID { get; set; }
        /// <summary>Gets or sets the address status.</summary>
        /// <value>The address status.</value>
        public string AddressStatus { get; set; }
        /// <summary>Gets or sets the currency code.</summary>
        /// <value>The currency code.</value>
        public string CurrencyCode { get; set; }
        /// <summary>Gets or sets the amt.</summary>
        /// <value>The amt.</value>
        public string Amt { get; set; }
        /// <summary>Gets or sets the item amt.</summary>
        /// <value>The item amt.</value>
        public string ItemAmt { get; set; }
        /// <summary>Gets or sets the shipping amt.</summary>
        /// <value>The shipping amt.</value>
        public string ShippingAmt { get; set; }
        /// <summary>Gets or sets the handling amt.</summary>
        /// <value>The handling amt.</value>
        public string HandlingAmt { get; set; }
        /// <summary>Gets or sets the tax amt.</summary>
        /// <value>The tax amt.</value>
        public string TaxAmt { get; set; }
        /// <summary>Gets or sets the insurance amt.</summary>
        /// <value>The insurance amt.</value>
        public string InsuranceAmt { get; set; }
        /// <summary>Gets or sets the ship disc amt.</summary>
        /// <value>The ship disc amt.</value>
        public string ShipDiscAmt { get; set; }
        /// <summary>Gets or sets the name of the.</summary>
        /// <value>The name of the.</value>
        public string LName { get; set; }
        /// <summary>Gets or sets the quantity.</summary>
        /// <value>the quantity.</value>
        public string LQuantity { get; set; }
        /// <summary>Gets or sets the tax amt.</summary>
        /// <value>the tax amt.</value>
        public string LTaxAmt { get; set; }
        /// <summary>Gets or sets the amt.</summary>
        /// <value>the amt.</value>
        public string LAmt { get; set; }
        /// <summary>Gets or sets the description.</summary>
        /// <value>the description.</value>
        public string LDescription { get; set; }
        /// <summary>Gets or sets the item weight value.</summary>
        /// <value>the item weight value.</value>
        public string LItemWeightValue { get; set; }
        /// <summary>Gets or sets the item length value.</summary>
        /// <value>the item length value.</value>
        public string LItemLengthValue { get; set; }
        /// <summary>Gets or sets the item width value.</summary>
        /// <value>the item width value.</value>
        public string LItemWidthValue { get; set; }
        /// <summary>Gets or sets the item height value.</summary>
        /// <value>the item height value.</value>
        public string LItemHeightValue { get; set; }
        /// <summary>Gets or sets the payment request currency code.</summary>
        /// <value>The payment request currency code.</value>
        public string PaymentRequestCurrencyCode { get; set; }
        /// <summary>Gets or sets the payment request amt.</summary>
        /// <value>The payment request amt.</value>
        public string PaymentRequestAmt { get; set; }
        /// <summary>Gets or sets the payment request item amt.</summary>
        /// <value>The payment request item amt.</value>
        public string PaymentRequestItemAmt { get; set; }
        /// <summary>Gets or sets the payment request shipping amt.</summary>
        /// <value>The payment request shipping amt.</value>
        public string PaymentRequestShippingAmt { get; set; }
        /// <summary>Gets or sets the payment request handling amt.</summary>
        /// <value>The payment request handling amt.</value>
        public string PaymentRequestHandlingAmt { get; set; }
        /// <summary>Gets or sets the payment request tax amt.</summary>
        /// <value>The payment request tax amt.</value>
        public string PaymentRequestTaxAmt { get; set; }
        /// <summary>Gets or sets the payment request insurance amt.</summary>
        /// <value>The payment request insurance amt.</value>
        public string PaymentRequestInsuranceAmt { get; set; }
        /// <summary>Gets or sets the payment request ship disc amt.</summary>
        /// <value>The payment request ship disc amt.</value>
        public string PaymentRequestShipDiscAmt { get; set; }
        /// <summary>Gets or sets the payment request transaction identifier.</summary>
        /// <value>The payment request transaction identifier.</value>
        public string PaymentRequestTransactionID { get; set; }
        /// <summary>Gets or sets the payment request insurance option offered.</summary>
        /// <value>The payment request insurance option offered.</value>
        public string PaymentRequestInsuranceOptionOffered { get; set; }
        /// <summary>Gets or sets the payment request address normalisation status.</summary>
        /// <value>The payment request address normalisation status.</value>
        public string PaymentRequestAddressNormalisationStatus { get; set; }
        /// <summary>Gets or sets the name of the payment request.</summary>
        /// <value>The name of the payment request.</value>
        public string LPaymentRequestName { get; set; }
        /// <summary>Gets or sets the payment request quantity.</summary>
        /// <value>the payment request quantity.</value>
        public string LPaymentRequestQuantity { get; set; }
        /// <summary>Gets or sets the payment request tax amt.</summary>
        /// <value>the payment request tax amt.</value>
        public string LPaymentRequestTaxAmt { get; set; }
        /// <summary>Gets or sets the payment request amt.</summary>
        /// <value>the payment request amt.</value>
        public string LPaymentRequestAmt { get; set; }
        /// <summary>Gets or sets the payment request description.</summary>
        /// <value>the payment request description.</value>
        public string LPaymentRequestDescription { get; set; }
        /// <summary>Gets or sets the payment request item weight value.</summary>
        /// <value>the payment request item weight value.</value>
        public string LPaymentRequestItemWeightValue { get; set; }
        /// <summary>Gets or sets the payment request item length value.</summary>
        /// <value>the payment request item length value.</value>
        public string LPaymentRequestItemLengthValue { get; set; }
        /// <summary>Gets or sets the payment request item width value.</summary>
        /// <value>the payment request item width value.</value>
        public string LPaymentRequestItemWidthValue { get; set; }
        /// <summary>Gets or sets the payment request item height value.</summary>
        /// <value>the payment request item height value.</value>
        public string LPaymentRequestItemHeightValue { get; set; }
        /// <summary>Gets or sets the payment request information transaction identifier.</summary>
        /// <value>The payment request information transaction identifier.</value>
        public string PaymentRequestInfoTransactionID { get; set; }
        /// <summary>Gets or sets the payment request information error code.</summary>
        /// <value>The payment request information error code.</value>
        public string PaymentRequestInfoErrorCode { get; set; }

        #region Sandbox-only properties

        /// <summary>Gets or sets the name of the payment request ship to.</summary>
        /// <value>The name of the payment request ship to.</value>
        public string PaymentRequestShipToName { get; set; }
        /// <summary>Gets or sets the payment request ship to street.</summary>
        /// <value>The payment request ship to street.</value>
        public string PaymentRequestShipToStreet { get; set; }
        /// <summary>Gets or sets the payment request ship to city.</summary>
        /// <value>The payment request ship to city.</value>
        public string PaymentRequestShipToCity { get; set; }
        /// <summary>Gets or sets the state of the payment request ship to.</summary>
        /// <value>The state of the payment request ship to.</value>
        public string PaymentRequestShipToState { get; set; }
        /// <summary>Gets or sets the payment request ship to zip.</summary>
        /// <value>The payment request ship to zip.</value>
        public string PaymentRequestShipToZip { get; set; }
        /// <summary>Gets or sets the payment request ship to country code.</summary>
        /// <value>The payment request ship to country code.</value>
        public string PaymentRequestShipToCountryCode { get; set; }
        /// <summary>Gets or sets the name of the payment request ship to country.</summary>
        /// <value>The name of the payment request ship to country.</value>
        public string PaymentRequestShipToCountryName { get; set; }
        /// <summary>Gets or sets the name of the ship to.</summary>
        /// <value>The name of the ship to.</value>
        public string ShipToName { get; set; }
        /// <summary>Gets or sets the ship to street.</summary>
        /// <value>The ship to street.</value>
        public string ShipToStreet { get; set; }
        /// <summary>Gets or sets the ship to city.</summary>
        /// <value>The ship to city.</value>
        public string ShipToCity { get; set; }
        /// <summary>Gets or sets the state of the ship to.</summary>
        /// <value>The state of the ship to.</value>
        public string ShipToState { get; set; }
        /// <summary>Gets or sets the ship to zip.</summary>
        /// <value>The ship to zip.</value>
        public string ShipToZip { get; set; }
        /// <summary>Gets or sets the ship to country code.</summary>
        /// <value>The ship to country code.</value>
        public string ShipToCountryCode { get; set; }
        /// <summary>Gets or sets the name of the ship to country.</summary>
        /// <value>The name of the ship to country.</value>
        public string ShipToCountryName { get; set; }

        #endregion
    }
}