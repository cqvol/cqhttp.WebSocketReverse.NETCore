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
    /// <para>获取语音</para>
    /// <para>其实并不是真的获取语音，而是转换语音到指定的格式，然后返回语音文件名（data\record 目录下）。</para>
    /// <para>注意，要使用此接口，需要安装 酷Q 的 <see href="https://cqp.cc/t/21132">语音组件</see>。</para>
    /// </summary>
    internal class GetRecordParams : IParams
    {
        /// <summary>
        /// 收到的语音文件名（CQ 码的 file 参数），如 <see href="0B38145AA44505000B38145AA4450500.silk"/>
        /// </summary>
        [JsonPropertyName("file")]
        public string File { get; set; }

        /// <summary>
        /// 要转换到的格式，目前支持 mp3、amr、wma、m4a、spx、ogg、wav、flac
        /// </summary>
        [JsonPropertyName("out_format")]
        public string OutFormat { get; set; }

        /// <summary>
        /// 是否返回文件的绝对路径（Windows 环境下建议使用，Docker 中不建议）
        /// </summary>
        [JsonPropertyName("full_path")]
        public bool FullPath { get; set; } = false;
    }
}
