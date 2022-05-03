using Newtonsoft.Json;

namespace Buddha.NET.Model
{
    public class ErrorItem
    {
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }
    }
}
