namespace ConsoleApp
{
    using cqhttp.WebSocketReverse.NETCore;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static readonly BlockingCollection<List<Tuple<ConsoleColor, ConsoleColor, string>>> blockingCollection = new BlockingCollection<List<Tuple<ConsoleColor, ConsoleColor, string>>>();
        static ConcurrentDictionary<string, Tuple<DateTime, DateTime, int>> messageRepeatTime = new ConcurrentDictionary<string, Tuple<DateTime, DateTime, int>>();
        static void Main(string[] args)
        {

            Console.WindowWidth = 70;
            Console.BufferWidth = 70;
            Console.Title = "Example";
            Console.WriteLine("打开酷Q应用窗口，点击五次右下角的版本号以启用压力测试,按下任意键开始");
            Console.ReadLine();

            int countReceive = 0;
            int countReply = 0;
            int lastCountReceive = 0;
            int lastCountReply = 0;
            int highCountReceive = 0;
            int highCountReply = 0;
            WebSocketServer wss = new WebSocketServer("ws://0.0.0.0:8889");

            CqHttpParse parse = new CqHttpParse(CqHttpApi.SetResult);
            CqHttpApi.Timeout = TimeSpan.FromSeconds(10);


            wss.OnAuthorizationAsync += async (s, e) =>
            {
                await Task.Run(() =>
                {
                    if (e.AuthCode == "Token cqhttp")
                    {
                        Debug.WriteLine(e.Connection.WebSocketConnectionInfo.ClientIpAddress);
                        e.Allow();
                    }
                });
            };

            wss.OnReceiveMessageAsync += async (s, e) =>
            {
                await parse.Parse(s, e);
            };

            parse.OnPrivateMessageAsync += async (n, b) =>
            {
                messageRepeatTime.AddOrUpdate(b.Message, Tuple.Create(DateTime.Now, DateTime.Now, 1), (m, i) =>
                {
                    return Tuple.Create(i.Item1, DateTime.Now, i.Item3 + 1);
                });
                List<Tuple<ConsoleColor, ConsoleColor, string>> currentReceive = new List<Tuple<ConsoleColor, ConsoleColor, string>>();

                Interlocked.Increment(ref countReceive);
                currentReceive.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.DarkBlue, $"{Environment.NewLine}{DateTime.Now.ToString("hh:mm:ss:fff")}\t"));
                currentReceive.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.Gray, $"R:{countReceive}\tW:{countReply}\t"));
                currentReceive.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, $"["));
                currentReceive.Add(Tuple.Create(ConsoleColor.DarkBlue, ConsoleColor.Yellow, $"接收"));
                currentReceive.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, $"]"));
                currentReceive.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, $"{b.Source.ReceivedDate.ToString("hh:MM:ss")}\t"));
                currentReceive.Add(Tuple.Create(ConsoleColor.White, ConsoleColor.Black, $"{b.Message}"));
                currentReceive.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.Yellow, $"({b.MessageId})"));
                blockingCollection.Add(currentReceive);

                await b.Source.Reply(b.Message);

                Interlocked.Increment(ref countReply);
                List<Tuple<ConsoleColor, ConsoleColor, string>> currentReply = new List<Tuple<ConsoleColor, ConsoleColor, string>>();
                currentReply.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.DarkBlue, $"{Environment.NewLine}{DateTime.Now.ToString("hh:mm:ss:fff")}\t"));
                currentReply.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.Gray, $"R:{countReceive}\tW:{countReply}\t"));
                currentReply.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, $"["));
                currentReply.Add(Tuple.Create(ConsoleColor.DarkGreen, ConsoleColor.Yellow, $"回复"));
                currentReply.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, $"]"));
                currentReply.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, $"{b.Source.ReceivedDate.ToString("hh:MM:ss")}\t"));
                currentReply.Add(Tuple.Create(ConsoleColor.White, ConsoleColor.Black, $"{b.Message}"));
                currentReply.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.Yellow, $"({b.MessageId})"));
                blockingCollection.Add(currentReply);
            };

            Task.Factory.StartNew(async () =>
            {
                int second = 5;
                int count = 0;
                while (true)
                {
                    int countReceivePerSec = (countReceive - lastCountReceive) / second;
                    int countReplyPerSec = (countReply - lastCountReply) / second;
                    highCountReceive = Math.Max(highCountReceive, countReceivePerSec);
                    highCountReply = Math.Max(highCountReply, countReplyPerSec);
                    int avgReceivePerSec = count == 0 ? 0 : countReceive / (second * count);
                    int avgReplyPerSec = count == 0 ? 0 : countReply / (second * count);

                    List<Tuple<ConsoleColor, ConsoleColor, string>> info = new List<Tuple<ConsoleColor, ConsoleColor, string>>();
                    info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                    info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                        $"╔═══════════════════════════════════════════════════════╗ "));
                    info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                    info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                        $"║\t\t      统计({second}秒一次)  \t\t\t║ "));
                    info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                    info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                        $"║\t\t经过时间:{second * count}秒\t内存大小:{Process.GetCurrentProcess().PrivateMemorySize64.ToString("N0")}\t║ "));
                    info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                    info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow, $"║\t\t\t\t接收\t回复\t\t║ "));
                    info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                    info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                        $"║\t\t总计处理:\t{countReceive}\t{countReply}\t\t║ "));
                    info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                    info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                        $"║\t\t期间每秒:\t{countReceivePerSec}\t{countReplyPerSec}\t\t║ "));
                    info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                    info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                        $"║\t\t总计平均:\t{avgReceivePerSec}\t{avgReplyPerSec}\t\t║ "));
                    info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                    info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                        $"║\t\t最高期间每秒:\t{highCountReceive}\t{highCountReply}\t\t║ "));

                    if (messageRepeatTime.Count > 0)
                    {
                        info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                        info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                            $"║ ﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉║ "));
                        info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                        info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                            $"║\t\t      消息统计\t\t\t\t║ "));
                        info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                        info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                            $"║ ﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍﹍║ "));
                    }

                    foreach (var m in messageRepeatTime)
                    {
                        info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                        info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                            $"║\t\t\t\"{m.Key}\"\t\t\t║ "));
                        info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                        info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                            $"║\t\t{(m.Value.Item2 - m.Value.Item1).TotalSeconds}秒 间共收到了{m.Value.Item3}次\t\t║ "));
                    }
                    info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));
                    info.Add(Tuple.Create(ConsoleColor.DarkMagenta, ConsoleColor.Yellow,
                        $"╚═══════════════════════════════════════════════════════╝ "));
                    info.Add(Tuple.Create(ConsoleColor.Black, ConsoleColor.White, Environment.NewLine));

                    blockingCollection.Add(info);
                    lastCountReceive = countReceive;
                    lastCountReply = countReceive;
                    Interlocked.Increment(ref count);
                    await Task.Delay(TimeSpan.FromSeconds(second));
                }
            });

            Task.Factory.StartNew(async () =>
            {
                try
                {
                    foreach (var b in blockingCollection.GetConsumingEnumerable())
                    {

                        foreach (var item in b)
                        {
                            Console.BackgroundColor = item.Item1;
                            Console.ForegroundColor = item.Item2;
                            await Console.Out.WriteAsync(item.Item3);
                        }
                    }
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteAsync(ex.ToString());
                }
            });

            Console.ReadLine();
        }
    }
}
