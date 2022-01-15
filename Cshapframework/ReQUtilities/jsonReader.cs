using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpframework.ReQUtilities
{
    public class jsonReader
    {
        public jsonReader()
        {

        }
        
        public string extractdataAsString(string token)
        {
            var myJsonString = File.ReadAllText("ReQUtilities//TestData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(token).Value<string>();
        }
        public string[] extractdataAsListofString(string token)
        {
            var myJsonString = File.ReadAllText("ReQUtilities//TestData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectTokens(token).Values<string>().ToArray();
        }
    }
}
