namespace Daishi.PaySharp {
    /// <summary>Metadata necessary to facilitate successful PayPal
    ///     <b>ExpressCheckout</b> calls.</summary>
    public abstract class ExpressCheckoutPayload {
        /// <summary>Gets or sets the user.</summary>
        /// <value>The user.</value>
        public string User { get; set; }
        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        public string Password { get; set; }
        /// <summary>Gets or sets the signature.</summary>
        /// <value>The signature.</value>
        public string Signature { get; set; }
        /// <summary>Gets the method.</summary>
        /// <value>The method.</value>
        public abstract string Method { get; }
        /// <summary>Gets or sets the version.</summary>
        /// <value>The version.</value>
        public string Version { get; set; }
        /// <summary>Gets or sets the subject.</summary>
        /// <value>The subject.</value>
        public string Subject { get; set; }
    }
}