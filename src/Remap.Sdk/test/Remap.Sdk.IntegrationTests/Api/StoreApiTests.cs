using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class StoreApiTests
    {
        private MoySkladCredentials _credentials;
        private StoreApi _subject;

        [Test]
        public async Task GetStoresAsync_with_slots_and_zones_should_return_status_code_404()
        {
            var query = new ApiParameterBuilder<Store>();
            query.Expand()
                .With("slots")
                .And.With("slots.zone")
                .And.With("zones");

            query.Limit(100);

            var response = await _subject.GetAllAsync(query);

            response.StatusCode.Should().Be(200);
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
            _subject = new StoreApi(new HttpClient(httpClientHandler), _credentials);
        }
    }
}