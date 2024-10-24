using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using Remap.Sdk.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <see cref="Assortment"/> endpoint.
    /// </summary>
    public class AssortmentApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="AssortmentApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public AssortmentApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/assortment", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the assortment.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="Assortment"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<Assortment>>> GetAllAsync(AssortmentApiParameterBuilder query = null)
        {
            var requestContext = new RequestContext();

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<EntitiesResponse<Assortment>>(requestContext);
        }

        /// <summary>
        /// Get async task result
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public virtual Task<ApiResponse<EntitiesResponse<Assortment>>> GetTaskResultAsync(string url)
        {
            var requestContext = new RequestContext();
            requestContext.WithPath(url);

            return CallAsync<EntitiesResponse<Assortment>>(requestContext);
        }

        /// <summary>
        /// ��������� ������ ���������� ������
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public virtual async Task<AsyncTask> GetTaskStateAsync(string url)
        {            
            var requestContext = new RequestContext();
            requestContext.WithPath(url);

            var httpResponse = await InternalCallAsync(requestContext);
            var model = (AsyncTask)await DeserializeAsync(httpResponse, typeof(AsyncTask));
            return model;
        }

        /// <summary>
        /// ��������� ������ � ����������� ������
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        public virtual async Task<ApiCreateAsyncTaskResponse> CreateTaskAsync(AssortmentApiParameterBuilder query = null)
        {
            const string locationHeader = "location";
            const string contentLocationHeader = "content-location";

            var requestContext = new RequestContext();

            if (query == null)
            {
                query = new AssortmentApiParameterBuilder();
            }
            
            query
                .Async(true);

            requestContext
                .WithQuery(query.Build());

            var httpResponse = await InternalCallAsync(requestContext);
            var location = httpResponse.Headers
                .FirstOrDefault(x => x.Key.ToLower() == locationHeader)
                .Value
                ?.FirstOrDefault();

            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ApiException(500, $"������ ������� � ����������� ������: ��������� '{locationHeader}' �� ������.");
            }

            var state = httpResponse.Content.Headers
                .FirstOrDefault(x => x.Key.ToLower() == contentLocationHeader)
                .Value
                ?.FirstOrDefault();

            if (string.IsNullOrWhiteSpace(state))
            {
                throw new ApiException(500, $"������ ������� � ����������� ������: ��������� '{contentLocationHeader}' �� ������.");
            }

            return new ApiCreateAsyncTaskResponse(taskStateUrl: state, taskResultUrl: location);
        }

        #endregion Methods
    }
}