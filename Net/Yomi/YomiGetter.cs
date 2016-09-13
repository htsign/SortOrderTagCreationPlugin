using System;
using System.Threading.Tasks;

namespace MusicBeePlugin.Net.Yomi
{
    public abstract class YomiGetter
    {
        public const string Separator = "[][][]";

        public abstract Task<string> GetYomiAsync(string query);

        public static YomiGetter Create(APIEngine engine)
        {
            switch (engine)
            {
                case APIEngine.Yahoo:   return new YahooYomiGetter();
                case APIEngine.Yomitan: return new YomitanYomiGetter();
                default:
                    throw new ArgumentException($"不正な{nameof(APIEngine)}が渡されました。", nameof(engine));
            }
        }
    }
}
