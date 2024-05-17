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
        Trackingcode,
        /// <summary>
        /// код маркировки потребительской упаковки
        /// </summary>
        Consumerpack,
        /// <summary>
        /// код транспортной упаковки
        /// </summary>
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
