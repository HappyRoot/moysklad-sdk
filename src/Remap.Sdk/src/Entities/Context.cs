using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an context about employee.
    /// </summary>
    public class Context
    {
        #region Properties

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        [JsonProperty("employee")]
        public Employee Employee { get; set; }
            
        #endregion
    }
}