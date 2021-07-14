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
    /// 发送好友赞
    /// </summary>
    internal class SendLikeParams : IParams
    {
        /// <summary>
        /// 对方 QQ 号
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 赞的次数，每个好友每天最多 10 次
        /// </summary>
        [JsonPropertyName("times")]
        public byte Times { get; set; }
    }
}
