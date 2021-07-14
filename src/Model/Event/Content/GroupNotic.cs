using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model
{
    [Flags]
    public enum GroupNotic : int
    {
        /// <summary>
        /// 
        /// </summary>
        Upload = 0,
        /// <summary>
        /// 
        /// </summary>
        Increase = 1,
        /// <summary>
        /// 
        /// </summary>
        Decrease = 2,
        /// <summary>
        /// 
        /// </summary>
        Admin = 4,
        /// <summary>
        /// 
        /// </summary>
        Ban = 8,
        /// <summary>
        /// 
        /// </summary>
        Set = 16,
        /// <summary>
        /// 
        /// </summary>
        UnSet = 32,
        /// <summary>
        /// 
        /// </summary>
        Leave = 64,
        /// <summary>
        /// 
        /// </summary>
        Kick = 128,
        /// <summary>
        /// 
        /// </summary>
        KickMe = 256,
        /// <summary>
        /// 
        /// </summary>
        Approve = 512,
        /// <summary>
        /// 
        /// </summary>
        Invite = 1024,
        /// <summary>
        /// 
        /// </summary>
        Lift_Ban = 2048,
    }
}
