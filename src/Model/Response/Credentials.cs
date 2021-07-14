using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Response
{
    public class Credentials
    {
        /// <summary>
        /// Cookies
        /// </summary>
        [JsonPropertyName("cookies")]
        public string Cookies { get; set; }

        /// <summary>
        /// CSRF Token
        /// </summary>
        [JsonPropertyName("csrf_token")]
        public int CsrfToken { get; set; }

        [JsonPropertyName("token")]
        private int Token { set { CsrfToken = value; } }
    }

}
