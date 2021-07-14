using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model
{
    public sealed class CqHttpSender
    {
        /// <summary>
        /// QQ号
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// QQ 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 群名片／备注
        /// </summary>
        public string Card { get; set; }

        /// <summary>
        /// 专属头衔
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 成员等级
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public InGroupSex Sex { get; set; } = InGroupSex.Unknown;

        /// <summary>
        /// 角色
        /// </summary>
        public GroupRole Role { get; set; } = GroupRole.Member;
    }
}
