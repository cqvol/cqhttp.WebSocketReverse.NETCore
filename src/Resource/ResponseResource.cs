using cqhttp.WebSocketReverse.NETCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Resource
{
    /// <summary>
    /// CQHTTP 回调合集
    /// </summary>
    public class ResponseResource
    {
        /// <summary>
        /// 操作结果返回码
        /// </summary>
        public int Retcode { get; set; }

        /// <summary>
        /// 操作失败与否
        /// </summary>
        public bool IsFailed { get; set; }

        /// <summary>
        /// 操作无效与否
        /// </summary>
        public bool IsInVaild { get; set; } = true;

        /// <summary>
        /// 消息Id
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// 好友列表
        /// </summary>
        public IList<FriendGroup> FriendGroupList { get; set; }

        /// <summary>
        /// 登录号信息
        /// </summary>
        public LoginInfo LoginInfo { get; set; }

        /// <summary>
        /// 陌生人信息,会员信息
        /// </summary>
        public QQInfo QQInfo { get; set; }

        /// <summary>
        /// 群列表
        /// </summary>
        public IList<Group> GroupList { get; set; }

        /// <summary>
        /// 群成员,群成员列表
        /// </summary>
        public IList<GroupMemberInfo> GroupMemberList { get; set; }

        /// <summary>
        /// QQ 相关接口凭证
        /// </summary>
        public Credentials Credentials { get; set; }

        /// <summary>
        /// 图片语音文件信息
        /// </summary>
        public FileInfo File { get; set; }

        /// <summary>
        /// 插件运行状态
        /// </summary>
        public CqHttpStatus Status { get; set; }

        /// <summary>
        /// 酷 Q 及 HTTP API 插件的版本信息
        /// </summary>
        public CqHttpVersion Version { get; set; }

        /// <summary>
        /// 是否可以发送图片
        /// </summary>
        public bool CanSendImage { get; set; }

        /// <summary>
        /// 是否可以发送语音
        /// </summary>
        public bool CanSendRecord { get; set; }
    }

}
