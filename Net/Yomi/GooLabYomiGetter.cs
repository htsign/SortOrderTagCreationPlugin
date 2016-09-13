using System;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;

namespace MusicBeePlugin.Net.Yomi
{
    public class GooLabYomiGetter : YomiGetter
    {
        private const string AppID = "92551a83656d8ea869f8a0f001c3addc098775be7236cfe71cc02c56e618dcaa";

        public override async Task<string> GetYomiAsync(string query)
        {
            string requestUrl = "https://labs.goo.ne.jp/api/hiragana";
            Guid guid = Guid.NewGuid();

            var wc = new WebClientEx();
            return await wc.UploadValuesTaskAsync(requestUrl, new NameValueCollection {
                { "app_id"     , AppID           },
                { "request_id" , guid.ToString() },
                { "sentence"   , query           },
                { "output_type", "hiragana"      },
            })
            .ContinueWith(t =>
            {
                var serializer = new DataContractJsonSerializer(typeof(GooLabHiraganaJson));
                GooLabHiraganaJson json;

                using (var ms = new MemoryStream(t.Result))
                {
                    json = (GooLabHiraganaJson)serializer.ReadObject(ms);
                }
                if (json.request_id != guid.ToString()) return null;

                string result = json.converted;
                return string.Join("", result.Split(' '));
            });
        }
    }

    [DataContract]
    class GooLabHiraganaJson
    {
        [DataMember]
        public string request_id  { get; set; }
        [DataMember]
        public string output_type { get; set; }
        [DataMember]
        public string converted   { get; set; }
    }
}
