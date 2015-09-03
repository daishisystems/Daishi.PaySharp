#region Includes

using System;
using System.Collections.Specialized;
using System.Web;

#endregion

namespace Daishi.PaySharp {
    /// <summary>
    ///     <c>PayPalUtility</c> provides functionality designed to augment
    ///     <see cref="PayPalAdapter" />. It provides parsing mechanisms designed
    ///     to deserialise PayPal metadata returned by <see cref="PayPalAdapter" />
    ///     methods.
    ///     <remarks>
    ///         PayPal exposes metadata in a form-urlencoded format.
    ///         <see cref="PayPalUtility" /> provides a means to deserialise PayPal
    ///         metadata to associated POCO.
    ///     </remarks>
    /// </summary>
    public static class PayPalUtility {

        /// <summary>
        ///     Parses PayPal metadata returned by <c>SetExpressCheckout</c> and returns
        ///     the encapsulated PayPal Access Token.
        /// </summary>
        /// <param name="setExpressCheckoutDetails">
        ///     PayPal metadata returned by <c>SetExpressCheckout</c>.
        /// </param>
        /// <param name="accessToken">PayPal API Access Token.</param>
        /// <param name="payPalError">
        ///     PayPal error response.
        ///     <remarks>
        ///         PayPalError is a POCO deserialised from a form-urlencoded HTTP response.
        ///     </remarks>
        /// </param>
        /// <returns>Returns a <see cref="bool" /> value indicating success.</returns>
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

        /// <summary>
        ///     Parses PayPal metadata returned by SetExpressCheckout and returns
        ///     the encapsulated PayPal <see cref="CustomerDetails" />.
        /// </summary>
        /// <param name="getExpressCheckoutDetails">
        ///     PayPal metadata returned by <c>GetExpressCheckoutDetails</c>.
        /// </param>
        /// <param name="customerDetails">PayPal Customer Details.</param>
        /// <param name="payPalError">
        ///     PayPal error response.
        ///     <remarks>
        ///         PayPalError is a POCO deserialised from a form-urlencoded HTTP response.
        ///     </remarks>
        /// </param>
        /// <returns>Returns a <see cref="bool" /> value indicating success.</returns>
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

        /// <summary>
        ///     Determines whether or not the specified <see cref="NameValueCollection" />
        ///     represents error metadata returned from PayPal.
        /// </summary>
        /// <param name="nvc">The <see cref="NameValueCollection" /> returned from PayPal.</param>
        /// <returns>
        ///     Returns a <see cref="bool" /> value indicating whether or not the specified
        ///     <see cref="NameValueCollection" /> represents error metadata returned from PayPal.
        /// </returns>
        private static bool IsErrorResponse(NameValueCollection nvc) {

            if (nvc == null || nvc.Count.Equals(0)) {
                throw new ArgumentException("The specified response is empty or null.");
            }
            return nvc["L_ERRORCODE0"] == null;
        }
    }
}