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
    public class StoreApiTests
    {
        private MoySkladCredentials _credentials;
        private SupplyApi _subject;

        [Test]
        public async Task GetStoresAsync_with_slots_and_zones_should_return_status_code_404()
        {
            var query = new ApiParameterBuilder<SupplyQuery>();
            query.Expand()
                .With(p => p.Positions)
                    .And.With("positions.slot")
                    .And.With("positions.assortment")
                        .And.With("positions.assortment.product")
                        .And.With("positions.assortment.uom")
                    .And.With("positions.pack")
                        .And.With("positions.pack.uom");
            var doc = await _subject.GetAsync(Guid.Parse("9ce5d469-95c2-11ee-0a80-139800100389"), query).ConfigureAwait(false);
            //var query = new ApiParameterBuilder<Store>();
            //query.Expand()
            //    .With("slots")
            //    .And.With("slots.zone")
            //    .And.With("zones");

            //query.Limit(100);

            //var response = await _subject.GetAllAsync(query);

            //response.StatusCode.Should().Be(200);
        }

        [SetUp]
        public void Init()
        {
            var account = TestAccount.Create();
            _credentials = new MoySkladCredentials()
            {
                Username = "admin@testmscrpt",
                Password = "123123"
            };

            var httpClientHandler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            _subject = new SupplyApi(new HttpClient(httpClientHandler), _credentials); //new StoreApi(new HttpClient(httpClientHandler), _credentials);
        }
    }
}