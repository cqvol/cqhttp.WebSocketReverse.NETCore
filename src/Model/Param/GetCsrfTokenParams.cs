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
    /// 获取 CSRF Token
    /// </summary>
    internal class GetCsrfTokenParams : IParams
    {
        /// <summary>
        /// CSRF Token
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
