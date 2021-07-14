using cqhttp.WebSocketReverse.NETCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Params
{
    /// <summary>
    /// 撤回消息
    /// </summary>
    internal class DeleteMessageParams : IParams
    {
        /// <summary>
        /// 消息 ID
        /// </summary>
        [JsonPropertyName("message_id")]
        public int MessageId { get; set; }
    }
}
