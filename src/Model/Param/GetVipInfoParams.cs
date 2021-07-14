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
    /// 获取会员信息
    /// </summary>
    internal class GetVipInfoParams : IParams
    {
        /// <summary>
        /// 要查询的 QQ 号
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }
    }
}
