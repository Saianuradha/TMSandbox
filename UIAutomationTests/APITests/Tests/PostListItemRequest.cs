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
                request.AddParameter("oauth_consumer_key", "consumer_key");
                request.AddParameter("oauth_consumer_secret", "consumer_secret");
                request.AddParameter("oauth_signature_method", "PLAINTEXT");

                var response = client.Execute(request);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

                var responseToken = JsonConvert.DeserializeObject<ResponseToken>(response.Content);
                oAuthToken = responseToken.AccessToken;           

        }

        [Test]
        public void PostAnItemTest()
        {

            var client = new RestClient(hostUrl);
            var request = new RestRequest(listItemUrlPath, Method.Post);
            request.AddParameter("oauth_consumer_key", "consumer_key");
            request.AddParameter("oauth_consumer_secret", "consumer_secret");
            request.AddParameter("oauth_key", "oAuthKey");
            request.AddParameter("oauth_token", "oAuthToken");
            request.AddParameter("oauth_signature_method", "PLAINTEXT");
            
            string jsonFilePath = "C:\\Users\\shyam\\OneDrive\\Desktop\\Anuradha\\C#\\TMSandbox\\UIAutomationTests\\APITests\\Data\\listItemData.json";
            string requestBody = File.ReadAllText(jsonFilePath);

            request.AddBody(requestBody);

            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            
        }
    }
}
