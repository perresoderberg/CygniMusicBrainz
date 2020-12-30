using System;
using System.Collections.Generic;
using System.Text;

namespace Cygni.MusicBrainz.Models.Models
{
    public class ArtistModel
    {
        public string MbId { get; set; }
        public string ArtistName { get; set; }

        public string Description { get; set; }

        public List<MusicAlbumModel> Albums { get; set; }
    }
}
