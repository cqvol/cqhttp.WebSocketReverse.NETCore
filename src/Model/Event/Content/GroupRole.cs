using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model
{
    public enum GroupRole : byte
    {
        /// <summary>
        /// 成员
        /// </summary>
        Member = 0,

        /// <summary>
        /// 管理员
        /// </summary>
        Admin = 1,

        /// <summary>
        /// 群主
        /// </summary>
        Owner = 255,
    }
}
