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
    /// 群组单人禁言
    /// </summary>
    internal class SetGroupBanParams : IParams
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// 要禁言的 QQ 号
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 禁言时长，单位秒，0 表示取消禁言
        /// </summary>
        [JsonPropertyName("duration")]
        public int Duration { get; set; }
    }
}
