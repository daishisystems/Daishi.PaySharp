#region Includes

using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

#endregion

namespace Daishi.PayPal {
    public class PayPalAdapter {
        public string GetExpressCheckoutToken(SetExpressCheckoutPayload setExpressCheckoutPayload,
            Encoding encoding, string setExpressCheckoutURI) {

            var nvc = new NameValueCollection {
                {"USER", setExpressCheckoutPayload.User},
                {"PWD", setExpressCheckoutPayload.Password},
                {"SIGNATURE", setExpressCheckoutPayload.Signature},
                {"METHOD", setExpressCheckoutPayload.Method},
                {"VERSION", setExpressCheckoutPayload.Version},
                {"PAYMENTREQUEST_0_PAYMENTACTION", setExpressCheckoutPayload.Action},
                {"PAYMENTREQUEST_0_AMT", setExpressCheckoutPayload.Amount},
                {"PAYMENTREQUEST_0_CURRENCYCODE", setExpressCheckoutPayload.CurrencyCode},
                {"cancelUrl", setExpressCheckoutPayload.CancelUrl},
                {"returnUrl", setExpressCheckoutPayload.ReturnUrl}
            };

            try {
                string tokenResponse;

                using (var webClient = new WebClient()) {
                    tokenResponse = encoding.GetString(webClient.UploadValues(
                        setExpressCheckoutURI, nvc));
                }

                var parsedTokenResponse = tokenResponse.Split(new[] {'&'},
                    StringSplitOptions.RemoveEmptyEntries);

                if (parsedTokenResponse.Length.Equals(0)) {
                    throw new FormatException("PayPal token response could not be parsed.");
                }

                var tokenPair = parsedTokenResponse[0].Split('=');

                if (!tokenPair.Length.Equals(2)) {
                    throw new FormatException("PayPal token response is invalid.");
                }

                return tokenPair[1];
            }
            catch (Exception exception) {
                throw new PayPalException(
                    "An exception occurred while retrieving an Express Checkout Token.",
                    exception);
            }
        }
    }
}