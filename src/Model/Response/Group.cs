using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Response
{
    public class Group
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// 群名称
        /// </summary>
        [JsonPropertyName("group_name")]
        public string GroupName { get; set; }

        /// <summary>
        /// 创建时间戳
        /// </summary>
        [JsonPropertyName("create_time")]
        public long CreatTimeStamp { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonIgnore()]
        public DateTime CreatTime
        {
            get
            {
                return DateTimeOffset.FromUnixTimeSeconds(CreatTimeStamp).DateTime;
            }
        }

        /// <summary>
        /// 群分类，具体这个 ID 对应的名称暂时没有
        /// </summary>
        [JsonPropertyName("category")]
        public int Category { get; set; }

        /// <summary>
        /// 成员数
        /// </summary>
        [JsonPropertyName("member_count")]
        public int MemberCount { get; set; }

        /// <summary>
        /// 最大成员数（群容量）
        /// </summary>
        [JsonPropertyName("max_member_count")]
        public int MaxMemberCount { get; set; }

        /// <summary>
        /// 群介绍
        /// </summary>
        [JsonPropertyName("introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// 群主和管理员列表
        /// </summary>
        [JsonPropertyName("admins")]
        public IReadOnlyList<Admin> Admins { get; set; }

        /// <summary>
        /// 群主和管理员数
        /// </summary>
        [JsonPropertyName("admin_count")]
        public int AdminCount { get; set; }

        /// <summary>
        /// 最大群主和管理员数
        /// </summary>
        [JsonPropertyName("max_admin_count")]
        public int MaxAdminCount { get; set; }

        /// <summary>
        /// 群主 QQ 号
        /// </summary>
        [JsonPropertyName("owner_id")]
        public long OwnerId { get; set; }

    }
}
