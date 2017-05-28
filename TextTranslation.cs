using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MusicBeePlugin
{
    public static class TextTranslation
    {
        public static readonly string PrefixBrackets = "[[[";
        public static readonly string SuffixBrackets = "]]]";

        /// <summary>
        /// カタカナ、半角カナをひらがなに置き換える。
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="temporary"></param>
        /// <returns></returns>
        public static string Translate(string sentence)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < sentence.Length; i++)
            {
                char hiragana;

                // 次の文字が濁点、または半濁点の場合は結合する
                if (i + 1 < sentence.Length &&
                    (sentence[i + 1] == 'ﾞ' || sentence[i + 1] == 'ﾟ'))
                {
                    string halfKana = string.Concat(sentence[i], sentence[i + 1]);
                    hiragana = CorrespondenceTable.GetHiragana(halfKana);
                    if (hiragana != '\0')
                    {
                        sb.Append(hiragana);
                        i++;
                    }
                    else
                    {
                        // 試してダメであれば、chars[i]は1文字で完結するカタカナ、または半角カナの可能性がある
                        hiragana = CorrespondenceTable.GetHiragana(sentence[i]);
                        if (hiragana != '\0')
                        {
                            sb.Append(hiragana);
                        }
                        else
                        {
                            // 試してダメであれば、chars[i]は1文字で完結する半角カナの可能性がある
                            hiragana = CorrespondenceTable.GetHiragana(sentence[i].ToString());
                            if (hiragana != '\0')
                            {
                                sb.Append(hiragana);
                            }
                            else
                            {
                                sb.Append(sentence[i]);
                            }
                        }
                    }
                }
                else
                {
                    hiragana = CorrespondenceTable.GetHiragana(sentence[i]);
                    if (hiragana != '\0')
                    {
                        sb.Append(hiragana);
                    }
                    else
                    {
                        hiragana = CorrespondenceTable.GetHiragana(sentence[i].ToString());
                        if (hiragana != '\0')
                        {
                            sb.Append(hiragana);
                        }
                        else
                        {
                            sb.Append(sentence[i]);
                        }
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// アルファベットと記号を変換させないため（主によみたん対策）に一時的に文字列を置き換えます。
        /// また一部機種依存文字でY!APIがエラーを起こすため退避させます。
        /// </summary>
        /// <param name="sentence">変換する対象文字列</param>
        /// <param name="options">置き換えられた部位の各文字列を格納した配列</param>
        /// <see cref="ChangeTemporaryToOrigin"/>
        public static void ChangeOriginToTemporary(ref string sentence, out string[] options)
        {
            var outOfKanjis = new Regex(Config.Instance.ReplacesRegExp);
            var outOptions = new List<string>();

            for (int i = 0; ; ++i)
            {
                Match m = outOfKanjis.Match(sentence);
                if (!m.Success) break;
                sentence = outOfKanjis.Replace(sentence, $"{PrefixBrackets}{i}{SuffixBrackets}", 1);
                outOptions.Add(m.Value);
            }

            options = outOptions.ToArray();
        }

        /// <summary>
        /// 置き換えられた文字列を元の文字列に戻します。
        /// </summary>
        /// <param name="sentence">変換する対象文字列</param>
        /// <param name="options">置き換えられていた部位の各文字列を格納した配列</param>
        /// <see cref="ChangeOriginToTemporary"/>
        public static void ChangeTemporaryToOrigin(ref string sentence, string[] options)
        {
            for (int i = 0; i < options.Length; ++i)
            {
                string searchString = $"{PrefixBrackets}{i}{SuffixBrackets}";
                if (!sentence.Contains(searchString)) break;
                sentence = sentence.Replace(searchString, options[i]);
            }
        }
    }

    static class CorrespondenceTable
    {
        private static KanaRelation[] relations = new List<KanaRelation>
        {
            { 'あ', 'ア', "ｱ" },
            { 'い', 'イ', "ｲ" },
            { 'う', 'ウ', "ｳ" },
            { 'え', 'エ', "ｴ" },
            { 'お', 'オ', "ｵ" },

            { 'か', 'カ', "ｶ" },
            { 'き', 'キ', "ｷ" },
            { 'く', 'ク', "ｸ" },
            { 'け', 'ケ', "ｹ" },
            { 'こ', 'コ', "ｺ" },

            { 'さ', 'サ', "ｻ" },
            { 'し', 'シ', "ｼ" },
            { 'す', 'ス', "ｽ" },
            { 'せ', 'セ', "ｾ" },
            { 'そ', 'ソ', "ｿ" },

            { 'た', 'タ', "ﾀ" },
            { 'ち', 'チ', "ﾁ" },
            { 'つ', 'ツ', "ﾂ" },
            { 'て', 'テ', "ﾃ" },
            { 'と', 'ト', "ﾄ" },

            { 'な', 'ナ', "ﾅ" },
            { 'に', 'ニ', "ﾆ" },
            { 'ぬ', 'ヌ', "ﾇ" },
            { 'ね', 'ネ', "ﾈ" },
            { 'の', 'ノ', "ﾉ" },

            { 'は', 'ハ', "ﾊ" },
            { 'ひ', 'ヒ', "ﾋ" },
            { 'ふ', 'フ', "ﾌ" },
            { 'へ', 'ヘ', "ﾍ" },
            { 'ほ', 'ホ', "ﾎ" },

            { 'ま', 'マ', "ﾏ" },
            { 'み', 'ミ', "ﾐ" },
            { 'む', 'ム', "ﾑ" },
            { 'め', 'メ', "ﾒ" },
            { 'も', 'モ', "ﾓ" },

            { 'や', 'ヤ', "ﾔ" },
            { 'ゆ', 'ユ', "ﾕ" },
            { 'よ', 'ヨ', "ﾖ" },

            { 'ら', 'ラ', "ﾗ" },
            { 'り', 'リ', "ﾘ" },
            { 'る', 'ル', "ﾙ" },
            { 'れ', 'レ', "ﾚ" },
            { 'ろ', 'ロ', "ﾛ" },

            { 'わ', 'ワ', "ﾜ" },
            { 'を', 'ヲ', "ｦ" },
            { 'ん', 'ン', "ﾝ" },

            { 'が', 'ガ', "ｶﾞ" },
            { 'ぎ', 'ギ', "ｷﾞ" },
            { 'ぐ', 'グ', "ｸﾞ" },
            { 'げ', 'ゲ', "ｹﾞ" },
            { 'ご', 'ゴ', "ｺﾞ" },

            { 'ざ', 'ザ', "ｻﾞ" },
            { 'じ', 'ジ', "ｼﾞ" },
            { 'ず', 'ズ', "ｽﾞ" },
            { 'ぜ', 'ゼ', "ｾﾞ" },
            { 'ぞ', 'ゾ', "ｿﾞ" },

            { 'だ', 'ダ', "ﾀﾞ" },
            { 'ぢ', 'ヂ', "ﾁﾞ" },
            { 'づ', 'ヅ', "ﾂﾞ" },
            { 'で', 'デ', "ﾃﾞ" },
            { 'ど', 'ド', "ﾄﾞ" },

            { 'ば', 'バ', "ﾊﾞ" },
            { 'び', 'ビ', "ﾋﾞ" },
            { 'ぶ', 'ブ', "ﾌﾞ" },
            { 'べ', 'ベ', "ﾍﾞ" },
            { 'ぼ', 'ボ', "ﾎﾞ" },

            { 'ぱ', 'パ', "ﾊﾟ" },
            { 'ぴ', 'ピ', "ﾋﾟ" },
            { 'ぷ', 'プ', "ﾌﾟ" },
            { 'ぺ', 'ペ', "ﾍﾟ" },
            { 'ぽ', 'ポ', "ﾎﾟ" },

            { 'ぁ', 'ァ', "ｧ" },
            { 'ぃ', 'ィ', "ｨ" },
            { 'ぅ', 'ゥ', "ｩ" },
            { 'ぇ', 'ェ', "ｪ" },
            { 'ぉ', 'ォ', "ｫ" },

            { 'っ', 'ッ', "ｯ" },
            { 'ゃ', 'ャ', "ｬ" },
            { 'ゅ', 'ュ', "ｭ" },
            { 'ょ', 'ョ', "ｮ" },
            { 'ゎ', 'ヮ', string.Empty },

            { 'ゐ', 'ヰ', string.Empty },
            { 'ゑ', 'ゑ', string.Empty },
            { 'ゔ', 'ヴ', "ｳﾞ" },
        }
        .ToArray();

        public static char GetHiragana(char katakana)
        {
            int index = Array.IndexOf(relations.Select(r => r.Katakana).ToArray(), katakana);
            return (index != -1) ? relations[index].Hiragana : '\0';
        }

        public static char GetHiragana(string halfKana)
        {
            int index = Array.IndexOf(relations.Select(r => r.HalfKana).ToArray(), halfKana);
            return (index != -1) ? relations[index].Hiragana : '\0';
        }
    }

    public struct KanaRelation
    {
        public char   Hiragana { get; }
        public char   Katakana { get; }
        public string HalfKana { get; }

        public KanaRelation(char hiragana, char katakana, string halfKana)
            : this()
        {
            Hiragana = hiragana;
            Katakana = katakana;
            HalfKana = halfKana;
        }
    }

    public static class KanaRelationCollectionExtensions
    {
        public static void Add(this ICollection<KanaRelation> self, char hiragana, char katakana, string halfKana)
        {
            self.Add(new KanaRelation(hiragana, katakana, halfKana));
        }
    }
}
