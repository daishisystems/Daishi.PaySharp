#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.PaySharp {
    /// <summary>
    ///     <see cref="MerchantAccounts" /> provides a means of managing PayPal
    ///     Merchant Accounts, by loading Merchant Account metadata from external
    ///     sources, such as *.config files, and by providing access to underlying
    ///     Merchant Account metadata through key-value lookup.
    /// </summary>
    public class MerchantAccounts {
        private readonly Dictionary<string, string> _merchantAccounts =
            new Dictionary<string, string>();

        /// <summary>
        ///     Loads Merchant Account metadata.
        ///     <remarks>
        ///         Metadata is internally stored in key-value format to facilitate
        ///         fast lookup.
        ///     </remarks>
        /// </summary>
        /// <param name="currencyCode">
        ///     The currency-code pertaining to the desired Merchant
        ///     Account.
        /// </param>
        /// <param name="merchantAccountID">Merchant Account Identifier.</param>
        public void Load(string currencyCode, string merchantAccountID) {

            _merchantAccounts.Add(currencyCode, merchantAccountID);
        }

        /// <summary>
        ///     Returns a Merchant Account ID pertaining to the specified
        ///     currency-code.
        ///     <remarks>Returns an empty string if the Merchant Account cannot be found.</remarks>
        /// </summary>
        /// <param name="currencyCode">
        ///     The currency-code pertaining to the desired Merchant
        ///     Account.
        /// </param>
        /// <returns>
        ///     A Merchant Account ID pertaining to <c>currencyCode</c>, if
        ///     <c>currencyCode</c> is valid. Otherwise, an empty <see cref="string" />.
        /// </returns>
        public string GetByCurrencyCode(string currencyCode) {

            string merchantAccountID;
            var merchantAccountExists =
                _merchantAccounts.TryGetValue(currencyCode,
                    out merchantAccountID);

            return !merchantAccountExists ? string.Empty : merchantAccountID;
        }
    }
}