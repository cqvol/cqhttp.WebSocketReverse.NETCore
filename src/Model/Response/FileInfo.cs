using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Response
{
    public class FileInfo
    {
        /// <summary>
        /// 下载后的图片/转换后的语音文件路径
        /// </summary>
        [JsonPropertyName("file")]
        public string FilePath { get; set; }
    }

}
