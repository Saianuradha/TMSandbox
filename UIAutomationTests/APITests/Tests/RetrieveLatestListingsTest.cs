using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using WireMock.Server;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace UIAutomationTests.APITests.Tests
{
    public class RetrieveLatestListingsTest
    {
        private RestClient client;
        private WireMockServer server;

        [SetUp]
        public void Setup()
        {
            server = WireMockServer.Start(9876);
            client = new RestClient("http://localhost:9876");
        }

        [TearDown]
        public void TearDown()
        {
            server.Stop();
        }

        private void GetLatestListings_ReturnsSuccess()
        {
            // Read the content of the JSON file
            string jsonFilePath = "C:\\Users\\shyam\\OneDrive\\Desktop\\Anuradha\\C#\\TMSandbox\\UIAutomationTests\\APITests\\Data\\listingData.json";
            string responseBody = File.ReadAllText(jsonFilePath);

            // Set up the mock server response
            server.Given(
                Request.Create().WithPath("/v1/Listings/Latest").UsingGet()
            ).RespondWith(
                Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json") // Change content type if JSON
                .WithBody(responseBody)
            );
        }


        [Test]
        public async Task RetrieveLatestListingsTest_200()
        {
            // Arrange
            GetLatestListings_ReturnsSuccess();
           
            RestRequest request = new RestRequest("/v1/Listings/Latest", Method.Get);

            // Act
            RestResponse? response = null;
            try
            {
                response = await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Exception occurred: " + ex.Message);
            }

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ContentType, Is.EqualTo("application/json"));

        }
    }
}
