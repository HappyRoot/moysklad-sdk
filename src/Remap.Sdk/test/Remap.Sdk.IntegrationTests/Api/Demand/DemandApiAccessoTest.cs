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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Routing;
using FluentAssertions;
using System.IO;
using System.Text.Json;

namespace Remap.Sdk.IntegrationTests.Api.DemandTests
{
    public class EntityApiAccessorTest
    {
        private MoySkladCredentials _credentials;
        private DemandApi _subject;

        private readonly string DATA_PATH = "\\Api\\Demand";

        [Test]
        public async Task Positions_Succesfully_Added()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            currentDirectory += DATA_PATH;
            string jsonFilePath = Path.Combine(currentDirectory,  "data.json");
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            var jsonData = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(jsonString);

            var documentId = Guid.Parse(jsonData.GetProperty("docId").GetString());	
            var positonJsonWithType = jsonData.GetProperty("value").GetString();
/*

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects };
            var temp = JsonConvert.SerializeObject(positions, settings);
*/
            try
            {
                var doc = _subject.GetAsync(documentId).Result;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is ApiException)
                {
                    var apiException = (ApiException)ex.InnerException;
                    if (apiException.ErrorCode == 404)
                    {
                        var newDoc = new Demand();
                        newDoc.Id = documentId;
                        newDoc.Name = $"Integration Test Document from {DateTime.Now}";
                        newDoc.Organization = new Organization();
                        newDoc.Organization.Meta = new Meta()
                        {
                            Href = "https://api.moysklad.ru/api/remap/1.2/entity/organization/4b9a82bf-3770-11ee-0a80-0e33000dd20f",
                            MediaType = "application/json",
                            Type = EntityType.Organization
                        };

                        newDoc.Store = new Store();
                        newDoc.Store.Meta = new Meta()
                        {
                            Href = "https://api.moysklad.ru/api/remap/1.2/entity/store/4b9badc8-3770-11ee-0a80-0e33000dd211",
                            MediaType = "application/json",
                            Type = EntityType.Store
                        };
                        newDoc.Agent = new Counterparty();
                        newDoc.Agent.Meta = new Meta()
                        {
                            Href = "https://api.moysklad.ru/api/remap/1.2/entity/counterparty/4bd9a2ce-3770-11ee-0a80-0e33000dd230",
                            MediaType = "application/json",
                            Type = EntityType.Counterparty
                        };
                        var result = await _subject.CreateAsync(newDoc);
                        documentId = result.Payload.Id.Value;
                    }
                }
            }

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects };
            var positions = JsonConvert.DeserializeObject<DemandPosition[]>(positonJsonWithType, settings);
            foreach (var position in positions)
            {
                position.Meta = null;
                position.Id = null;
                position.AccountId = null;
            }
            var response = await _subject.AddPositions(documentId, positions);
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
            _subject = new DemandApi(new HttpClient(httpClientHandler), _credentials);
        }
    }
}
