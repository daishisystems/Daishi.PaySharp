#region Includes

using System;
using System.Collections.Specialized;
using System.Web;

#endregion

namespace Daishi.PaySharp {
    /// <summary>
    ///     <c>PayPalUtility</c> provides functionality designed to augment
    ///     <see cref="PayPalAdapter" />. It provides parsing mechanisms designed to
    ///     deserialise PayPal metadata returned by <see cref="PayPalAdapter" />
    ///     methods.
    ///     <remarks>
    ///         PayPal exposes metadata in a form-encoded format.
    ///         <see cref="PayPalUtility" /> provides a means to deserialise PayPal
    ///         metadata to associated POCO.
    ///     </remarks>
    /// </summary>
    public static class PayPalUtility {

        /// <summary>
        ///     Parses PayPal metadata returned by <c>SetExpressCheckout</c> and
        ///     returns the encapsulated PayPal Access Token.
        /// </summary>
        /// <param name="setExpressCheckoutDetails">
        ///     PayPal metadata returned by
        ///     <c>SetExpressCheckout</c>.
        /// </param>
        /// <param name="accessToken">PayPal API Access Token.</param>
        /// <param name="payPalError">
        ///     PayPal error response.
        ///     <remarks>
        ///         PayPalError is a POCO deserialised from a form-encoded HTTP
        ///         response.
        ///     </remarks>
        /// </param>
        /// <returns>Returns a <see cref="bool" /> value indicating success.</returns>
        public static bool TryParseAccessToken(string setExpressCheckoutDetails,
            out string accessToken, out PayPalError payPalError) {

            var parsedExpressCheckoutDetails =
                HttpUtility.ParseQueryString(setExpressCheckoutDetails);

            if (IsNotErrorResponse(parsedExpressCheckoutDetails)) {
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
        ///     Parses PayPal metadata returned by SetExpressCheckout and returns the
        ///     encapsulated PayPal <see cref="CustomerDetails" />.
        /// </summary>
        /// <param name="getExpressCheckoutDetails">
        ///     PayPal metadata returned by
        ///     <c>GetExpressCheckoutDetails</c>.
        /// </param>
        /// <param name="customerDetails">PayPal Customer Details.</param>
        /// <param name="payPalError">
        ///     PayPal error response.
        ///     <remarks>
        ///         PayPalError is a POCO deserialised from a form-urlencoded HTTP
        ///         response.
        ///     </remarks>
        /// </param>
        /// <returns>Returns a <see cref="bool" /> value indicating success.</returns>
        public static bool TryParseCustomerDetails(
            string getExpressCheckoutDetails,
            out CustomerDetails customerDetails,
            out PayPalError payPalError) {

            var parsedExpressCheckoutDetails =
                HttpUtility.ParseQueryString(getExpressCheckoutDetails);

            if (IsNotErrorResponse(parsedExpressCheckoutDetails)) {

                customerDetails = new CustomerDetails {
                    AccessToken = parsedExpressCheckoutDetails["TOKEN"],
                    BillingAgreementAcceptedStatus =
                        parsedExpressCheckoutDetails
                            ["BILLINGAGREEMENTACCEPTEDSTATUS"],
                    CheckoutStatus =
                        parsedExpressCheckoutDetails["CHECKOUTSTATUS"],
                    TimeStamp = parsedExpressCheckoutDetails["TIMESTAMP"],
                    CorrelationID =
                        parsedExpressCheckoutDetails["CORRELATIONID"],
                    Ack = parsedExpressCheckoutDetails["ACK"],
                    Version = parsedExpressCheckoutDetails["VERSION"],
                    Build = parsedExpressCheckoutDetails["BUILD"],
                    Email = parsedExpressCheckoutDetails["EMAIL"],
                    PayerID = parsedExpressCheckoutDetails["PAYERID"],
                    PayerStatus = parsedExpressCheckoutDetails["PAYERSTATUS"],
                    FirstName = parsedExpressCheckoutDetails["FIRSTNAME"],
                    LastName = parsedExpressCheckoutDetails["LASTNAME"],
                    CountryCode = parsedExpressCheckoutDetails["COUNTRYCODE"],
                    BillingName = parsedExpressCheckoutDetails["BILLINGNAME"],
                    Street = parsedExpressCheckoutDetails["STREET"],
                    Street2 = parsedExpressCheckoutDetails["STREET2"],
                    City = parsedExpressCheckoutDetails["CITY"],
                    State = parsedExpressCheckoutDetails["STATE"],
                    Zip = parsedExpressCheckoutDetails["ZIP"],
                    Country = parsedExpressCheckoutDetails["COUNTRY"],
                    CountryName = parsedExpressCheckoutDetails["COUNTRYNAME"],
                    AddressID = parsedExpressCheckoutDetails["ADDRESSID"],
                    AddressStatus =
                        parsedExpressCheckoutDetails["ADDRESSSTATUS"],
                    CurrencyCode = parsedExpressCheckoutDetails["CURRENCYCODE"],
                    Amt = parsedExpressCheckoutDetails["AMT"],
                    ItemAmt = parsedExpressCheckoutDetails["ITEMAMT"],
                    ShippingAmt = parsedExpressCheckoutDetails["SHIPPINGAMT"],
                    HandlingAmt = parsedExpressCheckoutDetails["HANDLINGAMT"],
                    TaxAmt = parsedExpressCheckoutDetails["TAXAMT"],
                    InsuranceAmt = parsedExpressCheckoutDetails["INSURANCEAMT"],
                    ShipDiscAmt = parsedExpressCheckoutDetails["SHIPDISCAMT"],
                    LName = parsedExpressCheckoutDetails["L_NAME0"],
                    LQuantity = parsedExpressCheckoutDetails["L_QTY0"],
                    LTaxAmt = parsedExpressCheckoutDetails["L_TAXAMT0"],
                    LAmt = parsedExpressCheckoutDetails["L_AMT0"],
                    LDescription = parsedExpressCheckoutDetails["L_DESC0"],
                    LItemWeightValue =
                        parsedExpressCheckoutDetails["L_ITEMWEIGHTVALUE0"],
                    LItemLengthValue =
                        parsedExpressCheckoutDetails["L_ITEMLENGTHVALUE0"],
                    LItemWidthValue =
                        parsedExpressCheckoutDetails["L_ITEMWIDTHVALUE0"],
                    LItemHeightValue =
                        parsedExpressCheckoutDetails["L_ITEMHEIGHTVALUE0"],
                    PaymentRequestCurrencyCode = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_CURRENCYCODE"],
                    PaymentRequestAmt =
                        parsedExpressCheckoutDetails["PAYMENTREQUEST_0_AMT"],
                    PaymentRequestItemAmt =
                        parsedExpressCheckoutDetails["PAYMENTREQUEST_0_ITEMAMT"],
                    PaymentRequestShippingAmt = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_SHIPPINGAMT"],
                    PaymentRequestHandlingAmt = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_HANDLINGAMT"],
                    PaymentRequestTaxAmt =
                        parsedExpressCheckoutDetails["PAYMENTREQUEST_0_TAXAMT"],
                    PaymentRequestInsuranceAmt = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_INSURANCEAMT"],
                    PaymentRequestShipDiscAmt = parsedExpressCheckoutDetails
                        ["PAYMENTREQUEST_0_SHIPDISCAMT"],
                    PaymentRequestTransactionID =
                        parsedExpressCheckoutDetails[
                            "PAYMENTREQUEST_0_TRANSACTIONID"],
                    PaymentRequestInsuranceOptionOffered =
                        parsedExpressCheckoutDetails[
                            "PAYMENTREQUEST_0_INSURANCEOPTIONOFFERED"],
                    PaymentRequestAddressNormalisationStatus =
                        parsedExpressCheckoutDetails[
                            "PAYMENTREQUEST_0_ADDRESSNORMALIZATIONSTATUS"],
                    LPaymentRequestName =
                        parsedExpressCheckoutDetails["L_PAYMENTREQUEST_0_NAME0"],
                    LPaymentRequestQuantity =
                        parsedExpressCheckoutDetails["L_PAYMENTREQUEST_0_QTY0"],
                    LPaymentRequestTaxAmt =
                        parsedExpressCheckoutDetails[
                            "L_PAYMENTREQUEST_0_TAXAMT0"],
                    LPaymentRequestAmt =
                        parsedExpressCheckoutDetails["L_PAYMENTREQUEST_0_AMT0"],
                    LPaymentRequestDescription =
                        parsedExpressCheckoutDetails["L_PAYMENTREQUEST_0_DESC0"],
                    LPaymentRequestItemWeightValue =
                        parsedExpressCheckoutDetails[
                            "L_PAYMENTREQUEST_0_ITEMWEIGHTVALUE0"],
                    LPaymentRequestItemLengthValue =
                        parsedExpressCheckoutDetails[
                            "L_PAYMENTREQUEST_0_ITEMLENGTHVALUE0"],
                    LPaymentRequestItemWidthValue =
                        parsedExpressCheckoutDetails[
                            "L_PAYMENTREQUEST_0_ITEMWIDTHVALUE0"],
                    LPaymentRequestItemHeightValue =
                        parsedExpressCheckoutDetails[
                            "L_PAYMENTREQUEST_0_ITEMHEIGHTVALUE0"],
                    PaymentRequestInfoTransactionID =
                        parsedExpressCheckoutDetails[
                            "PAYMENTREQUESTINFO_0_TRANSACTIONID"],
                    PaymentRequestInfoErrorCode = parsedExpressCheckoutDetails
                        ["PAYMENTREQUESTINFO_0_ERRORCODE"],
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
                    PaymentRequestShipToCountryCode =
                        parsedExpressCheckoutDetails
                            ["PAYMENTREQUEST_0_SHIPTOCOUNTRYCODE"],
                    PaymentRequestShipToCountryName =
                        parsedExpressCheckoutDetails
                            ["PAYMENTREQUEST_0_SHIPTOCOUNTRYNAME"],
                    ShipToName = parsedExpressCheckoutDetails["SHIPTONAME"],
                    ShipToStreet = parsedExpressCheckoutDetails["SHIPTOSTREET"],
                    ShipToCity = parsedExpressCheckoutDetails["SHIPTOCITY"],
                    ShipToState = parsedExpressCheckoutDetails["SHIPTOSTATE"],
                    ShipToZip = parsedExpressCheckoutDetails["SHIPTOZIP"],
                    ShipToCountryCode =
                        parsedExpressCheckoutDetails["SHIPTOCOUNTRYCODE"],
                    ShipToCountryName =
                        parsedExpressCheckoutDetails["SHIPTOCOUNTRYNAME"],
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
        ///     Determines whether or not the specified
        ///     <see cref="NameValueCollection" />
        ///     represents error metadata returned from PayPal.
        /// </summary>
        /// <param name="nvc">The <see cref="NameValueCollection" /> returned from PayPal.</param>
        /// <returns>
        ///     Returns a <see cref="bool" /> value indicating whether or not the
        ///     specified
        ///     <see cref="NameValueCollection" /> represents error metadata returned from
        ///     PayPal.
        /// </returns>
        private static bool IsNotErrorResponse(NameValueCollection nvc) {

            if (nvc == null || nvc.Count.Equals(0)) {
                throw new ArgumentException(
                    "The specified response is empty or null.");
            }
            return nvc["L_ERRORCODE0"] == null;
        }
    }
}