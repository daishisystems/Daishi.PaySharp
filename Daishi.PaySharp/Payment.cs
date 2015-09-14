namespace Daishi.PaySharp {
    /// <summary>
    ///     Represents a
    ///     <a href="http://www.dofactory.com/net/builder-design-pattern">
    ///         <c>Builder</c>
    ///     </a>
    ///     that accepts and augments a <see cref="TUnderlyingPayment" />, to
    ///     facilitate a downstream financial operation beyond the scope of PayPal.
    ///     <remarks>
    ///         Augmenting an underlying <see cref="TUnderlyingPayment" /> might
    ///         consist of, for example, decorating <see cref="TUnderlyingPayment" />
    ///         with properties pertaining to downstream auditing, fraud-prevention, or
    ///         booking systems.
    ///     </remarks>
    /// </summary>
    /// <typeparam name="TMetadata">
    ///     An object that contains metadata necessary for
    ///     augmentation.
    /// </typeparam>
    /// <typeparam name="TUnderlyingPayment">
    ///     The underlying
    ///     <see cref="TUnderlyingPayment" />
    ///     to augment.
    /// </typeparam>
    public abstract class Payment<TMetadata, TUnderlyingPayment> {

        protected readonly TUnderlyingPayment customPayment;

        /// <summary>The underlying <see cref="TUnderlyingPayment" /> to augment.</summary>
        public TUnderlyingPayment CustomPayment => customPayment;

        /// <summary>Initialises a new instance of
        ///     <see cref="Payment{TMetadata, TUnderlyingPayment}" /> with a
        ///     <see cref="TUnderlyingPayment" /> to augment.</summary>
        /// <param name="customPayment">The <see cref="TUnderlyingPayment" /> to augment.</param>
        protected Payment(TUnderlyingPayment customPayment) {

            this.customPayment = customPayment;
        }

        /// <summary>
        ///     Augments the underlying <see cref="TUnderlyingPayment" /> to
        ///     facilitate a downstream financial transaction beyond the scope of PayPal.
        /// </summary>
        /// <param name="metadata">
        ///     Metadata necessary to augment the underlying
        ///     <see cref="TUnderlyingPayment" />.
        /// </param>
        public abstract void Augment(TMetadata metadata);
    }
}