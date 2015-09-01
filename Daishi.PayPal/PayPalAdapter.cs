#region Includes

using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web;

#endregion

namespace Daishi.PayPal {
    public class PayPalAdapter {
        public string SetExpressCheckout(SetExpressCheckoutPayload setExpressCheckoutPayload,
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

        public CustomerDetails ParseCustomerDetails(string expressCheckoutDetails) {

            var parsedExpressCheckoutDetails =
                HttpUtility.ParseQueryString(expressCheckoutDetails);

            return new CustomerDetails {
                Token = parsedExpressCheckoutDetails["TOKEN"],
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
        }
    }
}