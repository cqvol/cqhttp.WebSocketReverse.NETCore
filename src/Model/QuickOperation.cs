using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model
{
    public sealed class QuickOperation
    {
        /// <summary>
        /// 回复
        /// </summary>
        [JsonPropertyName("reply")]
        public string Reply { get; set; }

        /// <summary>
        /// @发送者
        /// </summary>
        [JsonPropertyName("at_sender")]
        public bool? AtSender { get; set; }

        /// <summary>
        /// 群组撤回成员消息
        /// </summary>
        [JsonPropertyName("delete")]
        public bool? Delete { get; set; }

        /// <summary>
        /// 群组踢人
        /// </summary>
        [JsonPropertyName("Kick")]
        public bool? Kick { get; set; }

        /// <summary>
        /// 群组禁言
        /// </summary>
        [JsonPropertyName("ban")]
        public bool? Ban { get; set; }

        /// <summary>
        /// 处理请求
        /// </summary>
        [JsonPropertyName("approve")]
        public bool? Approve { get; set; }

        /// <summary>
        /// 添加后的好友备注（仅在同意时有效）
        /// </summary>
        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 拒绝理由（仅在拒绝时有效）
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    }
}
