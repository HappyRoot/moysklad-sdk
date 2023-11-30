using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class SlotsApiTests
    {
        private MoySkladCredentials _credentials;
        private SlotsApi _subject;

        [Test]
        public async Task GetSlotsAsync_with_query_should_return_status_code_404()
        {
            var query = new ApiParameterBuilder<Slot>();
            query.Limit(100);
            var storeId = Guid.Parse("4b9badc8-3770-11ee-0a80-0e33000dd212");
            var response = await _subject.GetAllAsync(storeId, query);

            response.StatusCode.Should().Be(404);
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
            _subject = new SlotsApi(new HttpClient(httpClientHandler), _credentials);
        }
    }
}