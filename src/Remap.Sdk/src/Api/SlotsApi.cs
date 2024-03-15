using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <see cref="Assortment"/> endpoint.
    /// </summary>
    public class SlotsApi : ApiAccessor
    {
        private const string BASE_URL = "api/remap/1.2/entity/store";
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="AssortmentApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public SlotsApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base(BASE_URL, httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the slots.
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="Slot"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<Slot>>> GetAllAsync(Guid storeId, ApiParameterBuilder query = null)
        {
            var requestContext = new RequestContext();
            var baseAddress = Client.BaseAddress is null ? new Uri(ApiDefaults.DEFAULT_BASE_PATH) : Client.BaseAddress;

            requestContext.WithPath($"{baseAddress}{BASE_URL}/{storeId}/slots");

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<EntitiesResponse<Slot>>(requestContext);
        }

        #endregion Methods
    }
}