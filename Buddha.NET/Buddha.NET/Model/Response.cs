using Newtonsoft.Json;

namespace Buddha.NET
{
    public class Response<TResponse> where TResponse : class
    {
        [JsonIgnore]
        public int HttpStatusCode { get; set; } = 200;

        public bool Success { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TResponse Data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ErrorData Error { get; set; }
    }
}
