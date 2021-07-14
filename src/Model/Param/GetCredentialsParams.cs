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
    /// 获取 QQ 相关接口凭证
    /// </summary>
    internal class GetCredentialsParams : IParams
    {
        /// <summary>
        /// 需要获取 cookies 的域名
        /// </summary>
        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// CSRF Token
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
