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
    /// 设置群名片（群备注）
    /// </summary>
    internal class SetGroupCardParams : IParams
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// 	要设置的 QQ 号
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 群名片内容，不填或空字符串表示删除群名片
        /// </summary>
        [JsonPropertyName("card")]
        public string Card { get; set; }
    }
}
