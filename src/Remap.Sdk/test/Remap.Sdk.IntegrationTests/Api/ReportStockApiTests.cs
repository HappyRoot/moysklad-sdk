using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class ReportStockApiTests
    {
        private MoySkladCredentials _credentials;
        private ReportStockApi _subject;

        [Test]
        public async Task GetSlotsReportAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder();
            query.Limit(100);

            query
                .Parameter("storeId")
                .Should()
                .Be("4b9badc8-3770-11ee-0a80-0e33000dd211");

            var response = await _subject.GetSlotsReportAsync(query);

        }
        
        [SetUp]
        public void Init()
        {
            var account = TestAccount.Create();
            _credentials = new MoySkladCredentials()
            {
                Username = account.Username,
                Password = account.Password
            };

            var httpClientHandler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            _subject = new ReportStockApi(new HttpClient(httpClientHandler), _credentials);
        }
    }
}