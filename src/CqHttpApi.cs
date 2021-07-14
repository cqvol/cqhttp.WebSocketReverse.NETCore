using System;
using System.Linq;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using cqhttp.WebSocketReverse.NETCore.Model;
using cqhttp.WebSocketReverse.NETCore.Params;
using cqhttp.WebSocketReverse.NETCore.Resource;
using cqhttp.WebSocketReverse.NETCore.Enumeration;
using cqhttp.WebSocketReverse.NETCore.Model.Params;
using cqhttp.WebSocketReverse.NETCore.Model.Response;
using System.Threading;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore
{
    public static class CqHttpApi
    {
        /// <summary>
        /// 回调超时限制
        /// </summary>
        public static TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// 回复对方消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message">要发送的内容</param>
        /// <param name="atSender">@发送者</param>
        public static async ValueTask Reply(this Source source, string message, bool atSender = true)
        {
            await SendMessage(source, new CqHttpRequest()
            {
                Task = RequestType.HandleQuickOperation,
                Params = new HandleQuickOperationParams()
                {
                    Context = JsonDocument.Parse(source.Context).RootElement,
                    Operation = new QuickOperation()
                    {
                        Reply = message,
                        AtSender = atSender
                    }
                }
            });
        }

        /// <summary>
        /// 禁言对方(预设30分钟)
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask Ban(this Source source)
        {
            await SendMessage(source, new CqHttpRequest()
            {
                Task = RequestType.HandleQuickOperation,
                Params = new HandleQuickOperationParams()
                {
                    Context = JsonDocument.Parse(source.Context).RootElement,
                    Operation = new QuickOperation()
                    {
                        Ban = true
                    }
                }
            });
        }

        /// <summary>
        /// 踢对方
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask Kick(this Source source)
        {
            await SendMessage(source, new CqHttpRequest()
            {
                Task = RequestType.HandleQuickOperation,
                Params = new HandleQuickOperationParams()
                {
                    Context = JsonDocument.Parse(source.Context).RootElement,
                    Operation = new QuickOperation()
                    {
                        Kick = true
                    }
                }
            });
        }

        /// <summary>
        /// 同意群组/好友请求
        /// </summary>
        /// <param name="source"></param>
        /// <param name="remark">好友备注</param>
        public static async ValueTask Approve(this Source source, string remark = "")
        {
            await SendMessage(source, new CqHttpRequest()
            {
                Task = RequestType.HandleQuickOperation,
                Params = new HandleQuickOperationParams()
                {
                    Context = JsonDocument.Parse(source.Context).RootElement,
                    Operation = new QuickOperation()
                    {
                        Approve = true,
                        Remark = remark
                    }
                }
            });
        }

        /// <summary>
        /// 拒绝群组/好友请求
        /// </summary>
        /// <param name="source"></param>
        /// <param name="reson">拒绝理由</param>
        public static async ValueTask Disapprove(this Source source, string reson = "")
        {
            await SendMessage(source, new CqHttpRequest()
            {
                Task = RequestType.HandleQuickOperation,
                Params = new HandleQuickOperationParams()
                {
                    Context = JsonDocument.Parse(source.Context).RootElement,
                    Operation = new QuickOperation()
                    {
                        Approve = false,
                        Reason = reson
                    }
                }
            });
        }

        /// <summary>
        /// 撤回对方消息
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask Delete(this Source source)
        {
            await SendMessage(source, new CqHttpRequest()
            {
                Task = RequestType.HandleQuickOperation,
                Params = new HandleQuickOperationParams()
                {
                    Context = JsonDocument.Parse(source.Context).RootElement,
                    Operation = new QuickOperation()
                    {
                        Delete = true
                    }
                }
            });
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message">要发送的内容</param>
        /// <param name="autoEscape">消息内容是否作为纯文本发送（即不解析 CQ 码），</param>
        public static async ValueTask<int> SendMessage(this Source source, string message, bool autoEscape = false)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SendMsg,
                Params = new MessageParams()
                {
                    MessageType = 
                    source.Flags.HasFlag(MessageFlags.Group) ? 
                        source.Flags.HasFlag(MessageFlags.Discuss) ? 
                            MessageFlags.Discuss :  
                        MessageFlags.Group :  
                    MessageFlags.Private,
                    Message = message,
                    UserId = source.UserId,
                    GroupId = source.GroupId,
                    DiscussId = source.DiscussId,
                    MessageAutoEscape = autoEscape
                }
            });
            return result?.MessageId ?? -1;
        }

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="userId">对方 QQ 号</param>
        /// <param name="message">要发送的内容</param>
        /// <param name="auto_escape">消息内容是否作为纯文本发送（即不解析 CQ 码），</param>
        public static async ValueTask<int> SendPrivateMessage(this Source source, string message, long userId = 0, bool autoEscape = false)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SendMsg,
                Params = new MessageParams()
                {
                    MessageType = MessageFlags.Group,
                    Message = message,
                    UserId = userId,
                    MessageAutoEscape = autoEscape
                }
            });
            return result?.MessageId ?? -1;
        }

        /// <summary>
        /// 发送群组匿名消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        /// <param name="message">要发送的内容</param>
        /// <param name="auto_escape">消息内容是否作为纯文本发送（即不解析 CQ 码），</param>
        public static async ValueTask<ResponseResource> SendGroupAnonymousMessage(this Source source, string message, long groupId = 0, bool autoEscape = false)
        {
            return await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SendMsg,
                Params = new MessageParams()
                {
                    MessageType = MessageFlags.Group,
                    Message = $"[CQ:anonymous,ignore=true]{message}",
                    GroupId = groupId,
                    MessageAutoEscape = autoEscape,
                }
            });
        }

        /// <summary>
        /// 发送群组消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        /// <param name="message">要发送的内容</param>
        /// <param name="auto_escape">消息内容是否作为纯文本发送（即不解析 CQ 码），</param>
        public static async ValueTask<ResponseResource> SendGroupMessage(this Source source, string message, long groupId = 0, bool autoEscape = false)
        {
            return await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SendMsg,
                Params = new MessageParams()
                {
                    MessageType = MessageFlags.Group,
                    Message = message,
                    GroupId = groupId,
                    MessageAutoEscape = autoEscape,
                }
            });
        }

        /// <summary>
        /// 发送讨论组消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="discussId">讨论组 ID（正常情况下看不到，需要从讨论组消息上报的数据中获得）</param>
        /// <param name="message">要发送的内容</param>
        /// <param name="auto_escape">消息内容是否作为纯文本发送（即不解析 CQ 码），</param>
        public static async ValueTask<ResponseResource> SendDiscussMessage(this Source source, string message, long discussId = 0, bool autoEscape = false)
        {
            return await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SendMsg,
                Params = new MessageParams()
                {
                    MessageType = MessageFlags.Discuss,
                    Message = message,
                    DiscussId = discussId,
                    MessageAutoEscape = autoEscape,
                }
            });
        }

        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="messageId">消息 ID</param>
        public static async ValueTask DeleteMessage(this Source source, int messageId)
        {
            await SendMessage(source, new CqHttpRequest()
            {
                Task = RequestType.DeleteMsg,
                Params = new DeleteMessageParams()
                {
                    MessageId = messageId
                }
            });
        }

        /// <summary>
        /// 发送好友赞
        /// </summary>
        /// <param name="source"></param>
        /// <param name="userId">对方 QQ 号</param>
        /// <param name="times">赞的次数，每个好友每天最多 10 次</param>
        public static async ValueTask SendLike(this Source source, long? userId = null, byte times = 1)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SendLike,
                Params = new SendLikeParams()
                {
                    UserId = userId ?? source.UserId,
                    Times = times
                }
            });
        }

        /// <summary>
        /// 群组踢人
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        /// <param name="userId">要踢的 QQ 号</param>
        /// <param name="rejectAddRequest">拒绝此人的加群请求</param>
        public static async ValueTask SetGroupKick(this Source source, long? groupId = null, long? userId = null, bool rejectAddRequest = false)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetGroupKick,
                Params = new SetGroupKickParams()
                {
                    GroupId = groupId ?? source.GroupId,
                    UserId = userId ?? source.UserId,
                    RejectAddRequest = rejectAddRequest
                }
            });
        }

        /// <summary>
        /// 群组单人禁言
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        /// <param name="duration">禁言时长，单位秒，0 表示取消禁言</param>
        public static async ValueTask SetGroupBan(this Source source, long? groupId = null, int duration = 1800)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetGroupBan,
                Params = new SetGroupBanParams()
                {
                    GroupId = groupId ?? source.GroupId,
                    Duration = duration,
                }
            });
        }

        /// <summary>
        /// 群组匿名用户禁言
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        /// <param name="flag">要禁言的匿名用户的 flag（需从群消息上报的数据中获得）</param>
        /// <param name="duration">禁言时长，单位秒，0 表示取消禁言</param>
        public static async ValueTask SetGroupAnonymousBan(this Source source, string flag, long? groupId = null, int duration = 1800)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetGroupAnonymousBan,
                Params = new SetGroupAnonymousBanParams()
                {
                    GroupId = groupId ?? source.GroupId,
                    Flag = flag,
                    Duration = duration,
                }
            });
        }

        /// <summary>
        /// 群组全员禁言
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        /// <param name="enable">是否禁言</param>
        /// <returns></returns>
        public static async ValueTask SetGroupWholeBan(this Source source, long? groupId = null, bool enable = true)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetGroupWholeBan,
                Params = new SetGroupWholeBanParams()
                {
                    GroupId = groupId ?? source.GroupId,
                    Enable = enable
                }
            });
        }

        /// <summary>
        /// 群组设置管理员
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        /// <param name="userId">要设置管理员的 QQ 号</param>
        /// <param name="enable">true 为设置，false 为取消</param>
        /// <returns></returns>
        public static async ValueTask SetGroupAdmin(this Source source, long? groupId, long? userId = null, bool enable = true)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetGroupAdmin,
                Params = new SetGroupAdminParams()
                {
                    GroupId = groupId ?? source.GroupId,
                    UserId = userId ?? source.UserId,
                    Enable = enable
                }
            });
        }

        /// <summary>
        /// 群组匿名
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        /// <param name="enable">是否允许匿名聊天</param>
        /// <returns></returns>
        public static async ValueTask SetGroupAnonymous(this Source source, long? groupId = null, bool enable = true)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetGroupAnonymous,
                Params = new SetGroupAnonymousParams()
                {
                    GroupId = groupId ?? source.GroupId,
                    Enable = enable
                }
            });
        }

        /// <summary>
        /// 设置群名片（群备注）
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        /// <param name="userId">要设置的 QQ 号</param>
        /// <param name="card">群名片内容，不填或空字符串表示删除群名片</param>
        /// <returns></returns>
        public static async ValueTask SetGroupAnonymous(this Source source, string card, long? groupId = null, long? userId = null)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetGroupCard,
                Params = new SetGroupCardParams()
                {
                    GroupId = groupId ?? source.GroupId,
                    UserId = userId ?? source.UserId,
                    Card = card
                }
            });
        }

        /// <summary>
        /// 退出群组
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        /// <param name="isDismiss">是否解散，如果登录号是群主，则仅在此项为 true 时能够解散</param>
        /// <returns></returns>
        public static async ValueTask SetGroupLeave(this Source source, long? groupId = null, bool isDismiss = false)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetGroupLeave,
                Params = new SetGroupLeaveParams()
                {
                    GroupId = groupId ?? source.GroupId,
                    IsDismiss = isDismiss
                }
            });
        }

        /// <summary>
        /// 设置群组专属头衔
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        /// <param name="userId">要设置的 QQ 号</param>
        /// <param name="specialTitle">专属头衔，不填或空字符串表示删除专属头衔</param>
        /// <param name="duration">专属头衔有效期，单位秒，-1 表示永久，不过此项似乎没有效果，可能是只有某些特殊的时间长度有效，有待测试</param>
        /// <returns></returns>
        public static async ValueTask SetGroupLeave(this Source source, long groupId, long userId, string specialTitle, int duration = -1)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetGroupSpecialTitle,
                Params = new SetGroupSpecialTitleParams()
                {
                    GroupId = groupId,
                    UserId = userId,
                    SpecialTitle = specialTitle,
                    Duration = duration
                }
            });
        }

        /// <summary>
        /// 退出讨论组
        /// </summary>
        /// <param name="source"></param>
        /// <param name="discussId">讨论组 ID（正常情况下看不到，需要从讨论组消息上报的数据中获得）</param>
        /// <returns></returns>
        public static async ValueTask SetGroupLeave(this Source source, long? discussId = null)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetDiscussLeave,
                Params = new SetDiscussLeaveParams()
                {
                    DiscussId = discussId ?? source.DiscussId
                }
            });
        }

        /// <summary>
        /// 处理加好友请求
        /// </summary>
        /// <param name="source"></param>
        /// <param name="flag">加好友请求的 flag（需从上报的数据中获得）</param>
        /// <param name="approve">是否同意请求</param>
        /// <param name="remark">添加后的好友备注（仅在同意时有效）</param>
        /// <returns></returns>
        public static async ValueTask SetGroupLeave(this Source source, string flag, bool approve = true, string remark = "")
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetFriendAddRequest,
                Params = new SetFriendAddRequestParams()
                {
                    Flag = flag,
                    Approve = approve,
                    Remark = remark
                }
            });
        }

        /// <summary>
        /// 处理加群请求／邀请
        /// </summary>
        /// <param name="source"></param>
        /// <param name="flag">加群请求的 flag（需从上报的数据中获得）</param>
        /// <param name="type">请求类型</param>
        /// <param name="approve">是否同意请求</param>
        /// <param name="reason">拒绝理由（仅在拒绝时有效）</param>
        /// <returns></returns>
        public static async ValueTask SetGroupLeave(this Source source, string flag, GroupRequestType type, bool approve = true, string reason = "")
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetFriendAddRequest,
                Params = new SetGroupAddRequestParams()
                {
                    Flag = flag,
                    Type = type == GroupRequestType.Add ? "add" : "invite",
                    Approve = approve,
                    Reason = reason
                }
            }); ;
        }

        /// <summary>
        /// 获取登录号信息
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask<LoginInfo> GetLoginInfo(this Source source)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetLoginInfo
            });
            return result?.LoginInfo;
        }

        /// <summary>
        /// 获取陌生人信息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="userId">QQ 号</param>
        /// <param name="noCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
        public static async ValueTask<QQInfo> GetStrangerInfo(this Source source, long? userId = null, bool noCache = false)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetStrangerInfo,
                Params = new GetStrangerInfoParams()
                {
                    UserId = userId ?? source.UserId,
                    NoCache = noCache
                }
            });
            return result?.QQInfo;
        }

        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask<IList<Group>> GetGroupList(this Source source)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetGroupList
            });
            return result?.GroupList;
        }

        /// <summary>
        /// 获取群成员信息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        /// <param name="userId">QQ号</param>
        /// <param name="noCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
        public static async ValueTask<GroupMemberInfo> GetGroupMemberInfo(this Source source, long? groupId = null, long? userId = null, bool noCache = false)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetGroupMemberInfo,
                Params = new GetGroupMemberInfoParams()
                {
                    GroupId = groupId ?? source.GroupId,
                    UserId = userId ?? source.UserId,
                    NoCache = noCache
                }
            });
            return result?.GroupMemberList.AsEnumerable()?.FirstOrDefault();
        }

        /// <summary>
        /// 获取群成员列表
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">群号</param>
        public static async ValueTask<IList<GroupMemberInfo>> GetGroupMemberList(this Source source, long? groupId = null)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetGroupMemberList,
                Params = new GetGroupMemberListParams()
                {
                    GroupId = groupId ?? source.GroupId
                }
            });
            return result?.GroupMemberList;
        }

        /// <summary>
        /// 获取 Cookies
        /// </summary>
        /// <param name="source"></param>
        /// <param name="domain">需要获取 cookies 的域名</param>
        public static async ValueTask<string> GetCookies(this Source source, string domain = "qq.com")
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetCookies,
                Params = new GetCookiesParams()
                {
                    Domain = domain
                }
            });
            return result?.Credentials.Cookies;
        }

        /// <summary>
        /// 获取 CSRF Token
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask<int> GetCsrfToken(this Source source)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetCsrfToken
            });
            return result?.Credentials.CsrfToken ?? -1;
        }

        /// <summary>
        /// 获取 QQ 相关接口凭证
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask<Credentials> GetCredentials(this Source source)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetCredentials
            });
            return result?.Credentials;
        }

        /// <summary>
        /// 获取语音
        /// <para>其实并不是真的获取语音，而是转换语音到指定的格式，然后返回语音文件名（data\record 目录下）。</para>
        /// <para>注意，要使用此接口，需要安装 酷Q 的 <see href="https://cqp.cc/t/21132">语音组件</see>。</para>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="file">收到的语音文件名</param>
        /// <param name="outFormat">要转换到的格式，目前支持 mp3、amr、wma、m4a、spx、ogg、wav、flac</param>
        /// <param name="fullPath">是否返回文件的绝对路径（Windows 环境下建议使用，Docker 中不建议）</param>
        public static async ValueTask<FileInfo> GetRecord(this Source source, string file, string outFormat, bool fullPath = false)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetRecord,
                Params = new GetRecordParams()
                {
                    File = file,
                    OutFormat = outFormat,
                    FullPath = fullPath
                }
            });
            return result?.File;
        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="source"></param>
        /// <param name="file">收到的语音文件名</param>
        public static async ValueTask<FileInfo> GetRecord(this Source source, string file)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetImage,
                Params = new GetImageParams()
                {
                    File = file,
                }
            });
            return result?.File;
        }

        /// <summary>
        /// 检查是否可以发送图片
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask<bool> CanSendImage(this Source source)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.CanSendImage,
            });
            return result?.CanSendImage ?? false;
        }

        /// <summary>
        /// 检查是否可以发送语音
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask<bool> CanSendRecord(this Source source)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.CanSendRecord,
            });
            return result?.CanSendRecord ?? false;
        }

        /// <summary>
        /// 获取插件运行状态
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask<CqHttpStatus> GetStatus(this Source source)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetStatus,
            });
            return result?.Status;
        }

        /// <summary>
        /// 获取酷 Q 及 HTTP API 插件的版本信息
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask<CqHttpVersion> GetVersionInfo(this Source source)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetVersionInfo,
            });
            return result?.Version;
        }

        /// <summary>
        /// 重启酷 Q，并以当前登录号自动登录（需勾选快速登录）
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cleanLog">是否在重启时清空酷 Q 的日志数据库（logv1.db）</param>
        /// <param name="cleanCache">是否在重启时清空酷 Q 的缓存数据库（cache.db）</param>
        /// <param name="cleanEvent">是否在重启时清空酷 Q 的事件数据库（eventv2.db）</param>
        public static async ValueTask SetRestart(this Source source, bool cleanLog = false, bool cleanCache = false, bool cleanEvent = false)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetRestart,
                Params = new SetRestartParams()
                {
                    CleanLog = cleanLog,
                    CleanCache = cleanCache,
                    CleanEvent = cleanEvent
                }
            });
        }

        /// <summary>
        /// 重启 HTTP API 插件
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask SetRestartPlugin(this Source source, int delay = 1)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.SetRestartPlugin,
                Params = new SetRestartPluginParams()
                {
                    Delay = delay
                }
            });
        }

        /// <summary>
        /// 清理数据目录
        /// 用于清理积攒了太多旧文件的数据目录，如 image。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data_dir">收到清理的目录名，支持 image、record、show、bface</param>
        public static async ValueTask CleanDataDir(this Source source, string data_dir)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.CleanDataDir,
                Params = new CleanDataDirParams()
                {
                    DataDir = data_dir
                }
            });
        }

        /// <summary>
        /// 用于清空插件的日志文件。
        /// </summary>
        /// <param name="source"></param>
        public static async ValueTask CleanPluginLog(this Source source)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.CleanPluginLog
            });
        }

        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <param name="source"></param>
        /// <param name="flat">是否获取扁平化的好友数据，即所有好友放在一起、所有分组放在一起，而不是按分组层级</param>
        public static async ValueTask<IList<FriendGroup>> GetFriendList(this Source source, bool flat = false)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetFriendList,
                Params = new GetFriendListParams()
                {
                    Flat = flat
                }
            });
            return result?.FriendGroupList;
        }

        /// <summary>
        /// 获取群信息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupId">要查询的群号</param>
        public static async ValueTask<Group> GetGroupInfo(this Source source, long? groupId = null)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetGroupInfo,
                Params = new GetGroupInfoParams()
                {
                    GroupId = groupId ?? source.GroupId
                }
            }); ;
            return result?.GroupList.AsEnumerable()?.FirstOrDefault();
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="userId">要查询的 QQ 号</param>
        public static async ValueTask<QQInfo> GetVipInfo(this Source source, long? userId = null)
        {
            var result = await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.GetVipInfo,
                Params = new GetVipInfoParams()
                {
                    UserId = userId ?? source.UserId
                }
            });
            return result?.QQInfo;
        }

        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="source"></param>
        /// <param name="automatic">是否自动进行，如果为 true，将不会弹窗提示，而仅仅输出日志，同时如果 auto_perform_update 为 true，则会自动更新并重启酷 Q</param>
        public static async ValueTask CheckUpdate(this Source source, bool automatic = false)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.CheckUpdate,
                Params = new CheckUpdateParams()
                {
                    Automatic = automatic
                }
            });
        }

        /// <summary>
        /// 对事件执行快速操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public static async ValueTask HandleQuickOperation(this Source source, string context, QuickOperation operation)
        {
            await SendRequestMessage(source, new CqHttpRequest()
            {
                Task = RequestType.HandleQuickOperation,
                Params = new HandleQuickOperationParams()
                {
                    Context = JsonDocument.Parse(context).RootElement,
                    Operation = operation
                }
            });
        }

        /// <summary>
        /// 发送原始请求消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="timeout"></param>
        private static async Task SendMessage(this Source source, CqHttpRequest message)
        {
            var api = source.ConnectionData.RoleAndConnections.TryGetValue("API", out Connection conn);
            if (api)
            {
                await conn.Send(JsonSerializer.Serialize(message, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Default }));
            }
        }

        /// <summary>
        /// 发送请求消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="timeout"></param>
        private static async Task<ResponseResource> SendRequestMessage(this Source source, CqHttpRequest message)
        {
            var api = source.ConnectionData.RoleAndConnections.TryGetValue("API", out Connection conn);
            if (api)
            {
                message.Echo = $"~{message.Task}@{Guid.NewGuid()}";
                await conn.Send(JsonSerializer.Serialize(message, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Default }));
                return await ActionResource.CQHTTPSubject
                    .Where(r => r.Item1 == message.Echo).Select(r => r.Item2).Take(1)
                    .Timeout(Timeout).Catch(Observable.Return<ResponseResource>(null)).ToTask();
            }
            return null;
        }

        [Obsolete]
        /// <summary>
        /// 发送请求消息(过时)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="timeout"></param>
        private static async Task<ResponseResource> SendRequestMessage_Dictionary(this Source source, CqHttpRequest message)
        {
            message.Echo = $"~{message.Task}@{Guid.NewGuid()}";
            var task = new TaskCompletionSource<ResponseResource>();
            if (ActionResource.Operations.TryAdd(message.Echo, task))
            {
                var api = source.ConnectionData.RoleAndConnections.TryGetValue("API", out Connection conn);
                if (api)
                {
                    await conn.Send(JsonSerializer.Serialize(message, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Default }));
                    bool received = await Task.WhenAny(task.Task, Task.Delay(Timeout)) == task.Task;
                    ActionResource.Operations.TryRemove(message.Echo, out TaskCompletionSource<ResponseResource> _);
                    if (received) return await task.Task;
                }
            }
            return null;
        }

        public static void SetResult(string echo, ResponseResource result)
        {
            ActionResource.CQHTTPSubject.OnNext(Tuple.Create(echo, result));
            //if (ActionResource.Operations.TryGetValue(echo, out TaskCompletionSource<ResponseResource> r))
            //{
            //    r.SetResult(result);
            //}
        }

    }
}
