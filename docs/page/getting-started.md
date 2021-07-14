
#### 前置行为

查看CQHTTP 文档 https://richardchien.gitee.io/coolq-http-api/docs/4.15/#/

#### CQHTTP设置

假定你已经下载[CQHTTP插件](https://github.com/richardchien/coolq-http-api/releases/download/v4.15.0/io.github.richardchien.coolqhttpapi.cpk)并放置在相应位置及启用应用后,
你可以开始建立全局设置於<kbd>data\app\io.github.richardchien.coolqhttpapi\config.ini</kbd>然后重载应用。

```config.ini
[general]
use_http = false
use_ws = false
use_ws_reverse = true
ws_reverse_url = ws://127.0.0.1:8889
show_log_console = false
access_token = cqhttp_token
convert_unicode_emoji = true
serve_data_files = true
enable_heartbeat = true
heartbeat_interval = 15000
```

新建立一个NETCore 3.1 Console应用。

```cs

namespace ConsoleApp1
{
    using cqhttp.WebSocketReverse.NETCore;
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            WebSocketServer wss = new WebSocketServer("ws://0.0.0.0:8889");
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
                await b.Source.Reply(b.Message);
            };
			
            Console.ReadLine();
        }
    }
}


```

使用其他帐号联络机器人帐号,测试复读
