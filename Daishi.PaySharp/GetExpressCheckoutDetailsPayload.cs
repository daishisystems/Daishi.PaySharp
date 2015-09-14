namespace Daishi.PaySharp {
    /// <summary>
    ///     Metadata necessary to facilitate a successful PayPal
    ///     <c>GetExpressCheckoutDetails</c> call.
    /// </summary>
    public class GetExpressCheckoutDetailsPayload : ExpressCheckoutPayload {
        public string AccessToken { get; set; }
        public string PayerID { get; set; }
        public override string Method => "GetExpressCheckoutDetails";
    }
}