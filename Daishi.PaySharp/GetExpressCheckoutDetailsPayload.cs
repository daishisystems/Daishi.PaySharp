namespace Daishi.PaySharp {
    /// <summary>Metadata necessary to facilitate successful PayPal
    ///     <b>GetExpressCheckoutDetails</b> calls.</summary>
    public class GetExpressCheckoutDetailsPayload : ExpressCheckoutPayload {
        /// <summary>Gets or sets the access token.</summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }
        /// <summary>Gets or sets the payer identifier.</summary>
        /// <value>The payer identifier.</value>
        public string PayerID { get; set; }
        /// <summary>Gets or sets the method.</summary>
        /// <value>The method.</value>
        public override string Method => "GetExpressCheckoutDetails";
    }
}