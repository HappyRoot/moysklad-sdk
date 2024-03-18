using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Отчет остатков в ячейках
    /// </summary>
    public class ReportStockBySlot
    {
        /// <summary>
        /// Остаток
        /// </summary>
        public double Stock { get; set; }

        /// <summary>
        /// Идентификатор ячейки склада
        /// </summary>
        public Guid? SlotId { get; set; }

        /// <summary>
        /// Идентификатор склада
        /// </summary>
        public Guid StoreId { get; set; }

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public Guid AssortmentId { get; set; }
    }
}
