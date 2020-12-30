using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cygni.MusicBrainz.Facade;
using Cygni.MusicBrainz.Models.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Cygni.MusicBrainz.Tests.FacadeTests
{
    [TestFixture]
    class CoverArtClientTest
    {
        string baseurl = "http://coverartarchive.org";
        string requesturl = "/release-group";
        string mbId = "f1afec0b-26dd-3db5-9aa1-c91229a74a24";

        string musicBrainzBaseUrl = "http://musicbrainz.org";
        string musicBrainzparameters = "fmt=json&inc=url-rels+release-groups";

        //[SetUp]
        //public void SetUp()
        //{

        //}
        //// http://coverartarchive.org/release-group/1b022e01-4da6-387b-8658-8678046e4cef
        //[Test]
        //public async Task CallCoverArtClient_HasReturnValue()
        //{

        //    CoverArtArchiveClient client = new CoverArtArchiveClient();

        //    var coverArtRet = await client.GetCoverArtByIdAsync(mbId);
            
        //    List<string> images = new List<string>();

        //    try
        //    {
        //        IDictionary<string, JToken> Jsondata = JObject.Parse(coverArtRet);
        //        var imagesJson = Jsondata["images"];

        //        foreach (var item in Jsondata["images"].Children())
        //        {
        //            images.Add(item["image"].ToString());
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new JsonException("Unable to cast CoverArt Json Object " + ex.Message);
        //    }

        //    Assert.IsNotNull(coverArtRet);
        //    Assert.IsTrue(coverArtRet.Length > 0);
        //    Assert.IsTrue(images.Count > 0);
        //}
        //[Test]
        //public async Task CallCoverArtClient2_HasReturnValue()
        //{

        //    MusicBrainzClient client = new MusicBrainzClient(musicBrainzBaseUrl, requesturl, musicBrainzparameters);

        //    var ret = await client.GetArtistByIdAsync(mbId);
        //    ArtistDto artist = JsonConvert.DeserializeObject<ArtistDto>(ret);

        //    var UrlToWikiData = artist.Relations.FirstOrDefault(x => x.Type == "wikidata");
        //    var UrlToWikiPedia = artist.Relations.FirstOrDefault(x => x.Type == "wikipedia");


        //    var listOfTitles = artist.ReleaseGroup.Where(x => x.Type == "Album").ToList();


        //    List<MusicAlbum> musicAlbums = new List<MusicAlbum>();
        //    listOfTitles.ForEach(x =>
        //    {
        //        MusicAlbum mmm = new MusicAlbum() { CoverArtId = x.CoverArtId, Title = x.Title, ImageUrls = null };
        //    });




        //    CoverArtArchiveClient coverArtArchiveClient = new CoverArtArchiveClient(baseurl, requesturl, null);

        //    foreach (var album in musicAlbums)
        //    {
        //        string title = album.Title;
        //        var coverArtRet = await coverArtArchiveClient.GetCoverArtByIdAsync(album.CoverArtId);

        //        List<string> images = new List<string>();

        //        try
        //        {
        //            IDictionary<string, JToken> Jsondata = JObject.Parse(coverArtRet);
        //            var imagesJson = Jsondata["images"];

        //            foreach (var item in Jsondata["images"].Children())
        //            {
        //                images.Add(item["image"].ToString());
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            throw new JsonException("Unable to cast CoverArt Json Object " + ex.Message);
        //        }


        //        Assert.IsNotNull(coverArtRet);
        //        Assert.IsTrue(coverArtRet.Length > 0);
        //        Assert.IsTrue(images.Count > 0);
        //    }



        //}

    }
}
