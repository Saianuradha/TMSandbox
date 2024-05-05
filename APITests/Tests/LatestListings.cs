using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using WireMock.Server;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace APITests.Tests
{
    public class LatestListings
    {
        private RestClient client;
        private WireMockServer server;

        [SetUp]
        public void Setup()
        {
            server = WireMockServer.Start(9876);
        }

        [TearDown]
        public void TearDown()
        {
            server.Stop();
        }

        private void GetLatestListings_ReturnsSuccess()
        {
            server.Given(
                Request.Create().WithPath("/v1/Listings/Latest").UsingGet()
            ).RespondWith(
                Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "text/plain")
                .WithBody("Hello, world!")
            );
        }

        [Test]
        public async Task TestHelloWorldStub()
        {
            // Arrange
            GetLatestListings_ReturnsSuccess();
            client = new RestClient("http://localhost:9876");
            RestRequest request = new RestRequest("/v1/Listings/Latest", Method.Get);

            // Act
            RestResponse response = null;
            try
            {
                response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Exception occurred: " + ex.Message);
            }

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ContentType, Is.EqualTo("text/plain"));
            Assert.That(response.Content, Is.EqualTo("Hello, world!"));
        }
    }
}

