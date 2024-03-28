using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a consignment query.
    /// </summary>
    public class ConsignmentQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the abstract product.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The abstract product.</value>
        [AllowExpand]
        [Parameter("assortment")]
        public AbstractProduct Assortment { get; set; }

        #endregion Properties
    }
}