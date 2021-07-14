using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Event
{
    public sealed class CqFriendRequestEventArgs : CqHttpBaseEventArgs
    {
        public long UserId { get; private set; }
        public string Flag { get; private set; }
        public string Comment { get; private set; }

        public CqFriendRequestEventArgs(Source source, long userId, string flag, string commet)
        {
            base.Source = source;
            this.UserId = userId;
            this.Flag = flag;
            this.Comment = commet;
        }
    }
}
