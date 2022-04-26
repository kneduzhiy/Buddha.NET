using Newtonsoft.Json;
using System;

namespace Buddha.NET
{
    public class ErrorData
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public Guid CorrelationId { get; set; } = Guid.NewGuid();
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        public string Message { get; set; } = string.Empty;
        public dynamic Data { get; set; }
    }
}
