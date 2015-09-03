#region Includes

using System;
using System.Collections.Specialized;
using System.Web;

#endregion

namespace Daishi.PayPal {
    public static class PayPalUtility {

        public static bool TryParseCustomerDetails(string getExpressCheckoutDetails,
            out CustomerDetails customerDetails,
            out PayPalError payPalError) {

            var parsedExpressCheckoutDetails =
                HttpUtility.ParseQueryString(getExpressCheckoutDetails);

            if (IsErrorResponse(parsedExpressCheckoutDetails)) {

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

            payPalError = new PayPalError {
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

        public static bool TryParseAccessToken(string setExpressCheckoutDetails,
            out string accessToken, out PayPalError payPalError) {

            var parsedExpressCheckoutDetails =
                HttpUtility.ParseQueryString(setExpressCheckoutDetails);

            if (IsErrorResponse(parsedExpressCheckoutDetails)) {
                accessToken = parsedExpressCheckoutDetails["TOKEN"];

                payPalError = null;
                return true;
            }

            payPalError = new PayPalError {
                Timestamp = parsedExpressCheckoutDetails["TIMESTAMP"],
                CorrelationID = parsedExpressCheckoutDetails["CORRELATIONID"],
                Ack = parsedExpressCheckoutDetails["ACK"],
                ErrorCode = parsedExpressCheckoutDetails["L_ERRORCODE0"],
                ShortMessage = parsedExpressCheckoutDetails["L_SHORTMESSAGE0"],
                LongMessage = parsedExpressCheckoutDetails["L_LONGMESSAGE0"],
                Build = parsedExpressCheckoutDetails["BUILD"],
                Version = parsedExpressCheckoutDetails["VERSION"],
                SeverityCode = parsedExpressCheckoutDetails["L_SEVERITYCODE0"]
            };

            accessToken = null;
            return false;
        }

        private static bool IsErrorResponse(NameValueCollection nvc) {

            if (nvc == null || nvc.Count.Equals(0)) {
                throw new ArgumentException("The specified response is empty or null.");
            }
            return nvc["L_ERRORCODE0"] == null;
        }
    }
}