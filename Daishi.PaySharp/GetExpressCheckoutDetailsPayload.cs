namespace Daishi.PaySharp {
    /// <summary>
    ///     Metadata necessary to facilitate a successful <c>GetExpressCheckoutDetails</c> call.
    /// </summary>
    public class GetExpressCheckoutDetailsPayload : ExpressCheckoutPayload {
        public string AccessToken { get; set; }
    }
}