## cqhttp.WebSocketReverse.NETCore
[![GitHub Workflow Status](https://img.shields.io/github/workflow/status/cqbef/cqhttp.WebSocketReverse.NETCore/PublicSDK?style=for-the-badge)](https://github.com/cqbef/cqhttp.WebSocketReverse.NETCore/actions)
[![NugetVersion](https://img.shields.io/nuget/v/cqhttp.WebSocketReverse.NETCore?style=for-the-badge)](https://www.nuget.org/packages/cqhttp.WebSocketReverse.NETCore/)
[![NugetDownload](https://img.shields.io/nuget/dt/cqhttp.WebSocketReverse.NETCore?style=for-the-badge)](https://www.nuget.org/api/v2/package/cqhttp.WebSocketReverse.NETCore)

基於CQHTTP插件的反向WebSocket通道提供服務端SDK層級的封裝

#### 應用範例

```cs
using cqhttp.WebSocketReverse.NETCore;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

WebSocketServer wss = new WebSocketServer ("ws://0.0.0.0:8889");

CqHttpParse parse = new CqHttpParse(CqHttpApi.SetResult);
CqHttpApi.Timeout = TimeSpan.FromSeconds(10);

wss.OnAuthorizationAsync += async (s, e) =>
{
   await Task.Run(() =>
   {
      Debug.WriteLine(e.Connection.WebSocketConnectionInfo.ClientIpAddress);
      e.Allow();
   });
};
wss.OnReceiveMessageAsync += async (s, e) =>
{
   await parse.Parse(s, e);
};
parse.OnPrivateMessageAsync += async (n, b) =>
{
   var vipinfo = await b.Source.GetVipInfo();
   if(vipinfo?.VipLevel == "普通用户")
   {
      await b.Source.Reply(b.Message);
   }else
   {
      long qqId = 123456789;
      int messageId = await b.Source.SendPrivateMessage($"{b.Sender.NickName}對你說:{b.Message}",qqId);
      if(messageId>0)await b.Source.Reply("已傳達消息");
   }
};

```
