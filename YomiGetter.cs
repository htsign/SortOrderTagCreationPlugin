using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Threading.Tasks;

namespace MusicBeePlugin
{
    public abstract class YomiGetter
    {
        public const string Separator = "[][][]";

        protected string Query { get; private set; }

        public abstract Task<string> GetYomiAsync();

        public static YomiGetter Create(APIEngine engine, string query)
        {
            switch (engine)
            {
                case APIEngine.Yahoo:   return new YahooYomiGetter   { Query = query };
                case APIEngine.Yomitan: return new YomitanYomiGetter { Query = query };
                default:
                    throw new ArgumentException("不正なAPIEngineが渡されました。", nameof(engine));
            }
        }
    }

    public class YahooYomiGetter
        : YomiGetter
    {
        private const string AppID = "dj0zaiZpPUdSNEQ3UjlqRTYwcSZzPWNvbnN1bWVyc2VjcmV0Jng9Yjc-";

        public override async Task<string> GetYomiAsync()
        {
            string sentence = HttpUtility.UrlEncode(Query);
            string requestUrl = $"http://jlp.yahooapis.jp/FuriganaService/V1/furigana?appid={AppID}&grade=1&sentence={sentence}";

            var wc = new WebClientEx();
            return await wc.DownloadStringTaskAsync(requestUrl)
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

    public class YomitanYomiGetter
        : YomiGetter
    {
        public override async Task<string> GetYomiAsync()
        {
            string sentence = HttpUtility.UrlEncode(Query);
            string requestUrl = $"http://yomi-tan.jp/api/yomi.php?n=1&t={sentence}";

            var wc = new WebClientEx();
            return await wc.DownloadStringTaskAsync(requestUrl);
        }
    }
}
