using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Event
{
    public sealed class CqGroupNoticEventArgs : CqHttpBaseEventArgs
    {
        public long GroupId { get; private set; }
        public long UserId { get; private set; }
        public long OperatorId { get; private set; }
        public long BanDuration { get; private set; }
        public File File { get; private set; }
        public GroupNotic Type { get; private set; }
        public CqGroupNoticEventArgs(Source source, long GroupId, long UserId, long OperatorId, long BanDuration, File File, GroupNotic Type)
        {
            base.Source = source;
            this.GroupId = GroupId;
            this.UserId = UserId;
            this.OperatorId = OperatorId;
            this.BanDuration = BanDuration;
            this.File = File;
            this.Type = Type;
        }
    }
}
