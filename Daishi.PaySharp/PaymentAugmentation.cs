namespace Daishi.PaySharp {
    /// <summary>
    ///     <see cref="PaymentAugmentation{TMetadata, TUnderlyingPayment}" /> is a
    ///     <a href="http://www.dofactory.com/net/decorator-design-pattern">
    ///         <c>Decorator</c>
    ///     </a>
    ///     designed to provide optional augmentation to an underlying
    ///     <see cref="Payment{TMetadata, TUnderlyingPayment}" /> at runtime.
    /// </summary>
    /// <typeparam name="TMetadata">
    ///     An object that contains metadata necessary for
    ///     augmentation.
    /// </typeparam>
    /// <typeparam name="TUnderlyingPayment">The underlying payment. to augment.</typeparam>
    public abstract class PaymentAugmentation<TMetadata, TUnderlyingPayment> :
        Payment<TMetadata, TUnderlyingPayment> {

        /// <summary>
        ///     Initialises a new instance of
        ///     <see cref="Payment{TMetadata, TUnderlyingPayment}" /> with an underlying
        ///     payment to augment.
        /// </summary>
        /// <param name="customPayment">The underlying payment to augment.</param>
        protected PaymentAugmentation(TUnderlyingPayment customPayment)
            : base(customPayment) {}
    }
}