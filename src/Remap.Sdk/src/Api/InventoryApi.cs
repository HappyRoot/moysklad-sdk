using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class InventoryApi : DocumentApiAccessor<Inventory, ApiParameterBuilder<InventoryQuery>, ApiParameterBuilder<InventoryQuery>>
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the metadata endpoint.
        /// </summary>
        public virtual MetadataApi<DocumentMetadata, DocumentMetadataQuery> Metadata { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="InventoryApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public InventoryApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/inventory", httpClient, credentials)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, httpClient, credentials);
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Пересчитать расчетный остаток в позициях документа "Инвентаризация". В результате, значение поля calculatedQuantity у позиций инвентаризации изменится и документ будет пересохранен
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <returns></returns>
        public virtual async Task RecalculatedQuantity(Guid inventoryId)
        {
            var requestContext = new RequestContext($"api/remap/1.2/rpc/inventory/{inventoryId}/recalcCalculatedQuantity", HttpMethod.Put);
            await CallAsync(requestContext).ConfigureAwait(false);
        }

        #endregion
    }
}