namespace Daishi.PaySharp {
    /// <summary>
    ///     Represents a
    ///     <a href="http://www.dofactory.com/net/builder-design-pattern">
    ///         <c>Builder</c>
    ///     </a>
    ///     that accepts and augments an underlying payment, to facilitate a downstream
    ///     financial operation beyond the scope of PayPal.
    ///     <remarks>
    ///         Augmenting an underlying payment might consist of, for example,
    ///         decorating an underlying payment with properties pertaining to
    ///         downstream auditing, fraud-prevention, or booking systems.
    ///     </remarks>
    /// </summary>
    /// <typeparam name="TMetadata">
    ///     An object that contains metadata necessary for
    ///     augmentation.
    /// </typeparam>
    /// <typeparam name="TUnderlyingPayment">The underlying payment to augment.</typeparam>
    public abstract class Payment<TMetadata, TUnderlyingPayment> {

        /// <summary>The underlying payment.</summary>
        protected readonly TUnderlyingPayment underlyingPayment;

        /// <summary>The underlying payment to augment.</summary>
        public TUnderlyingPayment CustomPayment => underlyingPayment;

        /// <summary>
        ///     Initialises a new instance of
        ///     <see cref="Payment{TMetadata, TUnderlyingPayment}" /> with an underlying
        ///     payment to augment.
        /// </summary>
        /// <param name="customPayment">The underlying payment to augment.</param>
        protected Payment(TUnderlyingPayment customPayment) {

            this.underlyingPayment = customPayment;
        }

        /// <summary>
        ///     Augments the underlying payment to facilitate a downstream financial
        ///     transaction beyond the scope of PayPal.
        /// </summary>
        /// <param name="metadata">Metadata necessary to augment the underlying payment.</param>
        public abstract void Augment(TMetadata metadata);
    }
}