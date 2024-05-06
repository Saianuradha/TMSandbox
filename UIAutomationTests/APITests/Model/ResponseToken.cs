using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSBAssessment.APITests.Model
{
    public class ResponseToken
    {
          [JsonProperty("access_token")]
            public string AccessToken { get; set; }

        }
    }
}
