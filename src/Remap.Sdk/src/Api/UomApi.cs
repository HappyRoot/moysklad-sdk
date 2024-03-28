using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <see cref="Uom"/> endpoint.
    /// </summary>
    public class UomApi : EntityApiAccessor<Uom, ApiParameterBuilder, ApiParameterBuilder<UomQuery>>
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="UomApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public UomApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/uom", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        #endregion Methods
    }
}