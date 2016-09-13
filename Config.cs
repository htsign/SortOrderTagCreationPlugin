using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using static MusicBeePlugin.Plugin;

namespace MusicBeePlugin
{
    public abstract class ConfigBase
    {
        /// <summary>
        /// デフォルト値を読み込みます。
        /// </summary>
        public abstract void LoadDefault();

        /// <summary>
        /// 指定されたパスに設定をXMLシリアライズして保存します。
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            var serializer = new XmlSerializer(this.GetType());
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, this);
            }
        }

        /// <summary>
        /// 指定されたパスからXMLを取得し、デシリアライズして設定を読み込みます。
        /// </summary>
        /// <param name="path"></param>
        public void Load(string path)
        {
            if (!File.Exists(path))
            {
                LoadDefault();
                return;
            }

            var serializer = new XmlSerializer(this.GetType());
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    var config = (ConfigBase)serializer.Deserialize(fs);

                    PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    foreach (PropertyInfo prop in properties)
                    {
                        object newValue = prop.GetValue(config, null);
                        prop.SetValue(this, newValue, null);
                    }
                }
                catch (InvalidOperationException)
                {
                    LoadDefault();
                }
            }
        }
    }

    [Serializable]
    public class Config
        : ConfigBase
    {
        private Config() { }
        private static Config instance = new Config();
        public static Config Instance => instance;

        #region public properties
        public SortCustomTag SortArtist      { get; set; } = new SortCustomTag(true,  MetaDataType.Custom1);

        public SortCustomTag SortAlbumArtist { get; set; } = new SortCustomTag(true,  MetaDataType.Custom2);

        public SortCustomTag SortTitle       { get; set; } = new SortCustomTag(false, MetaDataType.Custom3);

        public SortCustomTag SortAlbum       { get; set; } = new SortCustomTag(false, MetaDataType.Custom4);

        public SortCustomTag SortComposer    { get; set; } = new SortCustomTag(false, MetaDataType.Custom5);

        public bool AddSortOrderTagsWhenLibraryChanged { get; set; } = false;

        public bool DontOverwrite { get; set; } = false;

        public APIEngine APIEngine { get; set; } = APIEngine.Yahoo;

        private const string DefaultMatchesRegExp = @"[\u2E80-\u2FDF\u3005\u3007\u3021-\u3029\u3038-\u303B\u3400-\u4DBF\u4E00-\u9FFF\uF900-\uFAFF\u20000-\u2FFFF]";
        private string matchesRegExp = DefaultMatchesRegExp;
        public  string MatchesRegExp
        {
            get { return string.IsNullOrEmpty(matchesRegExp) ? DefaultMatchesRegExp : matchesRegExp; }
            set { this.matchesRegExp = value; }
        }

        private const string DefaultReplacesRegExp = @"[A-Za-zゔヵヶ\s" +
            RegexCharactors.Latin1Supplement +
            RegexCharactors.ExtendedLatin +
            RegexCharactors.ExtendedIPA +
            RegexCharactors.GeometricDesign +
            RegexCharactors.OtherSymbols +
            @"\W-[\[\]]]+";
        private string replacesRegExp = DefaultReplacesRegExp;
        public  string ReplacesRegExp
        {
            get { return string.IsNullOrEmpty(replacesRegExp) ? DefaultReplacesRegExp : replacesRegExp; }
            set { this.replacesRegExp = value; }
        }

        public WordKanaCollection WordKanaCollection { get; set; } = new WordKanaCollection();
        #endregion

        public static string GetEngineName(APIEngine engine)
        {
            switch (engine)
            {
                case APIEngine.Yahoo:
                    return "Yahoo!Japan";
                case APIEngine.Yomitan:
                    return "よみたん";
                case APIEngine.GooLab:
                    return "gooラボ";
            }
            return null;
        }

        public override void LoadDefault()
        {
            instance = new Config();
        }
    }

    public enum APIEngine
    {
        Yahoo,
        Yomitan,
        GooLab,
    }

    [Serializable]
    public struct SortCustomTag
    {
        ///<summary>ソートタグが有効かどうか</summary>
        [XmlAttribute]
        public bool Enabled { get; set; }
        ///<summary>対応するソートタグ</summary>
        [XmlText]
        public MetaDataType SortTag { get; set; }
        
        ///<summary>対応するソートタグのタグタイプ</summary>
        [XmlIgnore]
        public MetaDataType TagType
        {
            get
            {
                if      (Equals(Config.Instance.SortArtist))      return MetaDataType.Artist;
                else if (Equals(Config.Instance.SortAlbumArtist)) return MetaDataType.AlbumArtist;
                else if (Equals(Config.Instance.SortTitle))       return MetaDataType.TrackTitle;
                else if (Equals(Config.Instance.SortAlbum))       return MetaDataType.Album;
                else if (Equals(Config.Instance.SortComposer))    return MetaDataType.Composer;

                throw new IndexOutOfRangeException();
            }
        }

        public SortCustomTag(bool enabled, MetaDataType sortTag) : this()
        {
            Enabled = enabled;
            SortTag = sortTag;
        }
    }
}
