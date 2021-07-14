using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Response
{

    public class GroupMemberInfo
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// QQ 号
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [JsonPropertyName("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// 群名片／备注
        /// </summary>
        [JsonPropertyName("card")]
        public string Card { get; set; }

        /// <summary>
        /// 性别，male 或 female 或 unknown
        /// </summary>
        [JsonPropertyName("sex")]
        public string Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [JsonPropertyName("age")]
        public int Age { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        [JsonPropertyName("area")]
        public string Area { get; set; }

        /// <summary>
        /// 加群时间戳
        /// </summary>
        [JsonPropertyName("join_time")]
        public int JoinTime { get; set; }

        /// <summary>
        /// 最后发言时间戳
        /// </summary>
        [JsonPropertyName("last_sent_time")]
        public int LastSentTime { get; set; }

        /// <summary>
        /// 成员等级
        /// </summary>
        [JsonPropertyName("level")]
        public string Level { get; set; }

        /// <summary>
        /// 角色，owner 或 admin 或 member
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }

        /// <summary>
        /// 是否不良记录成员
        /// </summary>
        [JsonPropertyName("unfriendly")]
        public bool Unfriendly { get; set; }

        /// <summary>
        /// 专属头衔
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// 专属头衔过期时间戳
        /// </summary>
        [JsonPropertyName("title_expire_time")]
        public int TitleExpireTime { get; set; }

        /// <summary>
        /// 是否允许修改群名片
        /// </summary>
        [JsonPropertyName("card_changeable")]
        public bool CardChangeable { get; set; }
    }

}
