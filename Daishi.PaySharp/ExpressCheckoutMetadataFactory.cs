#region Includes

using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;

#endregion

namespace Daishi.PaySharp
{
    internal static class ExpressCheckoutMetadataFactory
    {

        public static NameValueCollection CreateSetExpressCheckoutMetadata(
            SetExpressCheckoutPayload payload)
        {

            return new NameValueCollection {
                {"METHOD", payload.Method},
                {"VERSION", payload.Version},
                {"USER", payload.User},
                {"PWD", payload.Password},
                {"SIGNATURE", payload.Signature},
                {"SUBJECT", payload.Subject},
                {"LOCALECODE", payload.LocaleCode},
                {"RETURNURL", payload.ReturnUrl},
                {"CANCELURL", payload.CancelUrl},
                {"REQBILLINGADDRESS", payload.RequireBillingAddress},
                {"NOSHIPPING", payload.NoShipping},
                {"PAYMENTREQUEST_0_PAYMENTACTION", payload.Action},
                {"PAYMENTREQUEST_0_AMT", payload.Amount.ToString(CultureInfo.InvariantCulture)},
                {"PAYMENTREQUEST_0_CURRENCYCODE", payload.CurrencyCode},
                {"MAXAMT", payload.Amount.ToString(CultureInfo.InvariantCulture)},
                {"L_PAYMENTREQUEST_0_NAME0", payload.PaymentRequestName},
                {"L_PAYMENTREQUEST_0_DESC0", payload.PaymentRequestDescription},
                {"L_PAYMENTREQUEST_0_AMT0", payload.Amount.ToString(CultureInfo.InvariantCulture)},
                {"L_PAYMENTREQUEST_0_QTY0", payload.PaymentRequestQuantity}
            };
        }

        public static string CreateGetExpressCheckoutDetailsQueryString(
            GetExpressCheckoutDetailsPayload payload)
        {

            var getExpressCheckoutDetailsMetadata = new NameValueCollection {
                {"METHOD", payload.Method},
                {"VERSION", payload.Version},
                {"USER", payload.User},
                {"PWD", payload.Password},
                {"SIGNATURE", payload.Signature},
                {"SUBJECT", payload.Subject},
                {"TOKEN", payload.AccessToken},
                {"PAYERID", payload.PayerID},
            };

            return string.Join("&",
                getExpressCheckoutDetailsMetadata.AllKeys.Select(
                    key => string.Concat(key, "=", HttpUtility.UrlEncode(
                        getExpressCheckoutDetailsMetadata[key]))));

        }

        public static string CreateDoExpressCheckoutPaymentQueryString(
            DoExpressCheckoutPaymentPayload payload)
        {

            var doExpressCheckoutPaymentMetadata = new NameValueCollection {
                {"METHOD", payload.Method},
                {"VERSION", payload.Version},
                {"USER", payload.User},
                {"PWD", payload.Password},
                {"SIGNATURE", payload.Signature},
                {"SUBJECT", payload.Subject},
                {"TOKEN", payload.AccessToken},
                {"PAYERID", payload.PayerID}, {
                    "PAYMENTREQUEST_0_PAYMENTACTION",
                    payload.PaymentRequestPaymentAction
                },
                {"PAYMENTREQUEST_0_AMT", payload.PaymentRequestAmt}, {
                    "PAYMENTREQUEST_0_CURRENCYCODE",
                    payload.PaymentRequestCurrencyCode
                },
                {"PAYMENTREQUEST_0_NOTIFYURL", payload.PaymentRequestNotifyUrl},
            };

            return string.Join("&",
                doExpressCheckoutPaymentMetadata.AllKeys.Select(
                    key => string.Concat(key, "=", HttpUtility.UrlEncode(
                        doExpressCheckoutPaymentMetadata[key]))));
        }
    }
}