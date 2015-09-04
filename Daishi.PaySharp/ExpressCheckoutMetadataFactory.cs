#region Includes

using System.Collections.Specialized;
using System.Linq;
using System.Web;

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

        public static string CreateGetExpressCheckoutDetailsQueryString(
            GetExpressCheckoutDetailsPayload payload) {

            var getExpressCheckoutDetailsMetadata = new NameValueCollection {
                {"USER", payload.User},
                {"PWD", payload.Password},
                {"SIGNATURE", payload.Signature},
                {"METHOD", payload.Method},
                {"VERSION", payload.Version},
                {"TOKEN", payload.AccessToken}
            };

            return string.Join("&",
                getExpressCheckoutDetailsMetadata.AllKeys.Select(
                    key => string.Concat(key, "=", HttpUtility.UrlEncode(
                        getExpressCheckoutDetailsMetadata[key]))));

        }
    }
}