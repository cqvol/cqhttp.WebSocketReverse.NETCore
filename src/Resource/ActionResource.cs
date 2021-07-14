using cqhttp.WebSocketReverse.NETCore.Resource;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Resource
{
    public static class ActionResource
    {
        [Obsolete]
        /// <summary>
        /// 回调等待暂存
        /// </summary>
        public static readonly ConcurrentDictionary<string, TaskCompletionSource<ResponseResource>> Operations
            = new ConcurrentDictionary<string, TaskCompletionSource<ResponseResource>>();

        /// <summary>
        /// 响应主题
        /// </summary>
        public static readonly ISubject<Tuple<string, ResponseResource>, Tuple<string, ResponseResource>> CQHTTPSubject 
            = new Subject<Tuple<string, ResponseResource>>();
    }
}
