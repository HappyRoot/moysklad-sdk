using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an unit of measure.
    /// </summary>
    public class Slot : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the external code.
        /// </summary>
        /// <value>The external code.</value>
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the external barcode.
        /// </summary>
        /// <value>The external code.</value>
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets the Zone.
        /// </summary>
        /// <value>The external code.</value>
        public Zone Zone { get; set; }

        #endregion Properties
    }
}