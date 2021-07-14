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
    /// 检查更新
    /// 此接口 status 会返回 async，检查更新操作将会在线程池执行。
    /// </summary>
    internal class CheckUpdateParams : IParams
    {
        /// <summary>
        /// 是否自动进行，如果为 true，将不会弹窗提示，而仅仅输出日志，同时如果 auto_perform_update 为 true，则会自动更新（需要手动重启 酷Q）
        /// </summary>
        [JsonPropertyName("automatic")]
        public bool Automatic { get; set; }
    }
}
