namespace Remap.Sdk.Models
{

    /// <summary>
    /// Асинхронная задача
    /// </summary>
    public class ApiCreateAsyncTaskResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskStateUrl"></param>
        /// <param name="taskResultUrl"></param>
        public ApiCreateAsyncTaskResponse(string taskStateUrl, string taskResultUrl)
        {
            TaskStateUrl = taskStateUrl;
            TaskResultUrl = taskResultUrl;
        }

        /// <summary>
        /// URL статуса Асинхронной задачи
        /// </summary>
        public string TaskStateUrl { get; private set; }
        /// <summary>
        /// URL результата выполнения Асинхронной задачи
        /// </summary>
        public string TaskResultUrl { get; private set; }
    }
}
