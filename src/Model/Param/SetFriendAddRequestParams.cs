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
    /// 处理加好友请求
    /// </summary>
    internal class SetFriendAddRequestParams : IParams
    {
        /// <summary>
        /// 加好友请求的 flag（需从上报的数据中获得）
        /// </summary>
        [JsonPropertyName("flag")]
        public string Flag { get; set; }

        /// <summary>
        /// 是否同意请求
        /// </summary>
        [JsonPropertyName("approve")]
        public bool Approve { get; set; }

        /// <summary>
        /// 添加后的好友备注（仅在同意时有效）
        /// </summary>
        [JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}
