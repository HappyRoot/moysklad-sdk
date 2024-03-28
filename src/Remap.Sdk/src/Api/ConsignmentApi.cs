using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <see cref="Consignment"/> endpoint.
    /// </summary>
    public class ConsignmentApi : EntityApiAccessor<Consignment, ApiParameterBuilder, ApiParameterBuilder<ConsignmentQuery>>
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ConsignmentApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ConsignmentApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/consignment", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        #endregion Methods
    }
}