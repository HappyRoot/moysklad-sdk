using Newtonsoft.Json;
using System.ComponentModel;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an supply.
    /// </summary>
    public class Inventory : Document
    {
        #region Properties
        /// <summary>
        /// Gets or sets the attribute values.
        /// </summary>
        /// <value>The attribute values.</value>
        public AttributeValue[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets the Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        /// <value>The positions.</value>
        [DefaultValue("{}")]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedEntities<InventoryPosition> Positions { get; set; } = new PagedEntities<InventoryPosition>();

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public State State { get; set; }

        /// <summary>
        /// Gets or sets the store.
        /// </summary>
        /// <value>The store.</value>
        public Store Store { get; set; }

        #endregion Properties
    }
}