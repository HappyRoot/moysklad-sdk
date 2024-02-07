namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an move position.
    /// </summary>
    public class MovePosition : DocumentPosition
    {
        // todo
        //private List<String> things;

        #region Properties

        /// <summary>
        /// Gets or sets the overhead.
        /// </summary>
        /// <value>The overhead.</value>
        public long? Overhead { get; set; }

        /// <summary>
        /// Gets or sets the Source Slot.
        /// </summary>
        public Slot SourceSlot { get; set; }

        /// <summary>
        /// Gets or sets the Target Slot.
        /// </summary>
        public Slot TargetSlot { get; set; }
        #endregion Properties
    }
}