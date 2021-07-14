using cqhttp.WebSocketReverse.NETCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Params
{
    /// <summary>
    /// 群组踢人
    /// </summary>
    internal class SetGroupKickParams : IParams
    {
        /// <summary>
        /// 要踢的 QQ 号
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// 拒绝此人的加群请求
        /// </summary>
        [JsonPropertyName("reject_add_request")]
        public bool RejectAddRequest { get; set; }
    }
}
