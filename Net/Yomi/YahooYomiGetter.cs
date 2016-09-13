using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace MusicBeePlugin.Net.Yomi
{
    public class YahooYomiGetter : YomiGetter
    {
        private const string AppID = "dj0zaiZpPUdSNEQ3UjlqRTYwcSZzPWNvbnN1bWVyc2VjcmV0Jng9Yjc-";

        public override async Task<string> GetYomiAsync(string query)
        {
            string sentence = HttpUtility.UrlEncode(query);
            string requestUrl = "http:" + $"//jlp.yahooapis.jp/FuriganaService/V1/furigana?appid={AppID}&grade=1&sentence={sentence}";

            var wc = new WebClientEx();
            return await wc.DownloadDataTaskAsync(requestUrl)
                .ContinueWith(t => Encoding.UTF8.GetString(t.Result))
                .ContinueWith(t =>
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(t.Result);

                    // エラーが発生していた場合は Error 要素が出現する
                    if (xmlDoc["Error"] != null)
                    {
                        return null;
                    }
                    XmlElement wordsRoot = (XmlElement)xmlDoc.GetElementsByTagName("WordList")[0];

                    var sb = new StringBuilder();
                    foreach (XmlElement node in wordsRoot.ChildNodes.OfType<XmlElement>())
                    {
                        XmlElement furigana = node["Furigana"];
                        if (furigana != null)
                        {
                            sb.Append(furigana.InnerText);
                        }
                        else
                        {
                            XmlElement surface = node["Surface"];
                            if (surface != null)
                            {
                                sb.Append(surface.InnerText);
                            }
                            else
                            {
                                sb.Append(string.Empty);
                            }
                        }
                    }
                    return sb.ToString();
                });
        }
    }
}
