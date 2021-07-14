using cqhttp.WebSocketReverse.NETCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace cqhttp.WebSocketReverse.NETCore
{
    public class CqHttpMessage
    {
        private readonly StringBuilder RawMessage = new StringBuilder();

        /// <summary>
        /// 发送图片
        /// </summary>
        /// <param name="filePath">酷Q data\image 相对目錄下的文件 或网络链接 file://http[s] 或本地文件系统链接 file=file:/// 或base64编码 file=base64://</param>
        /// <param name="cache">使用缓存</param>
        /// <param name="timeout">设置下载操作超时</param>
        /// <returns></returns>
        public CqHttpMessage WithImage(string filePath,bool cache = true,int timeout = 0)
        {
            RawMessage.Append("[CQ:image");
            if (!cache) { RawMessage.Append(",cache=0"); }
            if (timeout!=0) { RawMessage.Append($",timeout={timeout}"); }
            RawMessage.Append($",file={filePath}]");
            return this;
        }

        /// <summary>
        /// 发送本地图片
        /// </summary>
        /// <param name="Path">本地文件路徑</param>
        /// <param name="cache">使用缓存</param>
        /// <param name="timeout">设置下载操作超时</param>
        /// <returns></returns>
        public CqHttpMessage WithLocalImage(string Path, bool cache = true, int timeout = 0)
        {
            RawMessage.Append("[CQ:image");
            if (!cache) { RawMessage.Append(",cache=0"); }
            if (timeout != 0) { RawMessage.Append($",timeout={timeout}"); }
            RawMessage.Append($",file=file:///{Path}]");
            return this;
        }

        /// <summary>
        /// 发送网络图片
        /// </summary>
        /// <param name="url">网络链接</param>
        /// <param name="cache">使用缓存</param>
        /// <param name="timeout">设置下载操作超时</param>
        /// <returns></returns>
        public CqHttpMessage WithImageUrl(string url, bool cache = true, int timeout = 0)
        {
            RawMessage.Append("[CQ:image");
            if (!cache) { RawMessage.Append(",cache=0"); }
            if (timeout != 0) { RawMessage.Append($",timeout={timeout}"); }
            RawMessage.Append($",file://{url}]");
            return this;
        }

        /// <summary>
        /// 发送Base64图片
        /// </summary>
        /// <param name="base64">base64编码</param>
        /// <param name="cache">使用缓存</param>
        /// <param name="timeout">设置下载操作超时</param>
        /// <returns></returns>
        public CqHttpMessage WithBase64Image(string base64, bool cache = true, int timeout = 0)
        {
            RawMessage.Append("[CQ:image");
            if (!cache) { RawMessage.Append(",cache=0"); }
            if (timeout != 0) { RawMessage.Append($",timeout={timeout}"); }
            RawMessage.Append($",file=base64://{base64}]");
            return this;
        }

        /// <summary>
        /// 发送语音
        /// </summary>
        /// <param name="filePath">酷Q data\record 相对目錄下的文件 或网络链接 file://http[s] 或本地文件系统链接 file=file:/// 或base64编码 file=base64://</param>
        /// <param name="cache">使用缓存</param>
        /// <param name="timeout">设置下载操作超时</param>
        /// <returns></returns>
        public string Record(string filePath, bool cache = true, int timeout = 0)
        {
            RawMessage.Clear();
            RawMessage.Append("[CQ:record");
            if (!cache) { RawMessage.Append(",cache=0"); }
            if (timeout != 0) { RawMessage.Append($",timeout={timeout}"); }
            RawMessage.Append($",file={filePath}]");
            return RawMessage.ToString();
        }

        /// <summary>
        /// 发送本地语音
        /// </summary>
        /// <param name="Path">本地文件路徑</param>
        /// <param name="cache">使用缓存</param>
        /// <param name="timeout">设置下载操作超时</param>
        /// <returns></returns>
        public string LocalRecord(string Path, bool cache = true, int timeout = 0)
        {
            RawMessage.Clear();
            RawMessage.Append("[CQ:record");
            if (!cache) { RawMessage.Append(",cache=0"); }
            if (timeout != 0) { RawMessage.Append($",timeout={timeout}"); }
            RawMessage.Append($",file=file:///{Path}]");
            return RawMessage.ToString();
        }

        /// <summary>
        /// 发送网络语音
        /// </summary>
        /// <param name="url">网络链接</param>
        /// <param name="cache">使用缓存</param>
        /// <param name="timeout">设置下载操作超时</param>
        /// <returns></returns>
        public string RecodUrl(string url, bool cache = true, int timeout = 0)
        {
            RawMessage.Clear();
            RawMessage.Append("[CQ:record");
            if (!cache) { RawMessage.Append(",cache=0"); }
            if (timeout != 0) { RawMessage.Append($",timeout={timeout}"); }
            RawMessage.Append($",file://{url}]");
            return RawMessage.ToString();
        }

        /// <summary>
        /// 发送Base64语音
        /// </summary>
        /// <param name="base64">base64编码</param>
        /// <param name="cache">使用缓存</param>
        /// <param name="timeout">设置下载操作超时</param>
        /// <returns></returns>
        public string Base64Record(string base64, bool cache = true, int timeout = 0)
        {
            RawMessage.Clear();
            RawMessage.Append("[CQ:record");
            if (!cache) { RawMessage.Append(",cache=0"); }
            if (timeout != 0) { RawMessage.Append($",timeout={timeout}"); }
            RawMessage.Append($",file=base64://{base64}]");
            return RawMessage.ToString();
        }

        /// <summary>
        /// 发送系统表情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CqHttpMessage WithFace(int id)
        {
            RawMessage.Append("[CQ:face");
            RawMessage.Append($",id={id}]");
            return this;
        }

        /// <summary>
        /// 发送emoji表情
        /// </summary>
        /// <param name="emoji">emoji</param>
        /// <returns></returns>
        public CqHttpMessage WithEmojiId(string emojiId)
        {
            RawMessage.Append("[CQ:emoji");
            RawMessage.Append($",id={emojiId}]");
            return this;
        }

        /// <summary>
        /// 发送文字
        /// </summary>
        /// <param name="emoji">emoji</param>
        /// <returns></returns>
        public CqHttpMessage WithText(string text)
        {
            RawMessage.Append(text);
            return this;
        }

        /// <summary>
        /// 发送原创表情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CqHttpMessage WithBface(int id)
        {
            RawMessage.Append("[CQ:bface");
            RawMessage.Append($",id={id}]");
            return this;
        }

        /// <summary>
        /// 发送小表情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CqHttpMessage WithSface(int id)
        {
            RawMessage.Append("[CQ:sface");
            RawMessage.Append($",id={id}]");
            return this;
        }

        /// <summary>
        /// 发送 @
        /// </summary>
        /// <param name="userId">QQ 号</param>
        /// <returns></returns>
        public CqHttpMessage WithAt(long userId)
        {
            RawMessage.Append("[CQ:at");
            RawMessage.Append($",qq={userId}]");
            return this;
        }

        /// <summary>
        /// 发送 @
        /// </summary>
        /// <param name="userId">QQ 号</param>
        /// <returns></returns>
        public CqHttpMessage WithAtAll()
        {
            RawMessage.Append("[CQ:at");
            RawMessage.Append($",qq=all]");
            return this;
        }

        /// <summary>
        /// 发送猜拳魔法表情
        /// </summary>
        /// <param name="typeId">
        /// 1 - 猜拳结果为石头
        /// 2 - 猜拳结果为剪刀
        /// 3 - 猜拳结果为布</param>
        /// <returns></returns>
        public CqHttpMessage WithAt(int typeId)
        {
            RawMessage.Clear();
            RawMessage.Append("[CQ:rps");
            RawMessage.Append($",type={typeId}]");
            return this;
        }

        /// <summary>
        /// 掷骰子魔法表情
        /// </summary>
        /// <returns></returns>
        public string Dice()
        {
            RawMessage.Clear();
            RawMessage.Append("[CQ:dice]");
            return RawMessage.ToString();
        }

        /// <summary>
        /// 戳一戳
        /// </summary>
        /// <returns></returns>
        public string Shake()
        {
            RawMessage.Clear();
            RawMessage.Append("[CQ:shake]");
            return RawMessage.ToString();
        }

        /// <summary>
        /// 地点
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="lon">经度</param>
        /// <param name="title">分享地点的名称</param>
        /// <param name="content">分享地点的具体地址</param>
        /// <returns></returns>
        public string Location(double lat, double lon, string title, string content)
        {
            RawMessage.Clear();
            RawMessage.Append($"[CQ:location,lat={lat},lon={lon},title={title},content={content}]");
            return RawMessage.ToString();
        }


        /// <summary>
        /// 音乐
        /// </summary>
        /// <param name="type">音乐平台类型，目前支持qq、163</param>
        /// <param name="songId">对应音乐平台的数字音乐id</param>
        /// <param name="styleId">音乐卡片的风格。</param>
        /// <returns></returns>
        public string Music(string type, int songId, int styleId = 4)
        {
            RawMessage.Clear();
            RawMessage.Append($"[CQ:music,type={type},id={songId},style={styleId}]");
            return RawMessage.ToString();
        }


        /// <summary>
        /// 音乐自定义分享
        /// </summary>
        /// <param name="url">分享链接，即点击分享后进入的音乐页面（如歌曲介绍页）。</param>
        /// <param name="audio">音频链接（如mp3链接）。</param>
        /// <param name="title">音乐的标题，建议12字以内。</param>
        /// <param name="content">音乐的简介，建议30字以内。该参数可被忽略。</param>
        /// <param name="image">音乐的封面图片链接。若参数为空或被忽略，则显示默认图片。</param>
        /// <returns></returns>
        public string MusicCard(string url, string audio, string title, string content, string image)
        {
            RawMessage.Clear();
            RawMessage.Append($"[CQ:music,type=custom,url={url},audio={audio},title={title},content={content},image={image}]");
            return RawMessage.ToString();
        }

        /// <summary>
        /// 链接分享
        /// </summary>
        /// <param name="url">分享链接。</param>
        /// <param name="title">分享的标题，建议12字以内。</param>
        /// <param name="content">分享的简介，建议30字以内。该参数可被忽略。</param>
        /// <param name="image">分享的图片链接。若参数为空或被忽略，则显示默认图片。</param>
        /// <returns></returns>
        public string UrlShare(string url, string title, string content, string image)
        {
            RawMessage.Clear();
            RawMessage.Append($"[CQ:share,url={url},title={title},content={content},image={image}]");
            return RawMessage.ToString();
        }

        public override string ToString()
        {
            return RawMessage.ToString();
        }
    }
}
