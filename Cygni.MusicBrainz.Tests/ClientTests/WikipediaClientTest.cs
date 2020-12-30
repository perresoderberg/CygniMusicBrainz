using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Cygni.MusicBrainz.Facade;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit;
using NUnit.Framework;

namespace Cygni.MusicBrainz.Tests.FacadeTests
{
    //[TestFixture]
    //class WikipediaClientTest
    //{
    //    string baseurl = "https://en.wikipedia.org";
    //    string requesturl = "/w/api.php";
    //    string parameters = "action=query&format=json&prop=extracts&exintro=true&redirects=true";

        
    //    [SetUp]
    //    public void SetUp()
    //    {

    //    }


    //    [Test]
    //    public async Task CallToWikipediaClient_ResponseNotNull()
    //    {
    //        try
    //        {
    //            string title = "Nirvana (band)";

    //            WikipediaClient client = new WikipediaClient(baseurl, requesturl, parameters);

    //            var ret = await client.GetInfoByTitleAsync(title);

    //            Assert.IsNotNull(ret);
    //        }
    //        catch (Exception ex)
    //        {


    //        }

    //    }

    //    [Test]
    //    public async Task GetArtistData_ResponseNotNullOrEmpty()
    //    {
    //        try
    //        {
    //            string title = "Nirvana (band)";

    //            WikipediaClient client = new WikipediaClient(baseurl, requesturl, parameters);

    //            var ret = await client.GetInfoByTitleAsync(title);
    //            dynamic test = JObject.Parse(ret);

    //            JObject pages = (JObject)test["query"]["pages"];

    //            var artistdata = pages.First.ToObject<JProperty>().Value;

    //            string extract = artistdata["extract"].ToString();

    //            Assert.IsNotNull(ret);
    //            Assert.IsNotNull(pages);
    //            Assert.IsNotNull(artistdata);
    //            Assert.IsFalse(string.IsNullOrWhiteSpace(extract));
    //        }
    //        catch (Exception ex)
    //        {


    //        }

    //    }
    //}
}
