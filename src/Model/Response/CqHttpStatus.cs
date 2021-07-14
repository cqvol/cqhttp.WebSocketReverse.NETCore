using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Response
{
    public class CqHttpStatus
    {
        /// <summary>
        /// HTTP API 插件已初始化
        /// </summary>
        [JsonPropertyName("app_initialized")]
        public bool AppInitialized { get; set; }

        /// <summary>
        /// HTTP API 插件已启用
        /// </summary>
        [JsonPropertyName("app_enabled")]
        public bool App_enabled { get; set; }

        /// <summary>
        /// HTTP API 的各内部插件是否正常运行
        /// </summary>
        [JsonPropertyName("plugins_good")]
        public JsonElement PluginsGood { get; set; }

        /// <summary>
        /// HTTP API 插件正常运行（已初始化、已启用、各内部插件正常运行）
        /// </summary>
        [JsonPropertyName("app_good")]
        public bool AppGood { get; set; }

        /// <summary>
        /// 	当前 QQ 在线
        /// </summary>
        [JsonPropertyName("online")]
        public bool Online { get; set; }

        /// <summary>
        /// 	HTTP API 插件状态符合预期，意味着插件已初始化，内部插件都在正常运行，且 QQ 在线
        /// </summary>
        [JsonPropertyName("good")]
        public bool Good { get; set; }
    }

}
