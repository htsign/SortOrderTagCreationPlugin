using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MusicBeePlugin.Net.Yomi
{
    public class YomitanYomiGetter : YomiGetter
    {
        public override async Task<string> GetYomiAsync(string query)
        {
            string sentence = HttpUtility.UrlEncode(query);
            string requestUrl = "http:" + $"//yomi-tan.jp/api/yomi.php?n=1&t={sentence}";

            var wc = new WebClientEx();
            wc.Headers[HttpRequestHeader.UserAgent] = nameof(YomitanYomiGetter);

            return await wc.DownloadDataTaskAsync(requestUrl)
                .ContinueWith(t => Encoding.UTF8.GetString(t.Result));
        }
    }
}
