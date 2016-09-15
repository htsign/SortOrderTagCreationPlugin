using System;
using System.Threading.Tasks;

namespace MusicBeePlugin.Net.Yomi
{
    public abstract class YomiGetterBase
    {
        public const string Separator = "[][][]";

        public abstract Task<string> GetYomiAsync(string query);

        public static YomiGetterBase Create(APIEngine engine)
        {
            switch (engine)
            {
                case APIEngine.Yahoo:   return new YahooYomiGetter();
                case APIEngine.Yomitan: return new YomitanYomiGetter();
                case APIEngine.GooLab:  return new GooLabYomiGetter();
                default:
                    throw new ArgumentException($"不正な{nameof(APIEngine)}が渡されました。", nameof(engine));
            }
        }
    }
}
