#region Includes

using System;
using System.Collections.Specialized;
using System.Web;

#endregion

namespace Daishi.PaySharp {
    /// <summary>
    ///     Provides functionality to augment
    ///     <see cref="PayPalAdapter" />. This class provides parsing mechanisms
    ///     designed to deserialise PayPal metadata returned by
    ///     <see cref="PayPalAdapter" />
    ///     methods that support the following PayPal functions:
    ///     <para>
    ///         <list type="bullet">
    ///             <item>
    ///                 <b>SetExpressCheckout</b>
    ///             </item>
    ///             <item>
    ///                 <b>GetExpressCheckoutDetails</b>
    ///             </item>
    ///             <item>
    ///                 <b>DoExpressCheckoutPayment</b>
    ///             </item>
    ///         </list>
    ///     </para>
    ///     <remarks>
    ///         PayPal exposes metadata in a form-encoded format. This class
    ///         provides a means to deserialise PayPal metadata to associated POCOs.
    ///     </remarks>
    /// </summary>
    public static class PayPalUtility {

        /// <summary>
        ///     Parses PayPal metadata returned by <b>SetExpressCheckout</b>
        ///     and returns the encapsulated PayPal <b>Access Token</b>, or a
        ///     <see cref="PayPalError" />, should an error occur.
        /// </summary>
        /// <param name="setExpressCheckoutDetails">
        ///     PayPal metadata returned by
        ///     <b>SetExpressCheckout</b>.
        /// </param>
        /// <param name="accessToken">PayPal <b>Access Token</b>.</param>
        /// <param name="payPalError">
        ///     <see cref="PayPalError" /> response.
        ///     <remarks>
        ///         <see cref="PayPalError" /> is deserialised from a form-encoded HTTP
        ///         response.
        ///     </remarks>
        /// </param>
        /// <returns>
        ///     A <see cref="bool" /> response indicating whether or not a
        ///     <b>SetExpressCheckout</b> transaction was successful.
        /// </returns>
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
        ///     Parses PayPal metadata returned by <b>GetExpressCheckoutDetails</b>
        ///     and returns the encapsulated PayPal <see cref="CustomerDetails" />, or
        ///     <see cref="PayPalError" />, should an error occur.
        /// </summary>
        /// <param name="getExpressCheckoutDetails">
        ///     PayPal metadata returned by
        ///     <b>GetExpressCheckoutDetails</b>.
        /// </param>
        /// <param name="customerDetails">
        ///     <see cref="CustomerDetails" />
        ///     returned as a result of a successful <b>GetExpressCheckoutDetails</b>
        ///     transaction.
        ///     <remarks>
        ///         <see cref="CustomerDetails" /> is deserialised from a form-encoded HTTP
        ///         response.
        ///     </remarks>
        /// </param>
        /// <param name="payPalError">
        ///     <see cref="PayPalError" /> response.
        ///     <remarks>
        ///         <see cref="PayPalError" /> is deserialised from a form-encoded HTTP
        ///         response.
        ///     </remarks>
        /// </param>
        /// <returns>
        ///     A <see cref="bool" /> response indicating whether or not a
        ///     <b>GetExpressCheckoutDetails</b> transaction was successful.
        /// </returns>
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
        ///     Parses PayPal metadata returned by <b>DoExpressCheckoutPayment</b> and
        ///     returns the encapsulated PayPal <see cref="TransactionResults" />, or
        ///     <see cref="PayPalError" />, should an error occur.
        /// </summary>
        /// <param name="doExpressCheckoutPayment">
        ///     PayPal metadata returned by
        ///     <b>DoExpressCheckoutPayment</b>.
        /// </param>
        /// <param name="transactionResults">
        ///     <see cref="TransactionResults" />
        ///     returned as a result of a successful <b>DoExpressCheckoutPayment</b>
        ///     transaction.
        ///     <remarks>
        ///         <see cref="TransactionResults" /> is deserialised from a form-encoded
        ///         HTTP response.
        ///     </remarks>
        /// </param>
        /// <param name="payPalError">
        ///     <see cref="PayPalError" /> response.
        ///     <remarks>
        ///         <see cref="PayPalError" /> is deserialised from a form-encoded HTTP
        ///         response.
        ///     </remarks>
        /// </param>
        /// <returns>
        ///     A <see cref="bool" /> response indicating whether or not a
        ///     <b>DoExpressCheckoutPayment</b> transaction was successful.
        /// </returns>
        public static bool TryParseTransactionResults(
            string doExpressCheckoutPayment,
            out TransactionResults transactionResults,
            out PayPalError payPalError) {

            var parsedDoExpressCheckoutPayment =
                HttpUtility.ParseQueryString(doExpressCheckoutPayment);

            if (IsNotErrorResponse(parsedDoExpressCheckoutPayment)) {
                transactionResults = new TransactionResults {
                    Token = parsedDoExpressCheckoutPayment["TOKEN"],
                    SuccessPageRedirectRequested =
                        parsedDoExpressCheckoutPayment[
                            "SUCCESSPAGEREDIRECTREQUESTED"],
                    Timestamp = parsedDoExpressCheckoutPayment["TIMESTAMP"],
                    CorrelationID =
                        parsedDoExpressCheckoutPayment["CORRELATIONID"],
                    Ack = parsedDoExpressCheckoutPayment["ACK"],
                    Version = parsedDoExpressCheckoutPayment["VERSION"],
                    Build = parsedDoExpressCheckoutPayment["BUILD"],
                    InsuranceOptionSelected =
                        parsedDoExpressCheckoutPayment["INSURANCEOPTIONSELECTED"
                            ],
                    ShippingOptionIsDefault =
                        parsedDoExpressCheckoutPayment["SHIPPINGOPTIONISDEFAULT"
                            ],
                    PaymentInfoTransactionID =
                        parsedDoExpressCheckoutPayment[
                            "PAYMENTINFO_0_TRANSACTIONID"],
                    PaymentInfoTransactionType =
                        parsedDoExpressCheckoutPayment[
                            "PAYMENTINFO_0_TRANSACTIONTYPE"],
                    PaymentInfoPaymentType =
                        parsedDoExpressCheckoutPayment[
                            "PAYMENTINFO_0_PAYMENTTYPE"],
                    PaymentInfoOrderTime =
                        parsedDoExpressCheckoutPayment["PAYMENTINFO_0_ORDERTIME"
                            ],
                    PaymentInfoAmt =
                        parsedDoExpressCheckoutPayment["PAYMENTINFO_0_AMT"],
                    PaymentInfoFeeAmt =
                        parsedDoExpressCheckoutPayment["PAYMENTINFO_0_FEEAMT"],
                    PaymentInfoTaxAmt =
                        parsedDoExpressCheckoutPayment["PAYMENTINFO_0_TAXAMT"],
                    PaymentInfoCurrencyCode =
                        parsedDoExpressCheckoutPayment[
                            "PAYMENTINFO_0_CURRENCYCODE"],
                    PaymentInfoPaymentStatus =
                        parsedDoExpressCheckoutPayment[
                            "PAYMENTINFO_0_PAYMENTSTATUS"],
                    PaymentInfoPendingReason =
                        parsedDoExpressCheckoutPayment[
                            "PAYMENTINFO_0_PENDINGREASON"],
                    PaymentInfoReasonCode =
                        parsedDoExpressCheckoutPayment[
                            "PAYMENTINFO_0_REASONCODE"],
                    PaymentInfoProtectionEligibility =
                        parsedDoExpressCheckoutPayment[
                            "PAYMENTINFO_0_PROTECTIONELIGIBILITY"],
                    PaymentInfoProtectionEligibilityType =
                        parsedDoExpressCheckoutPayment[
                            "PAYMENTINFO_0_PROTECTIONELIGIBILITYTYPE"],
                    PaymentInfoSecureMerchantAccountID =
                        parsedDoExpressCheckoutPayment[
                            "PAYMENTINFO_0_SECUREMERCHANTACCOUNTID"],
                    PaymentInfoErrorCode =
                        parsedDoExpressCheckoutPayment["PAYMENTINFO_0_ERRORCODE"
                            ],
                    PaymentInfoAck =
                        parsedDoExpressCheckoutPayment["PAYMENTINFO_0_ACK"]
                };

                payPalError = null;
                return true;
            }

            payPalError = new PayPalError {
                Timestamp = parsedDoExpressCheckoutPayment["TIMESTAMP"],
                CorrelationID = parsedDoExpressCheckoutPayment["CORRELATIONID"],
                Ack = parsedDoExpressCheckoutPayment["ACK"],
                ErrorCode = parsedDoExpressCheckoutPayment["L_ERRORCODE0"],
                ShortMessage = parsedDoExpressCheckoutPayment["L_SHORTMESSAGE0"],
                LongMessage = parsedDoExpressCheckoutPayment["L_LONGMESSAGE0"]
            };

            transactionResults = null;
            return false;
        }

        /// <summary>
        ///     Determines whether or not the specified
        ///     <see cref="NameValueCollection" />
        ///     represents error metadata returned from PayPal.
        ///     <remarks>
        ///         A PayPal response is considered erroneous if it contains a key
        ///         named <c>'L_ERRORCODE0'</c>.
        ///     </remarks>
        /// </summary>
        /// <param name="nvc">The <see cref="NameValueCollection" /> returned from PayPal.</param>
        /// <returns>
        ///     A <see cref="bool" /> value indicating whether or not the specified
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