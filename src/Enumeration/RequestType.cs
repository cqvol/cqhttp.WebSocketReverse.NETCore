using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Enumeration
{
    public enum RequestType
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        [Description("send_msg")]
        SendMsg = 0,

        /// <summary>
        /// 撤回消息
        /// </summary>
        [Description("delete_msg")]
        DeleteMsg = 1,

        /// <summary>
        /// 发送好友赞
        /// </summary>
        [Description("send_like")]
        SendLike = 2,

        /// <summary>
        /// 群组踢人
        /// </summary>
        [Description("set_group_kick")]
        SetGroupKick = 3,

        /// <summary>
        /// 群组单人禁言
        /// </summary>
        [Description("set_group_ban")]
        SetGroupBan = 4,

        /// <summary>
        /// 群组匿名用户禁言
        /// </summary>
        [Description("set_group_anonymous_ban")]
        SetGroupAnonymousBan = 5,

        /// <summary>
        /// 群组全员禁言
        /// </summary>
        [Description("set_group_whole_ban")]
        SetGroupWholeBan = 6,

        /// <summary>
        /// 群组设置管理员
        /// </summary>
        [Description("set_group_admin")]
        SetGroupAdmin = 7,

        /// <summary>
        /// 群组匿名
        /// </summary>
        [Description("set_group_anonymous")]
        SetGroupAnonymous = 8,

        /// <summary>
        /// 设置群名片（群备注）
        /// </summary>
        [Description("set_group_card")]
        SetGroupCard = 9,

        /// <summary>
        /// 退出群组
        /// </summary>
        [Description("set_group_leave")]
        SetGroupLeave = 10,

        /// <summary>
        /// 设置群组专属头衔
        /// </summary>
        [Description("set_group_special_title")]
        SetGroupSpecialTitle = 11,

        /// <summary>
        /// 退出讨论组
        /// </summary>
        [Description("set_discuss_leave")]
        SetDiscussLeave = 12,

        /// <summary>
        /// 处理加好友请求
        /// </summary>
        [Description("set_friend_add_request")]
        SetFriendAddRequest = 13,

        /// <summary>
        /// 处理加群请求／邀请
        /// </summary>
        [Description("set_group_add_request")]
        SetGroupAddRequest = 14,

        /// <summary>
        /// 获取登录号信息
        /// </summary>
        [Description("get_login_info")]
        GetLoginInfo = 15,

        /// <summary>
        /// 获取陌生人信息
        /// </summary>
        [Description("get_stranger_info")]
        GetStrangerInfo = 16,

        /// <summary>
        /// 获取陌生人信息
        /// </summary>
        [Description("get_group_list")]
        GetGroupList = 17,

        /// <summary>
        /// 获取陌生人信息
        /// </summary>
        [Description("get_group_member_info")]
        GetGroupMemberInfo = 18,

        /// <summary>
        /// 获取陌生人信息
        /// </summary>
        [Description("get_group_member_list")]
        GetGroupMemberList = 19,

        /// <summary>
        /// 获取 Cookies
        /// </summary>
        [Description("get_cookies")]
        GetCookies = 20,

        /// <summary>
        /// 获取 CSRF Token
        /// </summary>
        [Description("get_csrf_token")]
        GetCsrfToken = 21,

        /// <summary>
        /// 获取 QQ 相关接口凭证
        /// </summary>
        [Description("get_credentials")]
        GetCredentials = 22,

        /// <summary>
        /// 获取语音
        /// </summary>
        [Description("get_record")]
        GetRecord = 23,

        /// <summary>
        /// 获取图片
        /// </summary>
        [Description("get_image")]
        GetImage = 24,

        /// <summary>
        /// 检查是否可以发送图片
        /// </summary>
        [Description("can_send_image")]
        CanSendImage = 25,

        /// <summary>
        /// 检查是否可以发送语音
        /// </summary>
        [Description("can_send_record")]
        CanSendRecord = 26,

        /// <summary>
        /// 获取插件运行状态
        /// </summary>
        [Description("get_status")]
        GetStatus = 27,

        /// <summary>
        /// 获取酷 Q 及 HTTP API 插件的版本信息
        /// </summary>
        [Description("get_version_info")]
        GetVersionInfo = 28,

        /// <summary>
        /// 重启酷 Q，并以当前登录号自动登录（需勾选快速登录）
        /// </summary>
        [Description("set_restart")]
        SetRestart = 29,

        /// <summary>
        /// 重启 HTTP API 插件
        /// </summary>
        [Description("set_restart_plugin")]
        SetRestartPlugin = 30,

        /// <summary>
        /// 清理数据目录
        /// </summary>
        [Description("clean_data_dir")]
        CleanDataDir = 31,

        /// <summary>
        /// 清理插件日志
        /// </summary>
        [Description("clean_plugin_log")]
        CleanPluginLog = 32,

        /// <summary>
        /// 获取好友列表
        /// </summary>
        [Description("_get_friend_list")]
        GetFriendList = 101,

        /// <summary>
        /// 获取群信息
        /// </summary>
        [Description("_get_group_info")]
        GetGroupInfo = 102,

        /// <summary>
        /// 清理数据目录
        /// </summary>
        [Description("_get_vip_info")]
        GetVipInfo = 103,

        [Description(".check_update")]
        /// <summary>
        /// 检查更新
        /// </summary>
        CheckUpdate = -1,

        [Description(".handle_quick_operation")]
        /// <summary>
        /// 快速操作
        /// </summary>
        HandleQuickOperation = -2,
    }
}
