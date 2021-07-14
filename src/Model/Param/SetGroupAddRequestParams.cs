using cqhttp.WebSocketReverse.NETCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Params
{
    /// <summary>
    /// 处理加群请求／邀请
    /// </summary>
    internal class SetGroupAddRequestParams : IParams
    {
        /// <summary>
        /// 加群请求的 flag（需从上报的数据中获得）
        /// </summary>
        [JsonPropertyName("flag")]
        public string Flag { get; set; }

        /// <summary>
        /// add 或 invite，请求类型（需要和上报消息中的 sub_type 字段相符）
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// 是否同意请求／邀请
        /// </summary>
        [JsonPropertyName("approve")]
        public bool Approve { get; set; }

        /// <summary>
        /// 拒绝理由（仅在拒绝时有效）
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    }
}
