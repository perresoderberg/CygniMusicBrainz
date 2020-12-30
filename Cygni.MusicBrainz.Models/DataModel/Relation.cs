using Newtonsoft.Json;

namespace Cygni.MusicBrainz.Models.DataModel
{
    public class Url
    {
        [JsonProperty("resource")] public string Resource { get; set; }
    }
    public class Relation
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")] public Url Url { get; set; }
    }
}
