using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using TSBAssessment.APITests.Model;

namespace TSBAssessment.APITests.Tests
{
    [TestFixture]
    public class GetLatestListingsRequest
    {
        private string hostUrl = "https://developer.trademe.co.nz";
        private string latestListingsUrlPath = "/v1/Listings/Latest";
        private string requestTokenUrlPath = "/api-overview/authentication";
        private string oAuthToken;

        [Test]
        public void getOAuthToken()
        {
            var client = new RestClient(hostUrl);
            var request = new RestRequest(requestTokenUrlPath, Method.Post);
            request.AddParameter("oauth_consumer_key", "consumer_key");
            request.AddParameter("oauth_consumer_secret", "consumer_secret");
            request.AddParameter("oauth_signature_method", "PLAINTEXT");

            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseToken = JsonConvert.DeserializeObject<ResponseToken>(response.Content);
            oAuthToken = responseToken.AccessToken;
        }

        [Test]
        public void GetLatestListingsTest()
        {
           
            var client = new RestClient(hostUrl);
            var request = new RestRequest(latestListingsUrlPath, Method.Post);
            request.AddParameter("oauth_consumer_key", "consumer_key");
            request.AddParameter("oauth_consumer_secret", "consumer_secret");
            request.AddParameter("oauth_key", "oAuthKey");
            request.AddParameter("oauth_token", "oAuthToken");
            request.AddParameter("oauth_signature_method", "PLAINTEXT");

            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var requestResponse = JsonConvert.DeserializeObject<LatestListing>(response.Content);
            requestResponse.title.Should().NotBeNullOrEmpty();



        }
    }
}
