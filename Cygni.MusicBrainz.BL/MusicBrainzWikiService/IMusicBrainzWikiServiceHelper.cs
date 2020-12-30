using Cygni.MusicBrainz.Facade;
using System.Collections.Generic;

namespace Cygni.MusicBrainz.BL.MusicBrainzWikiService
{
    public interface IMusicBrainzWikiServiceHelper
    {
        string GetWikipediaDescription(string wikipediaRet);
        List<string> GetCoverArtImages(string coverArtRet);
    }
}
