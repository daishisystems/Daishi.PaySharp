#region Includes

using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Daishi.PaySharp {
    /// <summary>
    ///     <c>PayPalAdapter</c> interfaces with PayPal HTTP endpoints and provides
    ///     both synchronous and asynchronous mechanisms that consume those endpoints.
    ///     <remarks>
    ///         PayPal exposes metadata in a form-encoded format.
    ///         <c>PayPalAdapter</c>
    ///         provides a means to retrieve such PayPal metadata in raw-format.
    ///     </remarks>
    /// </summary>
    public class PayPalAdapter {

        /// <summary>
        ///     Executes PayPal's <c>SetExpressCheckout</c> function in order to
        ///     return a PayPal Access Token.
        /// </summary>
        /// <param name="payload">
        ///     Metadata necessary to facilitate a successful
        ///     <c>SetExpressCheckout</c> call. Payload will be converted to key-value
        ///     format.
        /// </param>
        /// <param name="encoding">Text encoding to apply during byte-to-text conversion.</param>
        /// <param name="expressCheckoutURI">Default PayPal ExpressCheckout HTTP URI.</param>
        /// <returns>Raw metadata, in key-value format, containing a PayPal Access Token.</returns>
        public string SetExpressCheckout(SetExpressCheckoutPayload payload,
            Encoding encoding, string expressCheckoutURI) {

            var setExpressCheckoutMetadata =
                ExpressCheckoutMetadataFactory.CreateSetExpressCheckoutMetadata(
                    payload);

            using (var webClient = new WebClient()) {

                var response = webClient.UploadValues(expressCheckoutURI,
                    setExpressCheckoutMetadata);
                return encoding.GetString(response);
            }
        }

        /// <summary>
        ///     SetExpressCheckout asynchronous equivalent.
        ///     <seealso cref="SetExpressCheckout" />
        /// </summary>
        /// <param name="payload">
        ///     Metadata necessary to facilitate a successful
        ///     <c>SetExpressCheckout</c> call. Payload will be converted to key-value
        ///     format.
        /// </param>
        /// <param name="encoding">Text encoding to apply during byte-to-text conversion.</param>
        /// <param name="expressCheckoutURI">Default PayPal ExpressCheckout HTTP URI.</param>
        /// <returns>
        ///     A <see cref="Task" /> of <see cref="string" />, representing raw
        ///     metadata, in key-value format, containing a PayPal Access Token.
        /// </returns>
        public async Task<string> SetExpressCheckoutAsync(
            SetExpressCheckoutPayload payload,
            Encoding encoding, string expressCheckoutURI) {

            var setExpressCheckoutMetadata =
                ExpressCheckoutMetadataFactory.CreateSetExpressCheckoutMetadata(
                    payload);

            using (var webClient = new WebClient()) {

                var response =
                    await webClient.UploadValuesTaskAsync(expressCheckoutURI,
                        setExpressCheckoutMetadata);
                return encoding.GetString(response);
            }
        }

        /// <summary>
        ///     Executes PayPal's <c>GetExpressCheckoutDetails</c> function in order
        ///     to return PayPal <see cref="CustomerDetails" />.
        /// </summary>
        /// <param name="payload">
        ///     Metadata necessary to facilitate a successful
        ///     <c>GetExpressCheckoutDetails</c> call. Payload will be converted to
        ///     key-value format.
        /// </param>
        /// <param name="expressCheckoutUri">Default PayPal ExpressCheckout HTTP URI.</param>
        /// <returns>
        ///     A <see cref="Task" /> of <see cref="string" />, representing a
        ///     serialised <see cref="CustomerDetails" /> instance.
        /// </returns>
        public string GetExpressCheckoutDetails(
            GetExpressCheckoutDetailsPayload payload, string expressCheckoutUri) {

            var queryString =
                ExpressCheckoutMetadataFactory
                    .CreateGetExpressCheckoutDetailsQueryString(payload);

            using (var webClient = new WebClient()) {

                return webClient.DownloadString(
                    new Uri(string.Concat(expressCheckoutUri, "?", queryString)));
            }
        }

        /// <summary>
        ///     GetExpressCheckoutDetails asynchronous equivalent.
        ///     <seealso cref="GetExpressCheckoutDetails" />
        /// </summary>
        /// <param name="payload">
        ///     Metadata necessary to facilitate a successful
        ///     <c>GetExpressCheckoutDetails</c> call. Payload will be converted to
        ///     key-value format.
        /// </param>
        /// <param name="getExpressCheckoutUri">Default PayPal ExpressCheckout HTTP URI.</param>
        /// <returns>
        ///     A <see cref="Task" /> of <see cref="string" />, representing a
        ///     serialised <see cref="CustomerDetails" /> instance.
        /// </returns>
        public async Task<string> GetExpressCheckoutDetailsAsync(
            GetExpressCheckoutDetailsPayload payload,
            string getExpressCheckoutUri) {

            var queryString =
                ExpressCheckoutMetadataFactory
                    .CreateGetExpressCheckoutDetailsQueryString(payload);

            using (var webClient = new WebClient()) {

                return await webClient.DownloadStringTaskAsync(
                    new Uri(string.Concat(getExpressCheckoutUri, "?",
                        queryString)));
            }
        }       
    }
}