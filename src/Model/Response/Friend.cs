using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Response
{
    public class Friend
    {
        /// <summary>
        /// 好友昵称
        /// </summary>
        [JsonPropertyName("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// 好友备注
        /// </summary>
        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 好友 QQ 号
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 好友所在分组 ID
        /// </summary>
        [JsonPropertyName("friend_group_id")]
        public int FriendGroupId { get; set; }
    }
}
