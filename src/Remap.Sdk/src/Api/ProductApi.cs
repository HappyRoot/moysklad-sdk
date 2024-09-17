using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class ProductApi : EntityApiAccessor<Product, ApiParameterBuilder<ProductQuery>, ApiParameterBuilder<ProductQuery>>
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the image endpoint.
        /// </summary>
        public virtual ImageApi Images { get; }

        /// <summary>
        /// Gets the API to interact with the metadata endpoint.
        /// </summary>
        public virtual MetadataApi<ProductMetadata, ProductMetadataQuery> Metadata { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ProductApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ProductApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/product", httpClient, credentials)
        {
            Metadata = new MetadataApi<ProductMetadata, ProductMetadataQuery>(Path, httpClient, credentials);
            Images = new ImageApi(Path, httpClient, credentials);
        }


        /// <summary>
        /// Uploads an array of products in MoySklad
        /// </summary>
        /// <param name="entities">Array of products which should be uploaded</param>
        public virtual Task<ApiResponse> CreateProductsAsync(Product[] entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var requestContext = new RequestContext(HttpMethod.Post)
                .WithBody(entities);

            return CallAsync(requestContext);
        }
        #endregion Ctor
    }
}