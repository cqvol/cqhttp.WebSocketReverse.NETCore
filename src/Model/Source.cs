using cqhttp.WebSocketReverse.NETCore.Enumeration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model
{
    public class Source
    {
        /// <summary>
        /// <para>原始事件数据对象</para>
        /// </summary>
        public string Context { get; private set; }

        /// <summary>
        /// <para>接收者</para>
        /// </summary>
        public long SelfId { get; private set; }

        /// <summary>
        /// <para>接收时间</para>
        /// </summary>
        public DateTime ReceivedDate { get; private set; }

        /// <summary>
        /// <para>连接器数据</para>
        /// </summary>
        public ConnectionData ConnectionData { get; private set; }

        /// <summary>
        /// <para>发送</para>
        /// </summary>
        public Func<string, Task> Send { get; private set; }

        /// <summary>
        /// <para>QQ 号</para>
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// <para>群号</para>
        /// </summary>
        public long GroupId { get; private set; }

        /// <summary>
        /// <para>讨论组 ID</para>
        /// </summary>
        public long DiscussId { get; private set; }

        /// <summary>
        /// 消息识别分类
        /// </summary>
        public MessageFlags Flags { get; private set; }


        public Source(long selfId, DateTime receivedDate, MessageEventArgs MessageEventArgs)
        {
            this.SelfId = selfId;
            this.Context = MessageEventArgs.Message;
            this.ReceivedDate = receivedDate;
            this.ConnectionData = MessageEventArgs.ConnectionData;
            this.Send = MessageEventArgs.Connection.Send;
        }

        public void UpdateSource(long userId, long groupId, long discussId, MessageFlags flags)
        {
            this.UserId = userId;
            this.GroupId = groupId;
            this.DiscussId = discussId;
            this.Flags = flags;
        }
    }
}
