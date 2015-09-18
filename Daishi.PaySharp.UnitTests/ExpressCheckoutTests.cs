#region Includes

using NUnit.Framework;

#endregion

namespace Daishi.PaySharp.UnitTests {

    [TestFixture]
    internal class ExpressCheckoutTests {
        #region Passing Tests

        [Test]
        public void PayPalUtilityParsesSetExpressCheckout() {

            string accesstoken;
            PayPalError error;

            var methodCompletedOK = PayPalUtility.TryParseAccessToken(
                Resource.SetExpressCheckout, out accesstoken, out error);

            Assert.IsTrue(methodCompletedOK);
            Assert.IsNull(error);

            Assert.AreEqual("EC-8JV062580S765292N", accesstoken);
        }

        [Test]
        public void PayPalUtilityParsesGetExpressCheckoutDetails() {

            CustomerDetails customerDetails;
            PayPalError error;

            var methodCompletedOK = PayPalUtility.TryParseCustomerDetails(
                Resource.CustomerDetails, out customerDetails, out error);

            Assert.IsTrue(methodCompletedOK);
            Assert.IsNull(error);

            Assert.AreEqual("EC-080143372V8487112", customerDetails.AccessToken);
            Assert.AreEqual("0", customerDetails.BillingAgreementAcceptedStatus);
            Assert.AreEqual("PaymentActionNotInitiated",
                customerDetails.CheckoutStatus);
            Assert.AreEqual("2015-08-31T11:07:13Z", customerDetails.TimeStamp);
            Assert.AreEqual("cdb26170126a4", customerDetails.CorrelationID);
            Assert.AreEqual("Success", customerDetails.Ack);
            Assert.AreEqual("93", customerDetails.Version);
            Assert.AreEqual("000000", customerDetails.Build);
            Assert.AreEqual("daishi.systems-buyer@gmail.com",
                customerDetails.Email);
            Assert.AreEqual("UPMHHXJ72R4EG", customerDetails.PayerID);
            Assert.AreEqual("verified", customerDetails.PayerStatus);
            Assert.AreEqual("test", customerDetails.FirstName);
            Assert.AreEqual("buyer", customerDetails.LastName);
            Assert.AreEqual("US", customerDetails.CountryCode);
            Assert.AreEqual("test buyer", customerDetails.ShipToName);
            Assert.AreEqual("1 Main St", customerDetails.ShipToStreet);
            Assert.AreEqual("San Jose", customerDetails.ShipToCity);
            Assert.AreEqual("CA", customerDetails.ShipToState);
            Assert.AreEqual("95131", customerDetails.ShipToZip);
            Assert.AreEqual("US", customerDetails.ShipToCountryCode);
            Assert.AreEqual("United States", customerDetails.ShipToCountryName);
            Assert.AreEqual("Confirmed", customerDetails.AddressStatus);
            Assert.AreEqual("USD", customerDetails.CurrencyCode);
            Assert.AreEqual("19.00", customerDetails.Amt);
            Assert.AreEqual("0.00", customerDetails.ShippingAmt);
            Assert.AreEqual("0.00", customerDetails.HandlingAmt);
            Assert.AreEqual("0.00", customerDetails.TaxAmt);
            Assert.AreEqual("0.00", customerDetails.InsuranceAmt);
            Assert.AreEqual("USD", customerDetails.PaymentRequestCurrencyCode);
            Assert.AreEqual("19.00", customerDetails.PaymentRequestAmt);
            Assert.AreEqual("0.00", customerDetails.PaymentRequestShippingAmt);
            Assert.AreEqual("0.00", customerDetails.PaymentRequestHandlingAmt);
            Assert.AreEqual("0.00", customerDetails.PaymentRequestTaxAmt);
            Assert.AreEqual("0.00", customerDetails.PaymentRequestInsuranceAmt);
            Assert.AreEqual("0.00", customerDetails.PaymentRequestShipDiscAmt);
            Assert.AreEqual("false",
                customerDetails.PaymentRequestInsuranceOptionOffered);
            Assert.AreEqual("test buyer",
                customerDetails.PaymentRequestShipToName);
            Assert.AreEqual("1 Main St",
                customerDetails.PaymentRequestShipToStreet);
            Assert.AreEqual("San Jose", customerDetails.PaymentRequestShipToCity);
            Assert.AreEqual("CA", customerDetails.PaymentRequestShipToState);
            Assert.AreEqual("95131", customerDetails.PaymentRequestShipToZip);
            Assert.AreEqual("US",
                customerDetails.PaymentRequestShipToCountryCode);
            Assert.AreEqual("United States",
                customerDetails.PaymentRequestShipToCountryName);
            Assert.AreEqual("Confirmed", customerDetails.AddressStatus);
            Assert.AreEqual("0", customerDetails.PaymentRequestInfoErrorCode);
        }

        [Test]
        public void PayPalUtilityParsesDoExpressCheckoutPayment() {

            TransactionResults transactionResults;
            PayPalError error;

            var methodCompletedOK = PayPalUtility.TryParseTransactionResults(
                Resource.DoExpressCheckoutPayment, out transactionResults,
                out error);

            Assert.IsTrue(methodCompletedOK);
            Assert.IsNull(error);

            Assert.AreEqual("EC-5ED70123NJ325433P", transactionResults.Token);
            Assert.AreEqual("false",
                transactionResults.SuccessPageRedirectRequested);
            Assert.AreEqual("2015-09-17T11:32:14Z", transactionResults.Timestamp);
            Assert.AreEqual("da59801663304", transactionResults.CorrelationID);
            Assert.AreEqual("Success", transactionResults.Ack);
            Assert.AreEqual("108.0", transactionResults.Version);
            Assert.AreEqual("000000", transactionResults.Build);
            Assert.AreEqual("false", transactionResults.InsuranceOptionSelected);
            Assert.AreEqual("false", transactionResults.ShippingOptionIsDefault);
            Assert.AreEqual("6YX65164PA326324T",
                transactionResults.PaymentInfoTransactionID);
            Assert.AreEqual("expresscheckout",
                transactionResults.PaymentInfoTransactionType);
            Assert.AreEqual("instant", transactionResults.PaymentInfoPaymentType);
            Assert.AreEqual("2015-09-17T11:32:14Z",
                transactionResults.PaymentInfoOrderTime);
            Assert.AreEqual("19.95", transactionResults.PaymentInfoAmt);
            Assert.AreEqual("0.93", transactionResults.PaymentInfoFeeAmt);
            Assert.AreEqual("0.00", transactionResults.PaymentInfoTaxAmt);
            Assert.AreEqual("EUR", transactionResults.PaymentInfoCurrencyCode);
            Assert.AreEqual("Completed",
                transactionResults.PaymentInfoPaymentStatus);
            Assert.AreEqual("None", transactionResults.PaymentInfoPendingReason);
            Assert.AreEqual("None", transactionResults.PaymentInfoReasonCode);
            Assert.AreEqual("Ineligible",
                transactionResults.PaymentInfoProtectionEligibility);
            Assert.AreEqual("None",
                transactionResults.PaymentInfoProtectionEligibilityType);
            Assert.AreEqual("NJ9W2NABYSKZ6",
                transactionResults.PaymentInfoSecureMerchantAccountID);
            Assert.AreEqual("0", transactionResults.PaymentInfoErrorCode);
            Assert.AreEqual("Success", transactionResults.PaymentInfoAck);
        }

        #endregion

        #region Failing Tests

        [Test]
        public void PayPalUtilityParsesErrors() {

            string accesstoken;
            PayPalError error;

            var methodCompletedOK = PayPalUtility.TryParseAccessToken(
                Resource.ErrorResponse, out accesstoken, out error);

            Assert.IsFalse(methodCompletedOK);
            Assert.IsNull(accesstoken);

            Assert.AreEqual("2015-09-02T16:19:49Z", error.Timestamp);
            Assert.AreEqual("d594df3b6b673", error.CorrelationID);
            Assert.AreEqual("Failure", error.Ack);
            Assert.AreEqual("10002", error.ErrorCode);
            Assert.AreEqual("Security error", error.ShortMessage);
            Assert.AreEqual("Security header is not valid", error.LongMessage);
            Assert.AreEqual("Error", error.SeverityCode);
            Assert.AreEqual("000000", error.Build);
            Assert.AreEqual("78", error.Version);
        }

        #endregion
    }
}