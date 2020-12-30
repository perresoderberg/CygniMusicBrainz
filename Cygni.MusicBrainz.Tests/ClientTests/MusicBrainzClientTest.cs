using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cygni.MusicBrainz.Facade;
using Cygni.MusicBrainz.Models.Models;
using Newtonsoft.Json;
using NUnit;
using NUnit.Framework;

namespace Cygni.MusicBrainz.Tests.FacadeTests
{
    [TestFixture]
    class MusicBrainzClientTest
    {
        string musicBrainzBaseUrl = "http://musicbrainz.org";
        string requesturl = "/ws/2/artist";
        string mbId = "5b11f4ce-a62d-471e-81fc-a69a8278c7da";
        string wikipediaMbId = "31e7b30b-f960-408f-908b-c8e277308eab";
        string parameters = "fmt=json&inc=url-rels+release-groups";

        string wikidataIdentifier = "Q11649";
    //    [SetUp]
    //    public void SetUp()
    //    {

    //    }

    //    [Test]
    //    public async Task CallToMusicBrainzClient_HasReturnValue()
    //    {
    //        MusicBrainzClient client = new MusicBrainzClient(musicBrainzBaseUrl, requesturl, parameters);

    //        var ret = await client.GetArtistByIdAsync(mbId);

    //        Assert.IsNotNull(ret);
    //        Assert.IsTrue(ret.Length > 0);
    //    }

    //    [Test]
    //    public async Task CallToMusicBrainzClient_ResponseHasRelationsWikiData()
    //    {
    //        MusicBrainzClient client = new MusicBrainzClient(musicBrainzBaseUrl, requesturl, parameters);

    //        var ret = await client.GetArtistByIdAsync(mbId);
    //        ArtistDto artist = JsonConvert.DeserializeObject<ArtistDto>(ret);

    //        var UrlToWikiData = artist.Relations.FirstOrDefault(x => x.Type == "wikidata");
    //        var UrlToWikiPedia = artist.Relations.FirstOrDefault(x => x.Type == "wikipedia");

            
    //        var listOfTitles = artist.ReleaseGroup.Where(x=>x.Type=="Album").ToList();


    //        List<MusicAlbum> musicAlbums = new List<MusicAlbum>();
    //        listOfTitles.ForEach(x => 
    //        {
    //            MusicAlbum mmm = new MusicAlbum() { CoverArtId=x.CoverArtId, Title = x.Title, ImageUrls = null };
    //        });




    //        Assert.IsNull(UrlToWikiPedia);
    //        Assert.IsNotNull(UrlToWikiData);
    //        Assert.IsNotNull(UrlToWikiData.Url);
    //        string wikidataID = UrlToWikiData.Url.Resource.ToString().Split('/').LastOrDefault<string>();


    //        Assert.IsFalse(string.IsNullOrWhiteSpace(wikidataID));
    //    }
    //    [Test]
    //    public async Task CallToMusicBrainzClient_ResponseHasRelationsWikipedia()
    //    {
    //        MusicBrainzClient client = new MusicBrainzClient(musicBrainzBaseUrl, requesturl, parameters);

    //        var ret = await client.GetArtistByIdAsync(wikipediaMbId);
    //        ArtistDto artist = JsonConvert.DeserializeObject<ArtistDto>(ret);

    //        var UrlToWikiData = artist.Relations.FirstOrDefault(x => x.Type == "wikidata");
    //        var UrlToWikiPedia = artist.Relations.FirstOrDefault(x => x.Type == "wikipedia");

    //        Assert.IsNotNull(UrlToWikiPedia);
    //        Assert.IsNotNull(UrlToWikiData);
    //        Assert.IsNotNull(UrlToWikiData.Url);
    //        string wikipediaTitle = UrlToWikiPedia.Url.Resource.ToString().Split('/').LastOrDefault<string>();
    //        string wikidataID = UrlToWikiData.Url.Resource.ToString().Split('/').LastOrDefault<string>();


    //        Assert.IsFalse(string.IsNullOrWhiteSpace(wikipediaTitle));
    //        Assert.IsFalse(string.IsNullOrWhiteSpace(wikidataID));
    //    }
    }
}
