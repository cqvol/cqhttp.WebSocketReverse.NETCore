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
    /// 获取图片
    /// </summary>
    internal class GetImageParams : IParams
    {
        /// <summary>
        /// 收到的图片文件名（CQ 码的 file 参数），如 <see href="6B4DE3DFD1BD271E3297859D41C530F5.jpg"/>
        /// </summary>
        [JsonPropertyName("file")]
        public string File { get; set; }
    }
}
