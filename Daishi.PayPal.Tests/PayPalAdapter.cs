#region Includes

using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

#endregion

namespace Daishi.PayPal.Tests {
    internal class PayPalAdapter {
        public string GetExpressCheckoutToken(ExpressCheckoutPayload expressCheckoutPayload,
            Encoding encoding, string setExpressCheckoutURI) {

            var nvc = new NameValueCollection {
                {"USER", expressCheckoutPayload.User},
                {"PWD", expressCheckoutPayload.Password},
                {"SIGNATURE", expressCheckoutPayload.Signature},
                {"METHOD", expressCheckoutPayload.Method},
                {"VERSION", expressCheckoutPayload.Version},
                {"PAYMENTREQUEST_0_PAYMENTACTION", expressCheckoutPayload.Action},
                {"PAYMENTREQUEST_0_AMT", expressCheckoutPayload.Amount},
                {"PAYMENTREQUEST_0_CURRENCYCODE", expressCheckoutPayload.CurrencyCode},
                {"cancelUrl", expressCheckoutPayload.CancelUrl},
                {"returnUrl", expressCheckoutPayload.ReturnUrl}
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
                    throw new FormatException("Token response could not be parsed.");
                }

                var tokenPair = parsedTokenResponse[0].Split('=');

                if (!tokenPair.Length.Equals(2)) {
                    throw new FormatException("Token response is invalid.");
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