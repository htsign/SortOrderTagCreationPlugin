using System;
using System.Net;
using System.Threading.Tasks;

namespace MusicBeePlugin
{
    public class WebClientEx : WebClient
    {
        public string Referer = null;
        public CookieContainer CookieContainer { get; set; } = new CookieContainer();

        protected override WebRequest GetWebRequest(Uri address)
        {
            var req = base.GetWebRequest(address);

            if (req is HttpWebRequest)
            {
                (req as HttpWebRequest).CookieContainer = CookieContainer;
            }
            return req;
        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            var res = base.GetWebResponse(request);

            if (res is HttpWebResponse)
            {
                Referer = (res as HttpWebResponse).ResponseUri.AbsoluteUri;
            }
            return res;
        }

        // ref: http://www.atmarkit.co.jp/ait/articles/1109/30/news126_2.html
        public Task<string> DownloadStringTaskAsync(string uri)
        {
            var tcs = new TaskCompletionSource<string>();

            DownloadStringCompletedEventHandler handler = null;

            handler = (sender, e) =>
            {
                if (e.Cancelled) tcs.TrySetCanceled();
                else if (e.Error != null) tcs.TrySetException(e.Error);
                else tcs.TrySetResult(e.Result);
                DownloadStringCompleted -= handler;
            };

            DownloadStringCompleted += handler;
            DownloadStringAsync(new Uri(uri));

            return tcs.Task;
        }
    }
}
