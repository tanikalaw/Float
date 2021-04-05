using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float.DataModels
{
    public class ApiResponseDataModel
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
