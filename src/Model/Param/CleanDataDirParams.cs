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
    /// 清理数据目录
    /// </summary>
    internal class CleanDataDirParams : IParams
    {
        /// <summary>
        /// 收到清理的目录名，支持 image、record、show、bface
        /// </summary>
        [JsonPropertyName("data_dir")]
        public string DataDir { get; set; }
    }
}
