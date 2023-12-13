using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an store.
    /// </summary>
    public class Store : MetaEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The code.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the addressFull.
        /// </summary>
        /// <value>The code.</value>
        public Address AddressFull { get; set; }

        /// <summary>
        /// Gets or sets the archived.
        /// </summary>
        /// <value>The code.</value>
        public bool Archived { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// </summary>
        /// <value>The external code.</value>
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the external description.
        /// </summary>
        /// <value>The external code.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the external group.
        /// </summary>
        /// <value>The external code.</value>
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        [DefaultValue("{}")]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Employee Owner { get; set; } = new Employee();

        /// <summary>
        /// Gets or sets the external pathName.
        /// </summary>
        /// <value>The external code.</value>
        public string PathName { get; set; }

        /// <summary>
        /// Gets or sets the Shared.
        /// </summary>
        /// <value>The external code.</value>
        public bool Shared { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets the Slots.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        public PagedEntities<Slot> Slots { get; set; }

        /// <summary>
        /// Gets or sets the Slots.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        public PagedEntities<Zone> Zones { get; set; }

        #endregion
    }
}