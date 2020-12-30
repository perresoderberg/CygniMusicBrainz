using Cygni.MusicBrainz.Models.DataModel;
using Cygni.MusicBrainz.Models.Models;
using System.Threading.Tasks;

namespace Cygni.MusicBrainz.BL.MusicBrainzWikiService
{
    public interface IMusicBrainzWikiService
    {
        Task<ArtistModel> GetArtistInfo(string mbId);
        Task<MusicAlbumModel> GetAlbumAsync(ReleaseGroup x);
}
}
