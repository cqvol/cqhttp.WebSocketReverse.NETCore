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
    /// 设置群组专属头衔
    /// </summary>
    internal class SetGroupSpecialTitleParams : IParams
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// 要设置的 QQ 号
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 专属头衔，不填或空字符串表示删除专属头衔
        /// </summary>
        [JsonPropertyName("special_title")]
        public string SpecialTitle { get; set; }

        /// <summary>
        /// 专属头衔有效期，单位秒，-1 表示永久，不过此项似乎没有效果，可能是只有某些特殊的时间长度有效，有待测试
        /// </summary>
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

    }
}
