using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Остатки
    /// </summary>
    public class ReportStockApi : ApiAccessor
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ReportStockApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ReportStockApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/report/stock", httpClient, credentials)
        {
        }

        /// <summary>
        /// Отчет "Остатки в ячейках складаassortment ИЛИ store"
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual async Task<IReadOnlyCollection<ReportStockBySlot>> GetSlotsReportAsync(ApiParameterBuilder query = null)
        {
            var result = await GetShortReportAsync<ReportStockBySlot>("byslot/current", query);
            return result;
        }

        /// <summary>
        /// Получить краткий отчет, без <see cref="ApiResponse" />
        /// </summary>
        /// <typeparam name="TReport"></typeparam>
        /// <param name="relativePath"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private async Task<TReport[]> GetShortReportAsync<TReport>(string relativePath, ApiParameterBuilder query = null)
        {
            var requestContext = new RequestContext($"{Path}/{relativePath}", HttpMethod.Get);

            if (query != null)
                requestContext.WithQuery(query.Build());

            var httpResponse = await InternalCallAsync(requestContext);
            var result = (TReport[])await DeserializeAsync(httpResponse, typeof(TReport[]));
            return result ?? Array.Empty<TReport>();
        }
    }
}
