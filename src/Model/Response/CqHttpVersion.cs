using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Response
{
    public class CqHttpVersion
    {
        /// <summary>
        /// 酷 Q 根目录路径
        /// </summary>
        [JsonPropertyName("coolq_directory")]
        public string CoolqDirectory { get; set; }

        /// <summary>
        /// 酷 Q 版本，air 或 pro
        /// </summary>
        [JsonPropertyName("coolq_edition")]
        public string CoolqEdition { get; set; }

        /// <summary>
        /// HTTP API 插件版本，例如 2.1.3
        /// </summary>
        [JsonPropertyName("plugin_version")]
        public string PluginVersion { get; set; }

        /// <summary>
        /// HTTP API 插件 build 号
        /// </summary>
        [JsonPropertyName("plugin_build_number")]
        public int PluginBuildNumber { get; set; }

        /// <summary>
        /// HTTP API 插件编译配置，debug 或 release
        /// </summary>
        [JsonPropertyName("plugin_build_configuration")]
        public string PluginBuildConfiguration { get; set; }
    }

}
