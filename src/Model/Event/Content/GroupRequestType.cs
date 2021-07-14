using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model
{
    public enum GroupRequestType : byte
    {
        /// <summary>
        /// 添加
        /// </summary>
        Add = 0,

        /// <summary>
        /// 邀请
        /// </summary>
        Invite = 1,
    }
}
