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

            StringAssert.AreEqualIgnoringCase("EC-080143372V8487112", parsed.Token);
            StringAssert.AreEqualIgnoringCase("0", parsed.BillingAgreementAcceptedStatus);
        }
    }
}