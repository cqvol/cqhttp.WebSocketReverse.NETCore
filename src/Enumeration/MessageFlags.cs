using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Enumeration
{
    [Flags]
    public enum MessageFlags : byte
    {
        /// <summary>
        /// 私聊消息
        /// </summary>
        [Description("private")]
        Private = 1,

        /// <summary>
        /// 群消息
        /// </summary>
        [Description("group")]
        Group = 2,

        /// <summary>
        /// 讨论组消息
        /// </summary>
        [Description("discuss")]
        Discuss = 4,

        /// <summary>
        /// 好友消息
        /// </summary>
        Friend = 8,

        /// <summary>
        /// 匿名消息
        /// </summary>
        Anonymous = 16,

        /// <summary>
        /// 群公告消息
        /// </summary>
        Notice = 32,

        Other = 64
    }
}
