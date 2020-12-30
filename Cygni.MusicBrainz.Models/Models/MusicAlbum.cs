using System;
using System.Collections.Generic;
using System.Text;

namespace Cygni.MusicBrainz.Models.Models
{
    public class MusicAlbumModel
    {
        public string Title { get; set; }
        public string CoverArtId { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
