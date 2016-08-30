using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicBeePlugin.Extensions
{
    public static class SongFileExtensions
    {
        public static bool WriteTag(this SongFile source, SortCustomTag condition, string value)
        {
            if (!condition.Enabled) return false;

            if (Config.Instance.DontOverwrite)
            {
                string newTagValue = source[condition.Name]; // ソート元のタグの取得
                string oldTagValue = source[condition.SortTag.ToString()];

                // ソート元のタグとの一致判定
                // 一致しなかった場合はソートタグにも値が含まれていると見做して中断
                if (newTagValue != oldTagValue) return false;
            }
            source[condition.Name] = value;
            return true;
        }
    }
}
