using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Статус выполнения Асинхронной задачи
    /// </summary>
    public enum AsyncTaskState
    {
        /// <summary>
        /// Задача находится в очереди
        /// </summary>
        [EnumMember(Value = "PENDING")]
        PENDING,
        /// <summary>
        /// Задача находится в обработке, результат еще не готов
        /// </summary>
        [EnumMember(Value = "PROCESSING")]
        PROCESSING,
        /// <summary>
        /// Задача выполнена успешно
        /// </summary>
        [EnumMember(Value = "DONE")]
        DONE,
        /// <summary>
        /// Задача не была выполнена в результате внутренней ошибки. В этом случае нужно попробовать запустить задачу заново
        /// </summary>
        [EnumMember(Value = "ERROR")]
        ERROR,
        /// <summary>
        /// Задача была отменена
        /// </summary>
        [EnumMember(Value = "CANCEL")]
        CANCEL,
        /// <summary>
        /// Задача была завершена с ошибкой апи
        /// </summary>
        [EnumMember(Value = "API_ERROR")]
        API_ERROR
    }
}
