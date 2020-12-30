using Newtonsoft.Json;

namespace Cygni.MusicBrainz.Models.DataModel
{
    public class ReleaseGroup
    {
        [JsonProperty("id")] public string CoverArtId { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("primary-type")] public string Type { get; set; }
        
    }
}
