using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MusicBeePlugin
{
    public sealed class TextTranslation
    {
        private static readonly string PrefixBracket  = "[[[";
        private static readonly string PostfixBracket = "]]]";

        /// <summary>
        /// カタカナ、半角カナをひらがなに置き換える。
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="temporary"></param>
        /// <returns></returns>
        public static string Translate(string sentence)
        {
            var cTable = new CorrespondenceTable();

            var sb = new StringBuilder();
            List<char> chars = sentence.ToCharArray().ToList();
            for (int i = 0; i < chars.Count; i++)
            {
                // 次の文字が濁点、または半濁点の場合は結合する
                if (i + 1 < chars.Count &&
                    (chars[i + 1] == 'ﾞ' || chars[i + 1] == 'ﾟ'))
                {
                    string halfKana = string.Concat(chars[i], chars[i + 1]);
                    char   hiragana = cTable.GetHiragana(halfKana);
                    if (hiragana != '\0')
                    {
                        sb.Append(hiragana);
                        i++;
                    }
                    else
                    {
                        // 試してダメであれば、chars[i]は1文字で完結するカタカナ、または半角カナの可能性がある
                        hiragana = cTable.GetHiragana(chars[i]);
                        if (hiragana != '\0')
                        {
                            sb.Append(hiragana);
                        }
                        else
                        {
                            // 試してダメであれば、chars[i]は1文字で完結する半角カナの可能性がある
                            hiragana = cTable.GetHiragana(chars[i].ToString());
                            if (hiragana != '\0')
                            {
                                sb.Append(hiragana);
                            }
                            else
                            {
                                sb.Append(chars[i]);
                            }
                        }
                    }
                }
                else
                {
                    char hiragana = cTable.GetHiragana(chars[i]);
                    if (hiragana != '\0')
                    {
                        sb.Append(hiragana);
                    }
                    else
                    {
                        hiragana = cTable.GetHiragana(chars[i].ToString());
                        if (hiragana != '\0')
                        {
                            sb.Append(hiragana);
                        }
                        else
                        {
                            sb.Append(chars[i]);
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
            int count = 0;

            while (true)
            {
                Match m = outOfKanjis.Match(sentence);
                if (!m.Success) break;
                sentence = outOfKanjis.Replace(sentence, PrefixBracket + count.ToString() + PostfixBracket, 1);
                outOptions.Add(m.Value);

                count++;
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
            int index;
            int count = 0;

            while (true)
            {
                index = sentence.IndexOf(PrefixBracket + count.ToString() + PostfixBracket);
                if (index == -1 || options.Length == count) break;
                sentence = sentence.Replace(PrefixBracket + count.ToString() + PostfixBracket, options[count]);

                count++;
            }
        }
    }

    class CorrespondenceTable
    {
        private List<KanaRelation> relations = new List<KanaRelation>
        {
            new KanaRelation('あ', 'ア', "ｱ"),
            new KanaRelation('い', 'イ', "ｲ"),
            new KanaRelation('う', 'ウ', "ｳ"),
            new KanaRelation('え', 'エ', "ｴ"),
            new KanaRelation('お', 'オ', "ｵ"),

            new KanaRelation('か', 'カ', "ｶ"),
            new KanaRelation('き', 'キ', "ｷ"),
            new KanaRelation('く', 'ク', "ｸ"),
            new KanaRelation('け', 'ケ', "ｹ"),
            new KanaRelation('こ', 'コ', "ｺ"),

            new KanaRelation('さ', 'サ', "ｻ"),
            new KanaRelation('し', 'シ', "ｼ"),
            new KanaRelation('す', 'ス', "ｽ"),
            new KanaRelation('せ', 'セ', "ｾ"),
            new KanaRelation('そ', 'ソ', "ｿ"),

            new KanaRelation('た', 'タ', "ﾀ"),
            new KanaRelation('ち', 'チ', "ﾁ"),
            new KanaRelation('つ', 'ツ', "ﾂ"),
            new KanaRelation('て', 'テ', "ﾃ"),
            new KanaRelation('と', 'ト', "ﾄ"),

            new KanaRelation('な', 'ナ', "ﾅ"),
            new KanaRelation('に', 'ニ', "ﾆ"),
            new KanaRelation('ぬ', 'ヌ', "ﾇ"),
            new KanaRelation('ね', 'ネ', "ﾈ"),
            new KanaRelation('の', 'ノ', "ﾉ"),

            new KanaRelation('は', 'ハ', "ﾊ"),
            new KanaRelation('ひ', 'ヒ', "ﾋ"),
            new KanaRelation('ふ', 'フ', "ﾌ"),
            new KanaRelation('へ', 'ヘ', "ﾍ"),
            new KanaRelation('ほ', 'ホ', "ﾎ"),

            new KanaRelation('ま', 'マ', "ﾏ"),
            new KanaRelation('み', 'ミ', "ﾐ"),
            new KanaRelation('む', 'ム', "ﾑ"),
            new KanaRelation('め', 'メ', "ﾒ"),
            new KanaRelation('も', 'モ', "ﾓ"),

            new KanaRelation('や', 'ヤ', "ﾔ"),
            new KanaRelation('ゆ', 'ユ', "ﾕ"),
            new KanaRelation('よ', 'ヨ', "ﾖ"),

            new KanaRelation('ら', 'ラ', "ﾗ"),
            new KanaRelation('り', 'リ', "ﾘ"),
            new KanaRelation('る', 'ル', "ﾙ"),
            new KanaRelation('れ', 'レ', "ﾚ"),
            new KanaRelation('ろ', 'ロ', "ﾛ"),

            new KanaRelation('わ', 'ワ', "ﾜ"),
            new KanaRelation('を', 'ヲ', "ｦ"),
            new KanaRelation('ん', 'ン', "ﾝ"),

            new KanaRelation('が', 'ガ', "ｶﾞ"),
            new KanaRelation('ぎ', 'ギ', "ｷﾞ"),
            new KanaRelation('ぐ', 'グ', "ｸﾞ"),
            new KanaRelation('げ', 'ゲ', "ｹﾞ"),
            new KanaRelation('ご', 'ゴ', "ｺﾞ"),

            new KanaRelation('ざ', 'ザ', "ｻﾞ"),
            new KanaRelation('じ', 'ジ', "ｼﾞ"),
            new KanaRelation('ず', 'ズ', "ｽﾞ"),
            new KanaRelation('ぜ', 'ゼ', "ｾﾞ"),
            new KanaRelation('ぞ', 'ゾ', "ｿﾞ"),

            new KanaRelation('だ', 'ダ', "ﾀﾞ"),
            new KanaRelation('ぢ', 'ヂ', "ﾁﾞ"),
            new KanaRelation('づ', 'ヅ', "ﾂﾞ"),
            new KanaRelation('で', 'デ', "ﾃﾞ"),
            new KanaRelation('ど', 'ド', "ﾄﾞ"),

            new KanaRelation('ば', 'バ', "ﾊﾞ"),
            new KanaRelation('び', 'ビ', "ﾋﾞ"),
            new KanaRelation('ぶ', 'ブ', "ﾌﾞ"),
            new KanaRelation('べ', 'ベ', "ﾍﾞ"),
            new KanaRelation('ぼ', 'ボ', "ﾎﾞ"),

            new KanaRelation('ぱ', 'パ', "ﾊﾟ"),
            new KanaRelation('ぴ', 'ピ', "ﾋﾟ"),
            new KanaRelation('ぷ', 'プ', "ﾌﾟ"),
            new KanaRelation('ぺ', 'ペ', "ﾍﾟ"),
            new KanaRelation('ぽ', 'ポ', "ﾎﾟ"),

            new KanaRelation('ぁ', 'ァ', "ｧ"),
            new KanaRelation('ぃ', 'ィ', "ｨ"),
            new KanaRelation('ぅ', 'ゥ', "ｩ"),
            new KanaRelation('ぇ', 'ェ', "ｪ"),
            new KanaRelation('ぉ', 'ォ', "ｫ"),

            new KanaRelation('っ', 'ッ', "ｯ"),
            new KanaRelation('ゃ', 'ャ', "ｬ"),
            new KanaRelation('ゅ', 'ュ', "ｭ"),
            new KanaRelation('ょ', 'ョ', "ｮ"),
            new KanaRelation('ゎ', 'ヮ', string.Empty),

            new KanaRelation('ゐ', 'ヰ', string.Empty),
            new KanaRelation('ゑ', 'ゑ', string.Empty),
            new KanaRelation('ゔ', 'ヴ', "ｳﾞ"),
        };

        public char GetHiragana(char katakana)
        {
            int index = Array.IndexOf(relations.Select(r => r.Katakana).ToArray(), katakana);
            return (index != -1) ? relations[index].Hiragana : '\0';
        }

        public char GetHiragana(string halfKana)
        {
            int index = Array.IndexOf(relations.Select(r => r.HalfKana).ToArray(), halfKana);
            return (index != -1) ? relations[index].Hiragana : '\0';
        }
    }

    struct KanaRelation
    {
        public char   Hiragana { get; private set; }
        public char   Katakana { get; private set; }
        public string HalfKana { get; private set; }

        public KanaRelation(char hiragana, char katakana, string halfKana)
            : this()
        {
            Hiragana = hiragana;
            Katakana = katakana;
            HalfKana = halfKana;
        }
    }
}
