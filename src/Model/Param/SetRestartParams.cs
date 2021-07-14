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
    /// 重启 酷Q，并以当前登录号自动登录（需勾选快速登录）
    /// </summary>
    internal class SetRestartParams : IParams
    {
        /// <summary>
        /// 是否在重启时清空 酷Q 的日志数据库（log*.db）
        /// </summary>
        [JsonPropertyName("clean_log")]
        public bool CleanLog { get; set; }

        /// <summary>
        /// 是否在重启时清空 酷Q 的缓存数据库（cache.db）
        /// </summary>
        [JsonPropertyName("clean_cache")]
        public bool CleanCache { get; set; }

        /// <summary>
        /// 是否在重启时清空 酷Q 的事件数据库（eventv2.db）
        /// </summary>
        [JsonPropertyName("clean_event")]
        public bool CleanEvent { get; set; }
    }
}
