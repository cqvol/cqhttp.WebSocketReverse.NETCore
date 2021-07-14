using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Event
{
    /// <summary>
    /// 元事件 - 连接
    /// </summary>
    public sealed class ConnectEventArgs : CqHttpBaseEventArgs
    {
        public ConnectEventArgs(Source source)
        {
            base.Source = source;
        }
    }
}
