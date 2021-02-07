using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an service.
    /// </summary>
    public class Service : Goods
    {
        #region Properties

        /// <summary>
        /// Gets or sets the payment item type.
        /// </summary>
        /// <value>The payment item type.</value>
        [JsonProperty("paymentItemType")]
        public ServicePaymentItemType? PaymentItemType { get; set; }
            
        #endregion
    }
}