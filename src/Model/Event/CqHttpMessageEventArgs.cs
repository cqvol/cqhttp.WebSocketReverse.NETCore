using cqhttp.WebSocketReverse.NETCore.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Event
{
    public sealed class CqHttpMessageEventArgs : CqHttpBaseEventArgs
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public int MessageId { get; private set; }

        /// <summary>
        /// QQ 号
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// <para>目标ID</para>
        /// <para>指在讨论组事件代表讨论组ID</para>
        /// <para>而在其他事件之下则代表群号</para>
        /// </summary>
        public long TargetId { get; private set; }

        /// <summary>
        /// <para>群号</para>
        /// </summary>
        public long GroupId { get; private set; }

        /// <summary>
        /// <para>讨论组 ID</para>
        /// </summary>
        public long DiscussId { get; private set; }

        /// <summary>
        /// 字体
        /// </summary>
        public long FontId { get; private set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// 原消息
        /// </summary>
        public string RawMessage { get; private set; }

        /// <summary>
        /// 发送者
        /// </summary>
        public CqHttpSender Sender { get; private set; }

        /// <summary>
        /// 匿名数据
        /// </summary>
        public Anonymous Anonymous { get; private set; }

        /// <summary>
        /// 消息识别分类
        /// </summary>
        public MessageFlags Flags { get; private set; }

        public CqHttpMessageEventArgs(Source source, string message, string rawMessage, string subType, int messageId, long targetId, long fontId, CqHttpSender sender, Anonymous anonymous)
        {
            base.Source = source;
            this.Flags = MessageFlags.Discuss;
            this.RawMessage = rawMessage;
            this.Message = message;
            this.MessageId = messageId;
            this.UserId = sender.UserId;
            this.TargetId = targetId;
            this.FontId = fontId;
            this.Sender = sender;
            this.Anonymous = anonymous;

            switch (subType)
            {
                case "normal":
                    this.Flags = MessageFlags.Group;
                    break;
                case "anonymous":
                    this.Flags = MessageFlags.Group | MessageFlags.Anonymous;
                    break;
                case "notice":
                    this.Flags = MessageFlags.Group | MessageFlags.Notice;
                    break;
                case "friend":
                    this.Flags = MessageFlags.Private | MessageFlags.Friend;
                    break;
                case "group":
                    this.Flags = MessageFlags.Private | MessageFlags.Group;
                    break;
                case "discuss":
                    this.Flags = MessageFlags.Private | MessageFlags.Discuss;
                    break;
                case "other":
                    this.Flags = MessageFlags.Private | MessageFlags.Other;
                    break;
            }
            if (this.Flags.HasFlag(MessageFlags.Group))
            {
                this.GroupId = targetId;
            }
            if (this.Flags.HasFlag(MessageFlags.Discuss))
            {
                this.DiscussId = targetId;
            }
            this.Source.UpdateSource(this.UserId, this.GroupId, this.GroupId, this.Flags);
        }
    }
}
