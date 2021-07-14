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
    internal class SetRestartPluginParams : IParams
    {
        /// <summary>
        /// 要延迟的毫秒数，如果默认情况下无法重启，可以尝试设置延迟为 2000 左右
        /// </summary>
        [JsonPropertyName("delay")]
        public int Delay { get; set; }
    }
}
