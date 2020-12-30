using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cygni.MusicBrainz.Models.DataModel
{
    public class Artist
    {
        [JsonProperty("relations")] public List<Relation> Relations { get; set; }
        [JsonProperty("release-groups")] public List<ReleaseGroup> ReleaseGroup { get; set; }
    }
}
