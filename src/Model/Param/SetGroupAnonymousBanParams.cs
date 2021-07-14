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
    ///  群组匿名用户禁言
    /// </summary>
    internal class SetGroupAnonymousBanParams : IParams
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// 要禁言的匿名用户的 flag（需从群消息上报的数据中获得）
        /// </summary>
        [JsonPropertyName("flag")]
        public string Flag { get; set; }

        /// <summary>
        /// 禁言时长，单位秒，无法取消匿名用户禁言
        /// </summary>
        [JsonPropertyName("duration")]
        public int Duration { get; set; }
    }
}
