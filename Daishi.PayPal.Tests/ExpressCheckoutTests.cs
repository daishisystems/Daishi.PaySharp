#region Includes

using System.Configuration;
using System.Text;
using NUnit.Framework;

#endregion

namespace Daishi.PayPal.Tests {

    [TestFixture]
    internal class ExpressCheckoutTests {

        private string _user, _password, _signature, _setExpressCheckoutURI;

        [TestFixtureSetUp]
        public void Init() {

            _user = ConfigurationManager.AppSettings["User"];
            _password = ConfigurationManager.AppSettings["Password"];
            _signature = ConfigurationManager.AppSettings["Signature"];
            _setExpressCheckoutURI = ConfigurationManager.AppSettings["SetExpressCheckoutURI"];
        }

        [Test]
        public void PayPalAdapterReturnsExpressCheckoutToken() {

            var payPalAdapter = new PayPalAdapter();

            var token = payPalAdapter.SetExpressCheckout(new SetExpressCheckoutPayload {
                User = _user,
                Password = _password,
                Signature = _signature,
                Method = "SetExpressCheckout",
                Version = "78",
                Action = "SALE",
                Amount = "19",
                CurrencyCode = "USD",
                CancelUrl = "",
                ReturnUrl = ""
            }, Encoding.UTF8, _setExpressCheckoutURI);

            Assert.IsNotNullOrEmpty(token);
        }

        [Test]
        public void PayPalAdapterParsesGetExpressCheckoutDetails() {

            var customerDetails = Resource.CustomerDetails;
            var payPalAdapter = new PayPalAdapter();

            var parsed = payPalAdapter.ParseCustomerDetails(customerDetails);

            Assert.AreEqual("EC-080143372V8487112", parsed.Token);
            Assert.AreEqual("0", parsed.BillingAgreementAcceptedStatus);
            Assert.AreEqual("PaymentActionNotInitiated", parsed.CheckoutStatus);
            Assert.AreEqual("2015-08-31T11:07:13Z", parsed.TimeStamp);
            Assert.AreEqual("cdb26170126a4", parsed.CorrelationID);
            Assert.AreEqual("Success", parsed.Ack);
            Assert.AreEqual("93", parsed.Version);
            Assert.AreEqual("000000", parsed.Build);
            Assert.AreEqual("daishi.systems-buyer@gmail.com", parsed.Email);
            Assert.AreEqual("UPMHHXJ72R4EG", parsed.PayerID);
            Assert.AreEqual("verified", parsed.PayerStatus);
            Assert.AreEqual("test", parsed.FirstName);
            Assert.AreEqual("buyer", parsed.LastName);
            Assert.AreEqual("US", parsed.CountryCode);
            Assert.AreEqual("test buyer", parsed.ShipToName);
            Assert.AreEqual("1 Main St", parsed.ShipToStreet);
            Assert.AreEqual("San Jose", parsed.ShipToCity);
            Assert.AreEqual("CA", parsed.ShipToState);
            Assert.AreEqual("95131", parsed.ShipToZip);
            Assert.AreEqual("US", parsed.ShipToCountryCode);
            Assert.AreEqual("United States", parsed.ShipToCountryName);
            Assert.AreEqual("Confirmed", parsed.AddressStatus);
            Assert.AreEqual("USD", parsed.CurrencyCode);
            Assert.AreEqual("19.00", parsed.Amt);
            Assert.AreEqual("0.00", parsed.ShippingAmt);
            Assert.AreEqual("0.00", parsed.HandlingAmt);
            Assert.AreEqual("0.00", parsed.TaxAmt);
            Assert.AreEqual("0.00", parsed.InsuranceAmt);
            Assert.AreEqual("USD", parsed.PaymentRequestCurrencyCode);
            Assert.AreEqual("19.00", parsed.PaymentRequestAmt);
            Assert.AreEqual("0.00", parsed.PaymentRequestShippingAmt);
            Assert.AreEqual("0.00", parsed.PaymentRequestHandlingAmt);
            Assert.AreEqual("0.00", parsed.PaymentRequestTaxAmt);
            Assert.AreEqual("0.00", parsed.PaymentRequestInsuranceAmt);
            Assert.AreEqual("0.00", parsed.PaymentRequestShipDiscAmt);
            Assert.AreEqual("false", parsed.PaymentRequestInsuranceOptionOffered);
            Assert.AreEqual("test buyer", parsed.PaymentRequestShipToName);
            Assert.AreEqual("1 Main St", parsed.PaymentRequestShipToStreet);
            Assert.AreEqual("San Jose", parsed.PaymentRequestShipToCity);
            Assert.AreEqual("CA", parsed.PaymentRequestShipToState);
            Assert.AreEqual("95131", parsed.PaymentRequestShipToZip);
            Assert.AreEqual("US", parsed.PaymentRequestShipToCountryCode);
            Assert.AreEqual("United States", parsed.PaymentRequestShipToCountryName);
            Assert.AreEqual("Confirmed", parsed.PaymentRequestAddressStatus);
            Assert.AreEqual("0", parsed.PaymentRequestInfoErrorCode);
        }
    }
}