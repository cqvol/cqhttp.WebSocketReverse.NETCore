using cqhttp.WebSocketReverse.NETCore.Interface;
using cqhttp.WebSocketReverse.NETCore.JsonConverter;
using cqhttp.WebSocketReverse.NETCore.Model;
using cqhttp.WebSocketReverse.NETCore.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Params
{
    /// <summary>
    /// 发送消息
    /// </summary>
    public class MessageParams : IParams
    {
        /// <summary>
        /// 消息类型，支持 private、group、discuss，分别对应私聊、群组、讨论组，如不传入，则根据传入的 *_id 参数判断
        /// </summary>
        [JsonPropertyName("message_type"), JsonConverter(typeof(EnumDescriptionConverterFactory))]
        public MessageFlags MessageType { get; set; }

        /// <summary>
        /// 对方 QQ 号（消息类型为 private 时需要）
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 群号（消息类型为 group 时需要）
        /// </summary>
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// 讨论组 ID（消息类型为 discuss 时需要）
        /// </summary>
        [JsonPropertyName("discuss_id")]
        public long DiscussId { get; set; }

        /// <summary>
        /// 要发送的内容
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// 消息内容是否作为纯文本发送（即不解析 CQ 码）
        /// </summary>
        [JsonPropertyName("auto_escape")]
        public bool MessageAutoEscape { get; set; } = false;
    }
}
