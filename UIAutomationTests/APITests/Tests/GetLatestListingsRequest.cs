using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using TSBAssessment.APITests.Model;

namespace TSBAssessment.APITests.Tests
{
    [TestFixture]
    public class GetLatestListingsRequest  // test class to get latest listings
    {
        private string hostUrl = "https://developer.trademe.co.nz";
        private string latestListingsUrlPath = "/v1/Listings/Latest";
        private string tokenUrlPath = "/api-overview/authentication";
        private string oAuthToken;
        

        [Test]
        public void getOAuthToken()   /// getting Oauth token information
        {
            var client = new RestClient(hostUrl);
            var request = new RestRequest(tokenUrlPath, Method.Post);
            request.AddParameter("grant_type", "Authorization");
            request.AddParameter("CONSUMER_KEY", "1BF6AAB61BCA5860794E7DBB359B6898");
            request.AddParameter("CONSUMER_SECRET", "ACBC52B7E84289794C6FF307986374F6");
            var response = client.Execute(request);
            ResponseToken responseToken = JsonConvert.DeserializeObject<ResponseToken>(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            oAuthToken = responseToken.AccessToken;

        }

        [Test]
        public void GetLatestListingsTest()
        {
            var client = new RestClient(hostUrl);
            var request = new RestRequest(tokenUrlPath, Method.Post);

            request.AddParameter("grant_type", "Authorization");
            request.AddParameter("CONSUMER_KEY", "1BF6AAB61BCA5860794E7DBB359B6898");
            request.AddParameter("CONSUMER_SECRET", "ACBC52B7E84289794C6FF307986374F6");
            var response = client.Execute(request);
            ResponseToken responseToken = JsonConvert.DeserializeObject<ResponseToken>(response.Content);   /// sending Get request to get latest listing details 
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            oAuthToken = responseToken.AccessToken;

            var request2 = new RestRequest(latestListingsUrlPath, Method.Get);
            Console.WriteLine(oAuthToken);
            request2.AddHeader("authorization", "Bearer " + oAuthToken);
            var response2 = client.Execute(request2);
            Assert.AreEqual(HttpStatusCode.OK, response2.StatusCode);


        }
    }
}
