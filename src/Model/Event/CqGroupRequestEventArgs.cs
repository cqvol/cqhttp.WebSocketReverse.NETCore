using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Event
{
    public sealed class CqGroupRequestEventArgs : CqHttpBaseEventArgs
    {
        public long GroupId { get; private set; }
        public long UserId { get; private set; }
        public GroupRequestType Type { get; private set; }
        public string Flag { get; private set; }
        public string Comment { get; private set; }

        public CqGroupRequestEventArgs(Source source, long userId, long groupId, string subType, string flag, string commet)
        {
            base.Source = source;
            this.UserId = userId;
            this.GroupId = groupId;
            this.Flag = flag;
            this.Comment = commet;
            switch (subType)
            {
                case "add":
                    this.Type = GroupRequestType.Add;
                    break;
                case "invite":
                    this.Type = GroupRequestType.Invite;
                    break;
            }
        }
    }
}
