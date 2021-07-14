using cqhttp.WebSocketReverse.NETCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Params
{
    /// <summary>
    /// 对事件执行快速操作
    /// </summary>
    internal class HandleQuickOperationParams : IParams
    {
        /// <summary>
        /// 事件上报的数据对象
        /// </summary>
        [JsonPropertyName("context")]
        public JsonElement Context { get; set; }

        /// <summary>
        /// 快速操作对象，例如 {"ban": true, "reply": "请不要说脏话"}
        /// </summary>
        [JsonPropertyName("operation")]
        public QuickOperation Operation { get; set; }
    }
}
