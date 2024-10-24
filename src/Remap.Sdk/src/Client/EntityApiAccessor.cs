﻿using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a API to interact with the <typeparamref name="TEntity"/> endpoint.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityBuilder"></typeparam>
    /// <typeparam name="TEntitiesBuilder"></typeparam>
    public abstract class DocumentApiAccessor<TEntity, TEntityBuilder, TEntitiesBuilder> : EntityApiAccessor<TEntity, TEntityBuilder, TEntitiesBuilder>
        where TEntity : Document
        where TEntityBuilder : ApiParameterBuilder
        where TEntitiesBuilder : ApiParameterBuilder
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="relativePath"></param>
        /// <param name="httpClient"></param>
        /// <param name="credentials"></param>
        protected DocumentApiAccessor(string relativePath, HttpClient httpClient, MoySkladCredentials credentials = null) : base(relativePath, httpClient, credentials)
        {
        }

        /// <summary>
        /// Add positions to document specified by id.
        /// </summary>
        /// <param name="documentId">Id of document that should be associated with positions</param>
        /// <param name="positions">Array of positions to be added to the </param>
        /// <returns><see cref="Task"/> containing the API response with the updated <typeparamref name="TEntity"/></returns>
        public virtual Task<ApiResponse> AddPositions<TPosition>(Guid documentId, TPosition[] positions)
            where TPosition : DocumentPosition
        {
            var contextPath = $"{Path}/{documentId}/positions/";

            var requestContext = new RequestContext(contextPath, HttpMethod.Post)
                .WithBody(positions);

            return CallAsync(requestContext);
        }
    }

    /// <summary>
    /// Represents a API to interact with the <typeparamref name="TEntity"/> endpoint.
    /// </summary>
    /// <typeparam name="TEntity">The type of the meta entity.</typeparam>
    /// <typeparam name="TEntityBuilder">The type of the <see cref="ApiParameterBuilder"/> to get single entity.</typeparam>
    /// <typeparam name="TEntitiesBuilder">The type of the <see cref="ApiParameterBuilder"/> to get list of the entity.</typeparam>
    public abstract class EntityApiAccessor<TEntity, TEntityBuilder, TEntitiesBuilder> : ApiAccessor
        where TEntity : MetaEntity
        where TEntityBuilder : ApiParameterBuilder
        where TEntitiesBuilder : ApiParameterBuilder
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EntityApiAccessor{TEntity, TSingleBuilder, TListBuilder}" /> class
        /// with the API endpoint relative path, the HTTP client and the MoySklad credentials (optional).
        /// </summary>
        /// <param name="relativePath">The API endpoint relative path.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public EntityApiAccessor(string relativePath, HttpClient httpClient, MoySkladCredentials credentials = null)
            : base(relativePath, httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Creates the <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to create.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the created <typeparamref name="TEntity"/>.</returns>
        public virtual Task<ApiResponse<TEntity>> CreateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var requestContext = new RequestContext(HttpMethod.Post)
                .WithBody(entity);

            return CallAsync<TEntity>(requestContext);
        }

        /// <summary>
        /// Uploads an array of entites in MoySklad
        /// </summary>
        /// <param name="entities">Array of products which should be uploaded</param>
        public virtual Task<ApiResponse<TEntity[]>> CreateAsync(TEntity[] entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var requestContext = new RequestContext(HttpMethod.Post)
                .WithBody(entities);

            return CallAsync<TEntity[]>(requestContext);
        }

        /// <summary>
        /// Deletes the <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to delete.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var id = entity.GetId();
            if (!id.HasValue)
                throw new InvalidOperationException("The entity id cannot be null.");

            return DeleteAsync(id.Value);
        }

        /// <summary>
        /// Deletes the <typeparamref name="TEntity"/> by specified ID.
        /// </summary>
        /// <param name="id">The <typeparamref name="TEntity"/> ID.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(Guid id)
        {
            var requestContext = new RequestContext($"{Path}/{id}", HttpMethod.Delete);

            return CallAsync(requestContext);
        }

        /// <summary>
        /// Gets the list of <typeparamref name="TEntity"/> by query (optional).
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <typeparamref name="TEntity"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<TEntity>>> GetAllAsync(TEntitiesBuilder query = null)
        {
            var requestContext = new RequestContext();

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<EntitiesResponse<TEntity>>(requestContext);
        }

        /// <summary>
        /// Gets the <typeparamref name="TEntity"/> by ID and query (optional).
        /// </summary>
        /// <param name="id">The entity ID.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the <typeparamref name="TEntity"/>.</returns>
        public virtual Task<ApiResponse<TEntity>> GetAsync(Guid id, TEntityBuilder query = null)
        {
            var requestContext = new RequestContext($"{Path}/{id}");

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<TEntity>(requestContext);
        }

        /// <summary>
        /// Updates the <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to update.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the updated <typeparamref name="TEntity"/>.</returns>
        public virtual Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var id = entity.GetId();
            if (!id.HasValue)
                throw new InvalidOperationException("The entity id cannot be null.");

            var requestContext = new RequestContext($"{Path}/{id}", HttpMethod.Put)
                .WithBody(entity);

            return CallAsync<TEntity>(requestContext);
        }
    }


    #endregion Methods
}
