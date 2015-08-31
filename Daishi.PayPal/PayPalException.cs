#region Includes

using System;

#endregion

namespace Daishi.PayPal {
    public class PayPalException : Exception {
        public PayPalException(string message, Exception innerException) : base(
            message, innerException) {}
    }
}