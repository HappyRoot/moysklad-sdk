using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Тип маркировки
    /// </summary>
    public enum TrackingCodeType
    {
        /// <summary>
        /// код маркировки товара
        /// </summary>
        [EnumMember(Value = "trackingcode")]
        Trackingcode,
        /// <summary>
        /// код маркировки потребительской упаковки
        /// </summary>
        [EnumMember(Value = "consumerpack")]
        Consumerpack,
        /// <summary>
        /// код транспортной упаковки
        /// </summary>
        [EnumMember(Value = "transportpack")]
        Transportpack
    }

    /// <summary>
    /// Маркировка
    /// </summary>
    public class TrackingCode
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Cis { get; set; }
        /// <summary>
        /// Тип марки
        /// </summary>
        public TrackingCodeType Type { get; set; }
    }
}
