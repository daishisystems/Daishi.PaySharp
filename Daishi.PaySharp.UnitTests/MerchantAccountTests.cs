#region Includes

using NUnit.Framework;

#endregion

namespace Daishi.PaySharp.UnitTests {
    [TestFixture]
    internal class MerchantAccountTests {

        [Test]
        public void MerchantAccountIDIsAccessibleByCurrencyCode() {

            var merchantAccounts = new MerchantAccounts();
            merchantAccounts.Load("GBP", "CNWKRL2JZLMPL");

            var merchantAccountID = merchantAccounts.GetByCurrencyCode("GBP");
            Assert.AreEqual("CNWKRL2JZLMPL", merchantAccountID);
        }

        [Test]
        public void InvalidCurrencyCodeResultsInEmptyMerchantAccountID() {

            var merchantAccounts = new MerchantAccounts();
            merchantAccounts.Load("GBP", "CNWKRL2JZLMPL");

            var merchantAccountID = merchantAccounts.GetByCurrencyCode("INVALID");
            Assert.AreEqual(string.Empty, merchantAccountID);
        }
    }
}