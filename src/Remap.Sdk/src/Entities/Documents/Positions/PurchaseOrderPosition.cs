namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an customer order position.
    /// </summary>
    public class PurchaseOrderPosition : DocumentPosition
    {
        #region Properties

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double? Discount { get; set; }

        /// <summary>
        /// Gets or sets the shipped.
        /// </summary>
        /// <value>The shipped.</value>
        public double? Shipped { get; set; }

        /// <summary>
        /// Gets or sets the vat.
        /// </summary>
        /// <value>The vat.</value>
        public int? Vat { get; set; }
        /// <summary>
        /// Gets or sets the vatEnabled.
        /// </summary>
        public bool VatEnabled { get; set; }

        /// <summary>
        /// Gets or sets the inTransit.
        /// </summary>
        public double? InTransit { get; set; }

        #endregion Properties
    }
}