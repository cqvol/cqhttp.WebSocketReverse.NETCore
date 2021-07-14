using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Content
{
    public class CqHttpContent
    {
        /// <summary>
        /// 操作结果返回码
        /// </summary>
        [JsonPropertyName("retcode")]
        public int RetCode { get; set; }

        /// <summary>
        /// 结果状态
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// 终端ID
        /// </summary>
        [JsonPropertyName("seifid")]
        public long SelfId { get; set; }

        /// <summary>
        /// 操作编号
        /// </summary>
        [JsonPropertyName("echo")]
        public string Echo { get; set; }

        /// <summary>
        /// 操作结果
        /// </summary>
        [JsonPropertyName("data")]
        public JsonElement Data { get; set; }
    }

}
