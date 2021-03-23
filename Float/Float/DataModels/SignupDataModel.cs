using Newtonsoft.Json;

namespace Float.DataModels
{
    public  class SignupDataModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

    }
}
