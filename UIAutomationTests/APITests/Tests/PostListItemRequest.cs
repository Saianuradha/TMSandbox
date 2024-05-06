using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TSBAssessment.APITests.Model;

namespace TSBAssessment.APITests.Tests   // Test class to list an item 
{
    public class PostListItemRequest
    {
        private string hostUrl = "https://developer.trademe.co.nz";
        private string listItemUrlPath = "/v1/Selling";
        private string tokenUrlPath = "/api-overview/authentication";
        private string oAuthToken;
        

        [Test]
        public void getOAuthToken()  // getting oAuth token from Authorization page"
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
        public void PostAnItemTest()
        {
            var client = new RestClient(hostUrl);
            var request = new RestRequest(tokenUrlPath, Method.Post);

            request.AddParameter("grant_type", "Authorization");
            request.AddParameter("Oauth_KEY", "*******");
            request.AddParameter("Oauth_SECRET", "########");
            var response = client.Execute(request);
            ResponseToken responseToken = JsonConvert.DeserializeObject<ResponseToken>(response.Content);  //sending post reuqest
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            oAuthToken = responseToken.AccessToken;

            var request2 = new RestRequest(listItemUrlPath, Method.Post);
            Console.WriteLine(oAuthToken);
            request2.AddHeader("authorization", "Bearer " + oAuthToken);
            var response2 = client.Execute(request2);
            Assert.AreEqual(HttpStatusCode.OK, response2.StatusCode);


        }
    }
}
