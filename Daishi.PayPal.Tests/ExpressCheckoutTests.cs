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
            StringAssert.AreEqualIgnoringCase("0", parsed.BillingAgreementAcceptedStatus);
            StringAssert.AreEqualIgnoringCase("PaymentActionNotInitiated", parsed.CheckoutStatus);
            StringAssert.AreEqualIgnoringCase("2015-08-31T11:07:13Z", parsed.TimeStamp);
            StringAssert.AreEqualIgnoringCase("cdb26170126a4", parsed.CorrelationID);
            StringAssert.AreEqualIgnoringCase("Success", parsed.Ack);
            StringAssert.AreEqualIgnoringCase("93", parsed.Version);
            StringAssert.AreEqualIgnoringCase("000000", parsed.Build);
            StringAssert.AreEqualIgnoringCase("daishi.systems-buyer@gmail.com", parsed.Email);
            StringAssert.AreEqualIgnoringCase("UPMHHXJ72R4EG", parsed.PayerID);
            StringAssert.AreEqualIgnoringCase("verified", parsed.PayerStatus);
            StringAssert.AreEqualIgnoringCase("test", parsed.FirstName);
            StringAssert.AreEqualIgnoringCase("buyer", parsed.LastName);
            StringAssert.AreEqualIgnoringCase("US", parsed.CountryCode);
            StringAssert.AreEqualIgnoringCase("test buyer", parsed.ShipToName);
            StringAssert.AreEqualIgnoringCase("1 Main St", parsed.ShipToStreet);
            StringAssert.AreEqualIgnoringCase("San Jose", parsed.ShipToCity);
            StringAssert.AreEqualIgnoringCase("CA", parsed.ShipToState);
            StringAssert.AreEqualIgnoringCase("95131", parsed.ShipToZip);
            StringAssert.AreEqualIgnoringCase("US", parsed.ShipToCountryCode);
            StringAssert.AreEqualIgnoringCase("United States", parsed.ShipToCountryName);
            StringAssert.AreEqualIgnoringCase("Confirmed", parsed.AddressStatus);
            StringAssert.AreEqualIgnoringCase("USD", parsed.CurrencyCode);
            StringAssert.AreEqualIgnoringCase("19.00", parsed.Amt);
            StringAssert.AreEqualIgnoringCase("0.00", parsed.ShippingAmt);
            StringAssert.AreEqualIgnoringCase("0.00", parsed.HandlingAmt);
            StringAssert.AreEqualIgnoringCase("0.00", parsed.TaxAmt);
            StringAssert.AreEqualIgnoringCase("0.00", parsed.InsuranceAmt);
            StringAssert.AreEqualIgnoringCase("USD", parsed.PaymentRequestCurrencyCode);
            StringAssert.AreEqualIgnoringCase("19.00", parsed.PaymentRequestAmt);
            StringAssert.AreEqualIgnoringCase("0.00", parsed.PaymentRequestShippingAmt);
            StringAssert.AreEqualIgnoringCase("0.00", parsed.PaymentRequestHandlingAmt);
            StringAssert.AreEqualIgnoringCase("0.00", parsed.PaymentRequestTaxAmt);
            StringAssert.AreEqualIgnoringCase("0.00", parsed.PaymentRequestInsuranceAmt);
            StringAssert.AreEqualIgnoringCase("0.00", parsed.PaymentRequestShipDiscAmt);
            StringAssert.AreEqualIgnoringCase("false", parsed.PaymentRequestInsuranceOptionOffered);
            StringAssert.AreEqualIgnoringCase("test buyer", parsed.PaymentRequestShipToName);
            StringAssert.AreEqualIgnoringCase("1 Main St", parsed.PaymentRequestShipToStreet);
            StringAssert.AreEqualIgnoringCase("San Jose", parsed.PaymentRequestShipToCity);
            StringAssert.AreEqualIgnoringCase("CA", parsed.PaymentRequestShipToState);

        }
    }
}