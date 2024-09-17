using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.IntegrationTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Entities;
using FluentAssertions;

namespace Remap.Sdk.IntegrationTests.Api
{
    public class ProductApiTests
    {
        private MoySkladCredentials _credentials;
        private ProductApi _subject;


        [Test]
        public async Task Should_Return_Ok_When_Adding_Multiple_Products()
        {

           

            Product[] products = new Product[]
            {
                new Product()
                {
                    Name = "test product 1"
                },
                new Product()
                {
                    Name = "test product 2"
                }
            };

            var response = await _subject.CreateAsync(products);
            response.StatusCode.Should().Be(200);
            response.Payload.Length.Should().Be(2);
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
            _subject = new ProductApi(new HttpClient(httpClientHandler), _credentials);
        }
    }
}
