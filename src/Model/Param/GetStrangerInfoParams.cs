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
    /// 获取陌生人信息
    /// </summary>
    internal class GetStrangerInfoParams : IParams
    {
        /// <summary>
        /// QQ 号
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 是否不使用缓存（使用缓存可能更新不及时，但响应更快）
        /// </summary>
        [JsonPropertyName("no_cache")]
        public bool NoCache { get; set; }
    }
}
