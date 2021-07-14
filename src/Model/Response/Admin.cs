using cqhttp.WebSocketReverse.NETCore.JsonConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Response
{
    public class Admin
    {
        /// <summary>
        /// QQ 号
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// QQ 昵称
        /// </summary>
        [JsonPropertyName("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// 角色，owner 表示群主、admin 表示管理员
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }
    }

}
