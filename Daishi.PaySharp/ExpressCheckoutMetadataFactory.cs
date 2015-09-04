#region Includes

using System.Collections.Specialized;

#endregion

namespace Daishi.PaySharp {
    public static class ExpressCheckoutMetadataFactory {
        public static NameValueCollection CreateSetExpressCheckoutMetadata(
            SetExpressCheckoutPayload payload) {
            return new NameValueCollection {
                {"USER", payload.User},
                {"PWD", payload.Password},
                {"SIGNATURE", payload.Signature},
                {"METHOD", payload.Method},
                {"VERSION", payload.Version},
                {"PAYMENTREQUEST_0_PAYMENTACTION", payload.Action},
                {"PAYMENTREQUEST_0_AMT", payload.Amount},
                {"PAYMENTREQUEST_0_CURRENCYCODE", payload.CurrencyCode},
                {"cancelUrl", payload.CancelUrl},
                {"returnUrl", payload.ReturnUrl}
            };
        }
    }
}