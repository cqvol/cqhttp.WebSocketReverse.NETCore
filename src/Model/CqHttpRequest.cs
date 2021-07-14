using cqhttp.WebSocketReverse.NETCore.Interface;
using cqhttp.WebSocketReverse.NETCore.JsonConverter;
using cqhttp.WebSocketReverse.NETCore.Enumeration;
using cqhttp.WebSocketReverse.NETCore.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model
{
    public class CqHttpRequest
    {
        [JsonPropertyName("action"), JsonConverter(typeof(EnumDescriptionConverterFactory))]
        public RequestType Task { get; set; }

        [JsonPropertyName("echo")]
        public string Echo { get; set; }

        [JsonPropertyName("params"), JsonConverter(typeof(ParamConverter))]
        public IParams Params { get; set; }
    }
}
