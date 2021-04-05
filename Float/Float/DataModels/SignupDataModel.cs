using Newtonsoft.Json;

namespace Float.DataModels
{
    public  class SignupDataModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

    }
}
