using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Response
{
    public class FriendGroup
    {
        /// <summary>
        /// 好友分组 ID
        /// </summary>
        [JsonPropertyName("friend_group_id")]
        public int FriendGroupId { get; set; }

        /// <summary>
        /// 好友分组名称
        /// </summary>
        [JsonPropertyName("friend_group_name")]
        public string FriendGroupName { get; set; }

        /// <summary>
        /// 分组中的好友
        /// </summary>
        [JsonPropertyName("friends")]
        public IList<Friend> Friends { get; set; }
    }
}
