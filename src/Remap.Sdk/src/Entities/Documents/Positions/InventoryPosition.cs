namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an inventory position.
    /// </summary>
    public class InventoryPosition : DocumentPosition
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CalculatedQuantity.
        /// </summary>
        /// <value>The discount.</value>
        public double CalculatedQuantity { get; set; }

        /// <summary>
        /// Gets or sets the CorrectionAmount.
        /// </summary>
        /// <value>The discount.</value>
        public double CorrectionAmount { get; set; }

        /// <summary>
        /// Gets or sets the CorrectionSum.
        /// </summary>
        /// <value>The discount.</value>
        public double CorrectionSum { get; set; }
        #endregion Properties
    }
}