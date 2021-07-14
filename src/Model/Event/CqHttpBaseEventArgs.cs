using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Event
{
    public class CqHttpBaseEventArgs : EventArgs
    {
        /// <summary>
        /// 來源
        /// </summary>
        public Source Source { get; set; }
    }
}
