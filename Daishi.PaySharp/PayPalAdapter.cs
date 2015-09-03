#region Includes

using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

#endregion

namespace Daishi.PaySharp {
    public class PayPalAdapter {

        public string SetExpressCheckout(SetExpressCheckoutPayload payload,
            Encoding encoding, string setExpressCheckoutURI) {

            var nvc = new NameValueCollection {
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

            using (var webClient = new WebClient()) {

                var response = webClient.UploadValues(setExpressCheckoutURI, nvc);
                return encoding.GetString(response);
            }
        }

        public async Task<string> SetExpressCheckoutAsync(SetExpressCheckoutPayload payload,
            Encoding encoding, string setExpressCheckoutURI) {

            var nvc = new NameValueCollection {
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

            using (var webClient = new WebClient()) {

                var response = await webClient.UploadValuesTaskAsync(setExpressCheckoutURI, nvc);
                return encoding.GetString(response);
            }
        }

        public string GetExpressCheckoutDetails(
            GetExpressCheckoutDetailsPayload payload, string getExpressCheckoutUri) {

            var nvc = new NameValueCollection {
                {"USER", payload.User},
                {"PWD", payload.Password},
                {"SIGNATURE", payload.Signature},
                {"METHOD", payload.Method},
                {"VERSION", payload.Version},
                {"TOKEN", payload.AccessToken}
            };

            var queryString = string.Join("&", nvc.AllKeys.Select(
                i => string.Concat(i, "=", HttpUtility.UrlEncode(nvc[i]))));

            using (var webClient = new WebClient()) {

                return webClient.DownloadString(
                    new Uri(string.Concat(getExpressCheckoutUri, "?", queryString)));
            }
        }

        public async Task<string> GetExpressCheckoutDetailsAsync(
            GetExpressCheckoutDetailsPayload payload, string getExpressCheckoutUri) {

            var nvc = new NameValueCollection {
                {"USER", payload.User},
                {"PWD", payload.Password},
                {"SIGNATURE", payload.Signature},
                {"METHOD", payload.Method},
                {"VERSION", payload.Version},
                {"TOKEN", payload.AccessToken}
            };

            var queryString = string.Join("&", nvc.AllKeys.Select(
                i => string.Concat(i, "=", HttpUtility.UrlEncode(nvc[i]))));

            using (var webClient = new WebClient()) {

                return await webClient.DownloadStringTaskAsync(
                    new Uri(string.Concat(getExpressCheckoutUri, "?", queryString)));
            }
        }
    }
}