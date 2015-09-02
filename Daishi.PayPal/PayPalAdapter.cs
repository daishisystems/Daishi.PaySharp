#region Includes

using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

#endregion

namespace Daishi.PayPal {
    public class PayPalAdapter {
        public static string SetExpressCheckout(SetExpressCheckoutPayload payload,
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

            string response;

            using (var webClient = new WebClient()) {
                response = encoding.GetString(webClient.UploadValues(
                    setExpressCheckoutURI, nvc));
            }

            var parsedResponse = response.Split(new[] {'&'},
                StringSplitOptions.RemoveEmptyEntries);

            if (parsedResponse.Length.Equals(0)) {
                throw new FormatException("Malformed PayPal response.");
            }

            var accessTokenSegment = parsedResponse[0].Split('=');

            if (!accessTokenSegment.Length.Equals(2)) {
                throw new FormatException("Malformed PayPal Access Token KV.");
            }

            return accessTokenSegment[1];
        }

        public static async Task<string> GetExpressCheckoutDetailsAsync(
            GetExpressCheckoutDetailsPayload payload, string getExpressCheckoutUri) {

            var nvc = new NameValueCollection {
                {"USER", payload.User},
                {"PWD", payload.Password},
                {"SIGNATURE", payload.Signature},
                {"METHOD", payload.Method},
                {"VERSION", payload.Version},
                {"TOKEN", payload.AccessToken}
            };

            using (var webClient = new WebClient()) {

                var queryString = string.Join("&", nvc.AllKeys.Select(
                    i => string.Concat(i, "=", HttpUtility.UrlEncode(nvc[i]))));

                return await webClient.DownloadStringTaskAsync(
                    new Uri(string.Concat(getExpressCheckoutUri, "?", queryString)));
            }
        }

        public static bool TryParseCustomerDetails(string getExpressCheckoutDetails,
            out CustomerDetails customerDetails, out PayPalError payPalError) {

            var parsedExpressCheckoutDetails =
                HttpUtility.ParseQueryString(getExpressCheckoutDetails);

            if (parsedExpressCheckoutDetails["L_ERRORCODE0"] == null) {

                customerDetails = new CustomerDetails {
                    AccessToken = parsedExpressCheckoutDetails["TOKEN"],
                    BillingAgreementAcceptedStatus = parsedExpressCheckoutDetails
                        ["BILLINGAGREEMENTACCEPTEDSTATUS"],
                    CheckoutStatus = parsedExpressCheckoutDetails["CHECKOUTSTATUS"],
                    TimeStamp = parsedExpressCheckoutDetails["TIMESTAMP"],
                    CorrelationID = parsedExpressCheckoutDetails["CORRELATIONID"],
                    Ack = parsedExpressCheckoutDetails["ACK"],
                    Version = parsedExpressCheckoutDetails["VERSION"],
                    Build = parsedExpressCheckoutDetails["BUILD"],
                    Email = parsedExpressCheckoutDetails["EMAIL"],
                    PayerID = parsedExpressCheckoutDetails["PAYERID"],
                    PayerStatus = parsedExpressCheckoutDetails["PAYERSTATUS"],
                    FirstName = parsedExpressCheckoutDetails["FIRSTNAME"],
                    LastName = parsedExpressCheckoutDetails["LASTNAME"],
                    CountryCode = parsedExpressCheckoutDetails["COUNTRYCODE"],
                    ShipToName = parsedExpressCheckoutDetails["SHIPTONAME"],
                    ShipToStreet = parsedExpressCheckoutDetails["SHIPTOSTREET"],
                    ShipToCity = parsedExpressCheckoutDetails["SHIPTOCITY"],
                    ShipToState = parsedExpressCheckoutDetails["SHIPTOSTATE"],
                    ShipToZip = parsedExpressCheckoutDetails["SHIPTOZIP"],
                    ShipToCountryCode = parsedExpressCheckoutDetails["SHIPTOCOUNTRYCODE"],
                    ShipToCountryName = parsedExpressCheckoutDetails["SHIPTOCOUNTRYNAME"],
                    AddressStatus = parsedExpressCheckoutDetails["ADDRESSSTATUS"],
                    CurrencyCode = parsedExpressCheckoutDetails["CURRENCYCODE"],
                    Amt = parsedExpressCheckoutDetails["AMT"],
                    ShippingAmt = parsedExpressCheckoutDetails["SHIPPINGAMT"],
                    HandlingAmt = parsedExpressCheckoutDetails["HANDLINGAMT"],
                    TaxAmt = parsedExpressCheckoutDetails["TAXAMT"],
                    InsuranceAmt = parsedExpressCheckoutDetails["INSURANCEAMT"],
                    ShipDiscAmt = parsedExpressCheckoutDetails["SHIPDISCAMT"],
                    PaymentRequestCurrencyCode = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_CURRENCYCODE"],
                    PaymentRequestAmt = parsedExpressCheckoutDetails["PAYMENTREQUEST_0_AMT"],
                    PaymentRequestShippingAmt = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_SHIPPINGAMT"],
                    PaymentRequestHandlingAmt = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_HANDLINGAMT"],
                    PaymentRequestTaxAmt = parsedExpressCheckoutDetails["PAYMENTREQUEST_0_TAXAMT"],
                    PaymentRequestInsuranceAmt = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_INSURANCEAMT"],
                    PaymentRequestShipDiscAmt = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_SHIPDISCAMT"],
                    PaymentRequestInsuranceOptionOffered = parsedExpressCheckoutDetails["PAYMENTREQUEST_0_INSURANCEOPTIONOFFERED"],
                    PaymentRequestShipToName = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_SHIPTONAME"],
                    PaymentRequestShipToStreet = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_SHIPTOSTREET"],
                    PaymentRequestShipToCity = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_SHIPTOCITY"],
                    PaymentRequestShipToState = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_SHIPTOSTATE"],
                    PaymentRequestShipToZip = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_SHIPTOZIP"],
                    PaymentRequestShipToCountryCode = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_SHIPTOCOUNTRYCODE"],
                    PaymentRequestShipToCountryName = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_SHIPTOCOUNTRYNAME"],
                    PaymentRequestAddressStatus = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_ADDRESSSTATUS"],
                    PaymentRequestInfoErrorCode = parsedExpressCheckoutDetails
                        ["PAYMENTREQUESTINFO_0_ERRORCODE"]
                };

                payPalError = null;
                return true;
            }

            payPalError = new GetExpressCheckoutDetailsPayPalError {
                Timestamp = parsedExpressCheckoutDetails["TIMESTAMP"],
                CorrelationID = parsedExpressCheckoutDetails["CORRELATIONID"],
                Ack = parsedExpressCheckoutDetails["ACK"],
                ErrorCode = parsedExpressCheckoutDetails["L_ERRORCODE0"],
                ShortMessage = parsedExpressCheckoutDetails["L_SHORTMESSAGE0"],
                LongMessage = parsedExpressCheckoutDetails["L_LONGMESSAGE0"]
            };

            customerDetails = null;
            return false;
        }
    }
}