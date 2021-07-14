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
    /// 退出群组
    /// </summary>
    internal class SetGroupLeaveParams : IParams
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// 是否解散，如果登录号是群主，则仅在此项为 true 时能够解散
        /// </summary>
        [JsonPropertyName("is_dismiss")]
        public bool IsDismiss { get; set; }

    }
}
