using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicBeePlugin.Net.Yomi
{
    using Extensions.Core;

    public class GooLabYomiGetter : YomiGetter
    {
        private const string AppID = "92551a83656d8ea869f8a0f001c3addc098775be7236cfe71cc02c56e618dcaa";

        public override async Task<string> GetYomiAsync(string query)
        {
            string requestUrl = "https://labs.goo.ne.jp/api/hiragana";
            Guid guid = Guid.NewGuid();
            var evacuations = new List<string>();

            var re = new Regex(@"\[\[\[(\d+)\]\]\]");
            for (int i = 0; re.IsMatch(query); ++i)
            {
                Match m = re.Match(query);
                string innerValue = m.Groups[1].Value;

                if (i == int.Parse(innerValue))
                {
                    evacuations.Add(m.Value);
                    query = re.Replace(query, Separator, 1);
                }
            }

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

                string result = json.converted.Split(' ').Join();
                for (int i = 0; i < evacuations.Count; i++)
                {
                    re = new Regex(@"\[\]\[\]\[\]");
                    result = re.Replace(result, evacuations[i], 1);
                }

                return result;
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
