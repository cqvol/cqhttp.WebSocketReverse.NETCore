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
    /// 获取好友列表
    /// </summary>
    internal class GetFriendListParams : IParams
    {
        /// <summary>
        /// 是否获取扁平化的好友数据，即所有好友放在一起、所有分组放在一起，而不是按分组层级
        /// </summary>
        [JsonPropertyName("flat")]
        public bool Flat { get; set; }
    }
}
