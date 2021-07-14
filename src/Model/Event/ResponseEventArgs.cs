using cqhttp.WebSocketReverse.NETCore.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Event
{
    /// <summary>
    /// 元事件 - 回调
    /// </summary>
    public sealed class ResponseEventArgs : CqHttpBaseEventArgs
    {
        public CqHttpContent Response { get; set; }

        public ResponseEventArgs(Source source, CqHttpContent response)
        {
            base.Source = source;
            this.Response = response;
        }
    }
}
