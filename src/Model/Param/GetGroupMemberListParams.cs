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
    ///  <para>获取群成员列表</para>
    ///  <para>响应内容为 JSON 数组，每个元素的内容和上面的 /get_group_member_info 接口相同，</para>
    ///  <para>但对于同一个群组的同一个成员，获取列表时和获取单独的成员信息时，某些字段可能有所不同，</para>
    ///  <para>例如 area、title 等字段在获取列表时无法获得，具体应以单独的成员信息为准。</para>
    /// </summary>
    internal class GetGroupMemberListParams : IParams
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }
    }
}
