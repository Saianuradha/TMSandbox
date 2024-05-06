using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UIAutomationTests.APITests.Tests
{
    public class ListAnItemTest
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

        [Test]
        public async Task PostAnItemTest()
        {
            // Define the request body with the necessary data
            // Read the JSON file into a string
            string jsonFilePath = "C:\\Users\\shyam\\OneDrive\\Desktop\\Anuradha\\C#\\TMSandbox\\UIAutomationTests\\APITests\\Data\\listItemData.json";
                                            
            string requestBody = File.ReadAllText(jsonFilePath);

            // Arrange: Set up the mock server response for the POST method
            server.Given(
                Request.Create().WithPath("/v1/Selling").UsingPost()
                .WithBody(requestBody) // Optional: Match specific request body
            ).RespondWith(
                Response.Create()
                .WithStatusCode(201)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{'message': 'Success'}")
            );

            // Act: Make a POST request to the mock server
            RestRequest request = new RestRequest("/v1/Selling", Method.Post);
            request.AddJsonBody(requestBody); // Set request body
            RestResponse response = await client.ExecuteAsync(request);

            // Assert: Verify the response from the mock server
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
            Assert.That(response.Content, Is.EqualTo("{'message': 'Success'}"));
        }

        [Test]
        public void TestPostRequestWithResponseStatus_400()
        {
            // Define WireMock expectation for POST request with different response status
            server.Given(
               Request.Create().WithPath("/v1/Selling").UsingPost()
                ).RespondWith(Response.Create().WithStatusCode(400));

            // Prepare POST request with invalid body
            var requestBody = new { key = "value" };

            // Make POST request using RestSharp
            var client = new RestClient(server.Urls[0]);
            var request = new RestRequest("/api/resource", Method.Post);
            request.AddJsonBody(requestBody);
            var response = client.Execute(request);

            // Assert the response status code
            Assert.AreEqual(400, (int)response.StatusCode);
        }
        [Test]
        public void TestPostRequestWithUnAuthorized_401()
        {
            // Define WireMock expectation for POST request with specific headers
            server
                .Given(Request.Create().WithPath("/V1/Selling").UsingPost()
                .WithHeader("Authorization", "Invalid Bearer token"))
                .RespondWith(Response.Create().WithStatusCode(401));

            // Prepare POST request body
            var requestBody = new { key = "value" };

            // Make POST request using RestSharp with custom header
            var client = new RestClient(server.Urls[0]);
            var request = new RestRequest("/api/resource", Method.Post);
            request.AddHeader("Authorization", "Invalid Bearer token");
            request.AddJsonBody(requestBody);
            var response = client.Execute(request);

            // Assert the response status code
            Assert.AreEqual(401, (int)response.StatusCode);
        }
    }
}
