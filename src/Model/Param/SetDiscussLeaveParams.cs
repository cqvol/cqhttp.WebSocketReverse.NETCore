using cqhttp.WebSocketReverse.NETCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Params
{
    /// <summary>
    /// 发送讨论组消息
    /// </summary>
    internal class SetDiscussLeaveParams : IParams
    {
        /// <summary>
        /// 讨论组 ID（正常情况下看不到，需要从讨论组消息上报的数据中获得）
        /// </summary>
        [JsonPropertyName("discuss_id")]
        public long DiscussId { get; set; }

        /// <summary>
        /// 讨论组 ID（正常情况下看不到，需要从讨论组消息上报的数据中获得）
        /// </summary>
        [JsonPropertyName("message")]
        public JsonElement Message { get; set; }


    }
}
