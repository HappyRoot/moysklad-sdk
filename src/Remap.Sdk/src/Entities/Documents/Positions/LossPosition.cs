﻿namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an loss position.
    /// </summary>
    public class LossPosition : DocumentPosition
    {
        // todo
        //private List<String> things;

        #region Properties

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>The reason.</value>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the Slot
        /// </summary>
        public Slot Slot { get; set; }

        #endregion Properties
    }
}