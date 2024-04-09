
using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Async task result
    /// </summary>
    public class AsyncTask: IHasMeta<Meta>
    {
        /// <summary>
        /// Gets the metadata about entity.
        /// </summary>
        /// <value>The metadata about entity.</value>
        public Meta Meta {  get; set; }

        /// <summary>
        /// Статус выполнения Асинхронной задачи
        /// </summary>
        public AsyncTaskState State { get; set; }

        /// <summary>
        /// URL запроса, по которому создана Асинхронная задача
        /// </summary>
        public string Request { get; set; }
        /// <summary>
        /// Ссылка на результат выполнения задачи. Содержится в ответе, если поле state имеет значение DONE
        /// </summary>
        public string ResultUrl { get; set; }

        /// <summary>
        /// Дата, после которой результат выполнения задачи станет недоступен. Содержится в ответе, если поле state имеет значение
        /// </summary>
        public DateTime deletionDate { get; set; }
    }
}
